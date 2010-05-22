namespace ICSharpCode
{
    using ICSharpCode.SharpZipLib.Checksums;
    using ICSharpCode.SharpZipLib.Zip;
    using System;
    using System.Collections;
    using System.IO;

    public class ZIPPER : IDisposable
    {
        private string m_FolderToZIP;
        private ArrayList m_FileNamesToZIP;
        private string m_FileNameZipped;
        
        private ZipOutputStream m_ZipStream = null;
        private Crc32 m_Crc;

        #region Begin for Public Properties
        public  string FolderToZIP
        {
            get { return m_FolderToZIP; }
            set { m_FolderToZIP = value; }
        }

        public  ArrayList FileNamesToZIP
        {
            get { return m_FileNamesToZIP; }
            set { m_FileNamesToZIP = value; }
        }

        public  string FileNameZipped
        {
            get { return m_FileNameZipped; }
            set { m_FileNameZipped = value; }
        }
        #endregion

        public ZIPPER()
        {
            this.m_FolderToZIP = "";
            this.m_FileNamesToZIP = new ArrayList();
            this.m_FileNameZipped = "";
        }

        #region ZipFolder
        public void ZipFolder()
        {
            if (this.m_FolderToZIP.Trim().Length == 0)
            {
                throw new Exception("You must setup the folder name you want to zip!");
            }

            if(Directory.Exists(this.m_FolderToZIP) == false)
            {
                throw new Exception("The folder you input does not exist! Please check it!");
            }
            
            if (this.m_FileNameZipped.Trim().Length == 0)
            {
                throw new Exception("You must setup the zipped file name!");
            }
            
            string[] fileNames = Directory.GetFiles(this.m_FolderToZIP.Trim());

            if (fileNames.Length == 0)
            {
                throw new Exception("Can not find any file in this folder(" + this.m_FolderToZIP + ")!");
            }


            this.CreateZipFile(this.m_FileNameZipped);

            foreach(string file in fileNames)
            {
                this.ZipSingleFile(file);
            }

            this.CloseZipFile();
        }
        #endregion

        #region ZipFiles
        public void ZipFiles()
        {
            if (this.m_FileNamesToZIP.Count == 0)
            {
                throw new Exception("You must setup the files name you want to zip!");
            }

            foreach(object file in this.m_FileNamesToZIP)
            {
                if(File.Exists(((string)file).Trim()) == false)
                {
                    throw new Exception("The file(" + (string)file + ") you input does not exist! Please check it!");
                }
            }

            if (this.m_FileNameZipped.Trim().Length == 0)
            {
                throw new Exception("You must input the zipped file name!");
            }

            this.CreateZipFile(this.m_FileNameZipped);

            foreach(object file in this.m_FileNamesToZIP)
            {
                this.ZipSingleFile((string)file);
            }

            this.CloseZipFile();
        }
        #endregion

        #region CreateZipFile
 
        private void CreateZipFile(string fileNameZipped)
        {
            this.m_Crc = new Crc32();
            this.m_ZipStream = new ZipOutputStream(File.Create(fileNameZipped));
            this.m_ZipStream.SetLevel(6);
        }
        #endregion

        #region CloseZipFile
       
        private void CloseZipFile()
        {
            this.m_ZipStream.Finish();
            this.m_ZipStream.Close();
            this.m_ZipStream = null;
        }
        #endregion

        #region ZipSingleFile
      
        private void ZipSingleFile(string fileNameToZip)
        {
            FileStream fso = File.OpenRead(fileNameToZip);

            byte[] buffer = new byte[fso.Length];
            fso.Read(buffer,0,buffer.Length);

            ZipEntry zipEntry = new ZipEntry(fileNameToZip.Split('\\')[fileNameToZip.Split('\\').Length - 1]);
            
            zipEntry.DateTime = DateTime.Now;
            zipEntry.Size = fso.Length;

            fso.Close();
            fso = null;

            this.m_Crc.Reset();
            this.m_Crc.Update(buffer);
            zipEntry.Crc = this.m_Crc.Value;

            this.m_ZipStream.PutNextEntry(zipEntry);
            this.m_ZipStream.Write(buffer,0,buffer.Length);
        }
        #endregion

        #region IDisposable member

        public void Dispose()
        {
            if(this.m_ZipStream != null)
            {
                this.m_ZipStream.Close();
                this.m_ZipStream = null;
            }
        }

        #endregion
    }

}

