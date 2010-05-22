namespace Ionic.Utils.Zip
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    public class ZipFile : IEnumerable<ZipEntry>, IEnumerable, IDisposable
    {
        private string _Comment;
        private bool _contentsChanged;
        private bool _Debug;
        private List<ZipDirEntry> _direntries;
        private bool _disposed;
        private List<ZipEntry> _entries;
        private bool _fileAlreadyExists;
        private string _name;
        private Stream _readstream;
        private TextWriter _StatusMessageTextWriter;
        private string _TempFileFolder;
        private string _temporaryFileName;
        private bool _TrimVolumeFromFullyQualifiedPaths;
        private Stream _writestream;

        private ZipFile()
        {
            this._StatusMessageTextWriter = null;
            this._Debug = false;
            this._disposed = false;
            this._entries = null;
            this._direntries = null;
            this._TrimVolumeFromFullyQualifiedPaths = true;
            this._fileAlreadyExists = false;
            this._temporaryFileName = null;
            this._contentsChanged = false;
            this._TempFileFolder = ".";
        }

        public ZipFile(Stream OutputStream)
        {
            this._StatusMessageTextWriter = null;
            this._Debug = false;
            this._disposed = false;
            this._entries = null;
            this._direntries = null;
            this._TrimVolumeFromFullyQualifiedPaths = true;
            this._fileAlreadyExists = false;
            this._temporaryFileName = null;
            this._contentsChanged = false;
            this._TempFileFolder = ".";
            if (!OutputStream.CanWrite)
            {
                throw new ArgumentException("The OutputStream must be a writable stream.");
            }
            this._writestream = OutputStream;
            this._entries = new List<ZipEntry>();
            this._name = null;
        }

        public ZipFile(string ZipFileName)
        {
            this._StatusMessageTextWriter = null;
            this._Debug = false;
            this._disposed = false;
            this._entries = null;
            this._direntries = null;
            this._TrimVolumeFromFullyQualifiedPaths = true;
            this._fileAlreadyExists = false;
            this._temporaryFileName = null;
            this._contentsChanged = false;
            this._TempFileFolder = ".";
            this.InitFile(ZipFileName, null);
        }

        public ZipFile(Stream OutputStream, TextWriter StatusMessageWriter)
        {
            this._StatusMessageTextWriter = null;
            this._Debug = false;
            this._disposed = false;
            this._entries = null;
            this._direntries = null;
            this._TrimVolumeFromFullyQualifiedPaths = true;
            this._fileAlreadyExists = false;
            this._temporaryFileName = null;
            this._contentsChanged = false;
            this._TempFileFolder = ".";
            if (!OutputStream.CanWrite)
            {
                throw new ArgumentException("The OutputStream must be a writable stream.");
            }
            this._writestream = OutputStream;
            this._entries = new List<ZipEntry>();
            this._name = null;
            this._StatusMessageTextWriter = StatusMessageWriter;
        }

        public ZipFile(string ZipFileName, TextWriter StatusMessageWriter)
        {
            this._StatusMessageTextWriter = null;
            this._Debug = false;
            this._disposed = false;
            this._entries = null;
            this._direntries = null;
            this._TrimVolumeFromFullyQualifiedPaths = true;
            this._fileAlreadyExists = false;
            this._temporaryFileName = null;
            this._contentsChanged = false;
            this._TempFileFolder = ".";
            this.InitFile(ZipFileName, StatusMessageWriter);
        }

        public void AddDirectory(string DirectoryName)
        {
            this.AddDirectory(DirectoryName, null);
        }

        public void AddDirectory(string DirectoryName, string DirectoryPathInArchive)
        {
            if (this.Verbose)
            {
                this.StatusMessageTextWriter.WriteLine("adding {0}...", DirectoryName);
            }
            int num = 0;
            string[] files = Directory.GetFiles(DirectoryName);
            foreach (string str in files)
            {
                this.AddFile(str, DirectoryPathInArchive);
                num++;
            }
            if (num == 0)
            {
                string filename = !DirectoryName.EndsWith(@"\") ? (DirectoryName + @"\") : DirectoryName;
                ZipEntry entry = ZipEntry.Create(filename, DirectoryPathInArchive);
                entry.TrimVolumeFromFullyQualifiedPaths = this.TrimVolumeFromFullyQualifiedPaths;
                entry.MarkAsDirectory();
                this.InsureUniqueEntry(entry);
                this._entries.Add(entry);
                this._contentsChanged = true;
            }
            string[] directories = Directory.GetDirectories(DirectoryName);
            foreach (string str3 in directories)
            {
                string str4 = Path.GetFileName(str3).ToString();
                this.AddDirectory(str3, (DirectoryPathInArchive == null) ? null : Path.Combine(DirectoryPathInArchive, str4));
            }
            this._contentsChanged = true;
        }

        public ZipEntry AddFile(string FileName)
        {
            return this.AddFile(FileName, null);
        }

        public ZipEntry AddFile(string FileName, string DirectoryPathInArchive)
        {
            ZipEntry entry = ZipEntry.Create(FileName, DirectoryPathInArchive);
            entry.TrimVolumeFromFullyQualifiedPaths = this.TrimVolumeFromFullyQualifiedPaths;
            if (this.Verbose)
            {
                this.StatusMessageTextWriter.WriteLine("adding {0}...", FileName);
            }
            this.InsureUniqueEntry(entry);
            this._entries.Add(entry);
            this._contentsChanged = true;
            return entry;
        }

        public void AddItem(string FileOrDirectoryName)
        {
            this.AddItem(FileOrDirectoryName, null);
        }

        public void AddItem(string FileOrDirectoryName, string DirectoryPathInArchive)
        {
            if (File.Exists(FileOrDirectoryName))
            {
                this.AddFile(FileOrDirectoryName, DirectoryPathInArchive);
            }
            else
            {
                if (!Directory.Exists(FileOrDirectoryName))
                {
                    throw new Exception(string.Format("That file or directory ({0}) does not exist!", FileOrDirectoryName));
                }
                this.AddDirectory(FileOrDirectoryName, DirectoryPathInArchive);
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposeManagedResources)
        {
            if (!this._disposed)
            {
                if (disposeManagedResources)
                {
                    if (this._readstream != null)
                    {
                        this._readstream.Dispose();
                        this._readstream = null;
                    }
                    if (this._writestream != null)
                    {
                        this._writestream.Dispose();
                        this._writestream = null;
                    }
                }
                this._disposed = true;
            }
        }

        public void Extract(string filename)
        {
            this[filename].Extract();
        }

        public void Extract(string filename, bool WantOverwrite)
        {
            this[filename].Extract(WantOverwrite);
        }

        public void Extract(string filename, Stream OutputStream)
        {
            if (!OutputStream.CanWrite)
            {
                throw new ArgumentException("The OutputStream must be a writable stream.");
            }
            this[filename].Extract(OutputStream);
        }

        public void ExtractAll(string path)
        {
            this.ExtractAll(path, false);
        }

        public void ExtractAll(string path, bool WantOverwrite)
        {
            bool verbose = this.Verbose;
            foreach (ZipEntry entry in this._entries)
            {
                if (verbose)
                {
                    this.StatusMessageTextWriter.WriteLine("\n{1,-22} {2,-8} {3,4}   {4,-8}  {0}", new object[] { "Name", "Modified", "Size", "Ratio", "Packed" });
                    this.StatusMessageTextWriter.WriteLine(new string('-', 0x48));
                    verbose = false;
                }
                if (this.Verbose)
                {
                    this.StatusMessageTextWriter.WriteLine("{1,-22} {2,-8} {3,4:F0}%   {4,-8} {0}", new object[] { entry.FileName, entry.LastModified.ToString("yyyy-MM-dd HH:mm:ss"), entry.UncompressedSize, entry.CompressionRatio, entry.CompressedSize });
                    if ((entry.Comment != null) && (entry.Comment != ""))
                    {
                        this.StatusMessageTextWriter.WriteLine("  Comment: {0}", entry.Comment);
                    }
                }
                entry.Extract(path, WantOverwrite);
            }
        }

        ~ZipFile()
        {
            this.Dispose(false);
        }

        public IEnumerator<ZipEntry> GetEnumerator()
        {
            return new <GetEnumerator>d__0(0) { <>4__this = this };
        }

        private void InitFile(string ZipFileName, TextWriter StatusMessageWriter)
        {
            this._name = ZipFileName;
            this._StatusMessageTextWriter = StatusMessageWriter;
            if (File.Exists(this._name))
            {
                ReadIntoInstance(this);
                this._fileAlreadyExists = true;
            }
            else
            {
                this._entries = new List<ZipEntry>();
            }
        }

        private void InsureUniqueEntry(ZipEntry ze1)
        {
            foreach (ZipEntry entry in this._entries)
            {
                if (this._Debug)
                {
                    Console.WriteLine("Comparing {0} to {1}...", ze1.FileName, entry.FileName);
                }
                if (ze1.FileName == entry.FileName)
                {
                    throw new Exception(string.Format("The entry '{0}' already exists in the zip archive.", ze1.FileName));
                }
            }
        }

        public static ZipFile Read(byte[] buffer)
        {
            MemoryStream zipStream = new MemoryStream(buffer);
            return Read(zipStream, null);
        }

        public static ZipFile Read(Stream ZipStream)
        {
            return Read(ZipStream, null);
        }

        public static ZipFile Read(string ZipFileName)
        {
            return Read(ZipFileName, null);
        }

        public static ZipFile Read(byte[] buffer, TextWriter StatusMessageWriter)
        {
            ZipFile zf = new ZipFile {
                _StatusMessageTextWriter = StatusMessageWriter,
                _readstream = new MemoryStream(buffer)
            };
            ReadIntoInstance(zf);
            return zf;
        }

        public static ZipFile Read(Stream ZipStream, TextWriter StatusMessageWriter)
        {
            ZipFile zf = new ZipFile {
                _StatusMessageTextWriter = StatusMessageWriter,
                _readstream = ZipStream
            };
            ReadIntoInstance(zf);
            return zf;
        }

        public static ZipFile Read(string ZipFileName, TextWriter StatusMessageWriter)
        {
            ZipFile zf = new ZipFile {
                _StatusMessageTextWriter = StatusMessageWriter,
                _name = ZipFileName
            };
            ReadIntoInstance(zf);
            return zf;
        }

        private static void ReadCentralDirectoryFooter(ZipFile zf)
        {
            Stream readStream = zf.ReadStream;
            int num = Shared.ReadSignature(readStream);
            if (num != 0x6054b50L)
            {
                readStream.Seek(-4L, SeekOrigin.Current);
                throw new Exception(string.Format("  ZipFile::Read(): Bad signature ({0:X8}) at position 0x{1:X8}", num, readStream.Position));
            }
            byte[] buffer = new byte[0x10];
            int num2 = zf.ReadStream.Read(buffer, 0, buffer.Length);
            ReadZipFileComment(zf);
        }

        private static void ReadIntoInstance(ZipFile zf)
        {
            ZipEntry entry;
            ZipDirEntry entry2;
            zf._entries = new List<ZipEntry>();
            if (zf.Verbose)
            {
                if (zf.Name == null)
                {
                    zf.StatusMessageTextWriter.WriteLine("Reading zip from stream...");
                }
                else
                {
                    zf.StatusMessageTextWriter.WriteLine("Reading zip {0}...", zf.Name);
                }
            }
            while ((entry = ZipEntry.Read(zf.ReadStream)) != null)
            {
                if (zf.Verbose)
                {
                    zf.StatusMessageTextWriter.WriteLine("  {0}", entry.FileName);
                }
                if (zf._Debug)
                {
                    Console.WriteLine("  ZipFile::Read(): ZipEntry: {0}", entry.FileName);
                }
                zf._entries.Add(entry);
            }
            zf._direntries = new List<ZipDirEntry>();
            while ((entry2 = ZipDirEntry.Read(zf.ReadStream)) != null)
            {
                if (zf._Debug)
                {
                    Console.WriteLine("  ZipFile::Read(): ZipDirEntry: {0}", entry2.FileName);
                }
                zf._direntries.Add(entry2);
                foreach (ZipEntry entry3 in zf._entries)
                {
                    if (entry3.FileName == entry2.FileName)
                    {
                        entry3.Comment = entry2.Comment;
                        if (entry2.IsDirectory)
                        {
                            entry3.MarkAsDirectory();
                        }
                        break;
                    }
                }
            }
            ReadCentralDirectoryFooter(zf);
            if ((zf.Verbose && (zf.Comment != null)) && (zf.Comment != ""))
            {
                zf.StatusMessageTextWriter.WriteLine("Zip file Comment: {0}", zf.Comment);
            }
            zf.ReadStream.Close();
        }

        private static void ReadZipFileComment(ZipFile zf)
        {
            byte[] buffer = new byte[2];
            int num = zf.ReadStream.Read(buffer, 0, buffer.Length);
            short num2 = (short) (buffer[0] + (buffer[1] * 0x100));
            if (num2 > 0)
            {
                buffer = new byte[num2];
                num = zf.ReadStream.Read(buffer, 0, buffer.Length);
                zf.Comment = Shared.StringFromBuffer(buffer, 0, buffer.Length);
            }
        }

        public void Save()
        {
            if (this._contentsChanged)
            {
                if (this.Verbose)
                {
                    this.StatusMessageTextWriter.WriteLine("Saving....");
                }
                foreach (ZipEntry entry in this._entries)
                {
                    entry.Write(this.WriteStream);
                }
                this.WriteCentralDirectoryStructure();
                this.WriteStream.Close();
                this.WriteStream = null;
                if (this._temporaryFileName != null)
                {
                    if (this._fileAlreadyExists)
                    {
                        File.Replace(this._temporaryFileName, this._name, null);
                    }
                    else
                    {
                        File.Move(this._temporaryFileName, this._name);
                    }
                }
                this._fileAlreadyExists = true;
            }
        }

        public void Save(string ZipFileName)
        {
            if (this._name == null)
            {
                this._writestream = null;
            }
            this._name = ZipFileName;
            this._contentsChanged = true;
            this._fileAlreadyExists = File.Exists(this._name);
            this.Save();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void WriteCentralDirectoryFooter(long StartOfCentralDirectory, long EndOfCentralDirectory)
        {
            byte[] buffer = new byte[0x400];
            int count = 0;
            buffer[count++] = 80;
            buffer[count++] = 0x4b;
            buffer[count++] = 5;
            buffer[count++] = 6;
            buffer[count++] = 0;
            buffer[count++] = 0;
            buffer[count++] = 0;
            buffer[count++] = 0;
            buffer[count++] = (byte) (this._entries.Count & 0xff);
            buffer[count++] = (byte) ((this._entries.Count & 0xff00) >> 8);
            buffer[count++] = (byte) (this._entries.Count & 0xff);
            buffer[count++] = (byte) ((this._entries.Count & 0xff00) >> 8);
            int num2 = (int) (EndOfCentralDirectory - StartOfCentralDirectory);
            buffer[count++] = (byte) (num2 & 0xff);
            buffer[count++] = (byte) ((num2 & 0xff00) >> 8);
            buffer[count++] = (byte) ((num2 & 0xff0000) >> 0x10);
            buffer[count++] = (byte) ((num2 & 0xff000000L) >> 0x18);
            int num3 = (int) StartOfCentralDirectory;
            buffer[count++] = (byte) (num3 & 0xff);
            buffer[count++] = (byte) ((num3 & 0xff00) >> 8);
            buffer[count++] = (byte) ((num3 & 0xff0000) >> 0x10);
            buffer[count++] = (byte) ((num3 & 0xff000000L) >> 0x18);
            if ((this.Comment == null) || (this.Comment.Length == 0))
            {
                buffer[count++] = 0;
                buffer[count++] = 0;
            }
            else
            {
                short length = (short) this.Comment.Length;
                if (((length + count) + 2) > buffer.Length)
                {
                    length = (short) ((buffer.Length - count) - 2);
                }
                buffer[count++] = (byte) (length & 0xff);
                buffer[count++] = (byte) ((length & 0xff00) >> 8);
                char[] chArray = this.Comment.ToCharArray();
                int index = 0;
                index = 0;
                while ((index < length) && ((count + index) < buffer.Length))
                {
                    buffer[count + index] = BitConverter.GetBytes(chArray[index])[0];
                    index++;
                }
                count += index;
            }
            this.WriteStream.Write(buffer, 0, count);
        }

        private void WriteCentralDirectoryStructure()
        {
            long length = this.WriteStream.Length;
            foreach (ZipEntry entry in this._entries)
            {
                entry.WriteCentralDirectoryEntry(this.WriteStream);
            }
            long endOfCentralDirectory = this.WriteStream.Length;
            this.WriteCentralDirectoryFooter(length, endOfCentralDirectory);
        }

        public string Comment
        {
            get
            {
                return this._Comment;
            }
            set
            {
                this._Comment = value;
                this._contentsChanged = true;
            }
        }

        public ZipEntry this[string filename]
        {
            get
            {
                foreach (ZipEntry entry in this._entries)
                {
                    if (entry.FileName == filename)
                    {
                        return entry;
                    }
                    if (filename.Replace(@"\", "/") == entry.FileName)
                    {
                        return entry;
                    }
                    if (entry.FileName.Replace(@"\", "/") == filename)
                    {
                        return entry;
                    }
                }
                return null;
            }
        }

        public string Name
        {
            get
            {
                return this._name;
            }
        }

        private Stream ReadStream
        {
            get
            {
                if ((this._readstream == null) && (this._name != null))
                {
                    this._readstream = File.OpenRead(this._name);
                }
                return this._readstream;
            }
            set
            {
                if (value != null)
                {
                    throw new Exception("Cannot set ReadStream explicitly to a non-null value.");
                }
                this._readstream = null;
            }
        }

        public TextWriter StatusMessageTextWriter
        {
            get
            {
                return this._StatusMessageTextWriter;
            }
            set
            {
                this._StatusMessageTextWriter = value;
            }
        }

        public string TempFileFolder
        {
            get
            {
                return this._TempFileFolder;
            }
            set
            {
                this._TempFileFolder = value;
            }
        }

        public bool TrimVolumeFromFullyQualifiedPaths
        {
            get
            {
                return this._TrimVolumeFromFullyQualifiedPaths;
            }
            set
            {
                this._TrimVolumeFromFullyQualifiedPaths = value;
            }
        }

        private bool Verbose
        {
            get
            {
                return (this._StatusMessageTextWriter != null);
            }
        }

        private Stream WriteStream
        {
            get
            {
                if (this._writestream == null)
                {
                    this._temporaryFileName = (this.TempFileFolder != ".") ? Path.Combine(this.TempFileFolder, Path.GetRandomFileName()) : Path.GetRandomFileName();
                    this._writestream = new FileStream(this._temporaryFileName, FileMode.CreateNew);
                }
                return this._writestream;
            }
            set
            {
                if (value != null)
                {
                    throw new Exception("Cannot set the stream to a non-null value.");
                }
                this._writestream = null;
            }
        }

        [CompilerGenerated]
        private sealed class <GetEnumerator>d__0 : IEnumerator<ZipEntry>, IEnumerator, IDisposable
        {
            private int <>1__state;
            private ZipEntry <>2__current;
            public ZipFile <>4__this;
            public List<ZipEntry>.Enumerator <>7__wrap2;
            public ZipEntry <e>5__1;

            [DebuggerHidden]
            public <GetEnumerator>d__0(int <>1__state)
            {
                this.<>1__state = <>1__state;
            }

            private void <>m__Finally3()
            {
                this.<>1__state = -1;
                this.<>7__wrap2.Dispose();
            }

            private bool MoveNext()
            {
                try
                {
                    switch (this.<>1__state)
                    {
                        case 0:
                            this.<>1__state = -1;
                            this.<>7__wrap2 = this.<>4__this._entries.GetEnumerator();
                            this.<>1__state = 1;
                            while (this.<>7__wrap2.MoveNext())
                            {
                                this.<e>5__1 = this.<>7__wrap2.Current;
                                this.<>2__current = this.<e>5__1;
                                this.<>1__state = 2;
                                return true;
                            Label_0071:
                                this.<>1__state = 1;
                            }
                            this.<>m__Finally3();
                            break;

                        case 2:
                            goto Label_0071;
                    }
                    return false;
                }
                fault
                {
                    this.System.IDisposable.Dispose();
                }
            }

            [DebuggerHidden]
            void IEnumerator.Reset()
            {
                throw new NotSupportedException();
            }

            void IDisposable.Dispose()
            {
                switch (this.<>1__state)
                {
                    case 1:
                    case 2:
                        try
                        {
                        }
                        finally
                        {
                            this.<>m__Finally3();
                        }
                        break;
                }
            }

            ZipEntry IEnumerator<ZipEntry>.Current
            {
                [DebuggerHidden]
                get
                {
                    return this.<>2__current;
                }
            }

            object IEnumerator.Current
            {
                [DebuggerHidden]
                get
                {
                    return this.<>2__current;
                }
            }
        }
    }
}

