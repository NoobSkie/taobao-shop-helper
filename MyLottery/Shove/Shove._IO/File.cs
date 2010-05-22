namespace Shove._IO
{
    using ICSharpCode.SharpZipLib.Checksums;
    using ICSharpCode.SharpZipLib.Zip;
    using System;
    using System.Collections;
    using System.IO;
    using System.Text;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;

    public class File
    {
        private static void GetFileList(string path, ArrayList fileList)
        {
            string[] files = Directory.GetFiles(path);
            string[] directories = Directory.GetDirectories(path);
            for (int i = 0; i < files.Length; i++)
            {
                fileList.Add(files[i]);
            }
            for (int j = 0; j < directories.Length; j++)
            {
                GetFileList(directories[j], fileList);
            }
        }

        public static bool Compress(string FileName)
        {
            return Compress(FileName, "");
        }

        public static bool Compress(string FileName, string ZipFileName)
        {
            ZipOutputStream stream;
            FileStream stream2;
            if (ZipFileName == "")
            {
                ZipFileName = FileName + ".zip";
            }
            Crc32 crc = new Crc32();
            try
            {
                stream = new ZipOutputStream(System.IO.File.Create(ZipFileName));
            }
            catch
            {
                return false;
            }
            stream.SetLevel(6);
            try
            {
                stream2 = System.IO.File.OpenRead(FileName);
            }
            catch
            {
                stream.Finish();
                stream.Close();
                System.IO.File.Delete(ZipFileName);
                return false;
            }
            byte[] buffer = new byte[stream2.Length];
            stream2.Read(buffer, 0, buffer.Length);
            ZipEntry entry = new ZipEntry(FileName.Split(new char[] { '\\' })[FileName.Split(new char[] { '\\' }).Length - 1]);
            entry.DateTime = DateTime.Now;
            entry.Size = stream2.Length;
            stream2.Close();
            crc.Reset();
            crc.Update(buffer);
            entry.Crc = crc.Value;
            stream.PutNextEntry(entry);
            stream.Write(buffer, 0, buffer.Length);
            stream.Finish();
            stream.Close();
            return true;
        }

        public static void CopyDirectory(string src, string dest)
        {
            if (Directory.Exists(src))
            {
                if (!Directory.Exists(dest))
                {
                    Directory.CreateDirectory(dest);
                }
                DirectoryInfo info = new DirectoryInfo(src);
                foreach (FileSystemInfo info2 in info.GetFileSystemInfos())
                {
                    string destFileName = Path.Combine(dest, info2.Name);
                    if (info2 is FileInfo)
                    {
                        System.IO.File.Copy(info2.FullName, destFileName, true);
                    }
                    else
                    {
                        Directory.CreateDirectory(destFileName);
                        CopyDirectory(info2.FullName, destFileName);
                    }
                }
            }
        }

        public static bool Decompress(string ZipFileName)
        {
            return Decompress(ZipFileName, "");
        }

        public static bool Decompress(string ZipFileName, string FileName)
        {
            ZipInputStream stream;
            FileName = FileName.Trim();
            try
            {
                stream = new ZipInputStream(System.IO.File.OpenRead(ZipFileName));
            }
            catch
            {
                return false;
            }
            ZipEntry nextEntry = stream.GetNextEntry();
            if (nextEntry == null)
            {
                stream.Close();
                return false;
            }
            string directoryName = Path.GetDirectoryName((FileName == "") ? ZipFileName : FileName);
            if (FileName == "")
            {
                FileName = Path.Combine(directoryName, Path.GetFileName(nextEntry.Name));
            }
            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }
            FileStream stream2 = System.IO.File.Create(FileName);
            int count = 0x800;
            byte[] buffer = new byte[count];
            while (true)
            {
                count = stream.Read(buffer, 0, buffer.Length);
                if (count <= 0)
                {
                    break;
                }
                stream2.Write(buffer, 0, count);
            }
            stream2.Close();
            stream.Close();
            return true;
        }

        public static void Download(params string[] FileNames)
        {
            Download(HttpContext.Current, FileNames);
        }

        public static void Download(HttpContext context, params string[] FileNames)
        {
            if (((context != null) && (FileNames != null)) && (FileNames.Length >= 1))
            {
                ArrayList list = new ArrayList();
                for (int i = 0; i < FileNames.Length; i++)
                {
                    FileNames[i] = context.Server.MapPath(FileNames[i]);
                    if (System.IO.File.Exists(FileNames[i]))
                    {
                        list.Add(FileNames[i]);
                    }
                }
                if (list.Count >= 1)
                {
                    HttpResponse response = context.Response;
                    if (list.Count == 1)
                    {
                        string path = list[0].ToString();
                        response.AppendHeader("Content-Disposition", "attachment;filename=" + Path.GetFileName(path));
                        response.ContentType = "application/octet-stream";
                        response.WriteFile(path);
                    }
                    else
                    {
                        string[] fileNames = new string[list.Count];
                        for (int j = 0; j < list.Count; j++)
                        {
                            fileNames[j] = list[j].ToString();
                        }
                        byte[] buffer = ZipMultiFiles(9, true, fileNames);
                        response.AppendHeader("Content-Disposition", "attachment;filename=" + Path.GetFileName(fileNames[0]) + ".zip");
                        response.ContentType = "application/octet-stream";
                        response.BinaryWrite(buffer);
                    }
                    response.Flush();
                    response.End();
                }
            }
        }

        public static string[] GetFileList(string Path)
        {
            DirectoryInfo info = new DirectoryInfo(Path);
            if (!info.Exists)
            {
                return null;
            }
            FileInfo[] files = info.GetFiles();
            if (files.Length == 0)
            {
                return null;
            }
            string[] strArray = new string[files.Length];
            for (int i = 0; i < files.Length; i++)
            {
                strArray[i] = files[i].Name;
            }
            return strArray;
        }

        public static string[] GetFileList(Page page, string Path)
        {
            return GetFileList(page.Server.MapPath(Path));
        }

        public static string[] GetFileListWithSubDir(string StartDirName)
        {
            ArrayList list = new ArrayList();
            GetFileList(StartDirName, list);
            if (list.Count < 1)
            {
                return null;
            }
            string[] strArray = new string[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                strArray[i] = list[i].ToString();
            }
            return strArray;
        }

        public static string[] GetFileListWithSubDir(Page page, string Path)
        {
            return GetFileListWithSubDir(page.Server.MapPath(Path));
        }

        public static string GetNewFileName(Page page, string path, string Ext, string Flag)
        {
            string str;
            int num = 0;
            do
            {
                str = Flag + num.ToString() + Ext;
                num++;
            }
            while (System.IO.File.Exists(page.Server.MapPath(path + str)));
            return str;
        }

        private static bool m000001(HtmlInputFile p0, string p1)
        {
            if (string.IsNullOrEmpty(p1))
            {
                return true;
            }
            string str = p0.PostedFile.ContentType.ToLower();
            p1 = p1.Trim().ToLower();
            foreach (string str2 in p1.Split(new char[] { ',' }))
            {
                if (!string.IsNullOrEmpty(str2))
                {
                    string str3 = str2.Trim();
                    if (str.IndexOf(str3) >= 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static string ReadFile(string FileName)
        {
            return System.IO.File.ReadAllText(FileName, Encoding.Default);
        }

        public static int UploadFile(Page page, HtmlInputFile file, string TargetDirectory, ref string NewFileName, string LimitFileTypeList)
        {
            if (!m000001(file, LimitFileTypeList))
            {
                return -101;
            }
            if (file.Value.Trim() == "")
            {
                return -1;
            }
            if (!TargetDirectory.EndsWith("/") && !TargetDirectory.EndsWith(@"\"))
            {
                TargetDirectory = TargetDirectory + "/";
            }
            string extension = Path.GetExtension(file.Value);
            NewFileName = GetNewFileName(page, TargetDirectory, extension, "");
            try
            {
                file.PostedFile.SaveAs(page.Server.MapPath(TargetDirectory + NewFileName));
            }
            catch
            {
                return -3;
            }
            return 0;
        }

        public static int UploadFile(Page page, HtmlInputFile file, string TargetDirectory, ref string ShortFileName, bool OverwriteExistFile, string LimitFileTypeList)
        {
            string str2;
            if (!m000001(file, LimitFileTypeList))
            {
                return -101;
            }
            try
            {
                string str = file.Value.Trim().Replace(@"\", @"\\");
                str2 = str.Substring(str.LastIndexOf(@"\") + 1, (str.Length - str.LastIndexOf(@"\")) - 1);
                ShortFileName = str2;
            }
            catch
            {
                return -1;
            }
            string path = page.Server.MapPath(TargetDirectory + str2);
            if (System.IO.File.Exists(path) && !OverwriteExistFile)
            {
                return -2;
            }
            try
            {
                file.PostedFile.SaveAs(path);
            }
            catch
            {
                return -3;
            }
            return 0;
        }

        public static int UploadFile(Page page, HtmlInputFile file, string TargetDirectory, string FileName, bool OverwriteExistFile, string LimitFileTypeList)
        {
            if (!m000001(file, LimitFileTypeList))
            {
                return -101;
            }
            if (file.Value.Trim() == "")
            {
                return -1;
            }
            if (!TargetDirectory.EndsWith("/") && !TargetDirectory.EndsWith(@"\"))
            {
                TargetDirectory = TargetDirectory + "/";
            }
            string path = page.Server.MapPath(TargetDirectory + FileName);
            if (System.IO.File.Exists(path) && !OverwriteExistFile)
            {
                return -2;
            }
            try
            {
                file.PostedFile.SaveAs(path);
            }
            catch
            {
                return -3;
            }
            return 0;
        }

        public static bool WriteFile(string FileName, string Content)
        {
            return WriteFile(FileName, Content, Encoding.Default);
        }

        public static bool WriteFile(string FileName, string Content, Encoding encoding)
        {
            bool flag = true;
            try
            {
                System.IO.File.WriteAllText(FileName, Content, encoding);
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public static byte[] ZipMultiFiles(int CompressLevel, bool isWithoutFilePathInfo, params string[] FileNames)
        {
            ZipOutputStream stream = null;
            FileStream stream2 = null;
            MemoryStream baseOutputStream = new MemoryStream();
            bool flag = false;
            try
            {
                Crc32 crc = new Crc32();
                stream = new ZipOutputStream(baseOutputStream);
                stream.SetLevel(CompressLevel);
                foreach (string str in FileNames)
                {
                    if (System.IO.File.Exists(str))
                    {
                        stream2 = System.IO.File.OpenRead(str);
                        byte[] buffer = new byte[stream2.Length];
                        stream2.Read(buffer, 0, buffer.Length);
                        stream2.Close();
                        crc.Reset();
                        crc.Update(buffer);
                        ZipEntry entry = new ZipEntry(isWithoutFilePathInfo ? Path.GetFileName(str) : str);
                        entry.DateTime = DateTime.Now;
                        entry.Size = buffer.Length;
                        entry.Crc = crc.Value;
                        stream.PutNextEntry(entry);
                        stream.Write(buffer, 0, buffer.Length);
                    }
                }
                flag = true;
            }
            catch
            {
            }
            finally
            {
                if (stream2 != null)
                {
                    stream2.Close();
                }
                if (stream != null)
                {
                    stream.Finish();
                    stream.Close();
                }
            }
            byte[] buffer2 = null;
            if (flag)
            {
                buffer2 = baseOutputStream.GetBuffer();
            }
            return buffer2;
        }
    }
}

