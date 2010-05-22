namespace Ionic.Utils.Zip
{
    using System;
    using System.IO;
    using System.IO.Compression;

    public class ZipEntry
    {
        private byte[] __filedata;
        private short _BitField;
        private string _Comment;
        private int _CompressedSize;
        private DeflateStream _CompressedStream;
        private short _CompressionMethod;
        private int _Crc32;
        private bool _Debug = false;
        private byte[] _Extra;
        private string _FileNameInArchive;
        private byte[] _header;
        private bool _IsDirectory;
        private int _LastModDateTime;
        private DateTime _LastModified;
        private string _LocalFileName;
        private bool _OverwriteOnExtract = false;
        private int _RelativeOffsetOfHeader;
        private bool _TrimVolumeFromFullyQualifiedPaths = true;
        private int _UncompressedSize;
        private MemoryStream _UnderlyingMemoryStream;
        private short _VersionNeeded;

        private ZipEntry()
        {
        }

        internal static ZipEntry Create(string filename)
        {
            return Create(filename, null);
        }

        internal static ZipEntry Create(string filename, string DirectoryPathInArchive)
        {
            ZipEntry entry = new ZipEntry {
                _LocalFileName = filename
            };
            if (DirectoryPathInArchive == null)
            {
                entry._FileNameInArchive = filename;
            }
            else
            {
                entry._FileNameInArchive = Path.Combine(DirectoryPathInArchive, Path.GetFileName(filename));
            }
            entry._LastModified = File.GetLastWriteTime(filename);
            if (entry._LastModified.IsDaylightSavingTime())
            {
                DateTime time = entry._LastModified - new TimeSpan(1, 0, 0);
                entry._LastModDateTime = Shared.DateTimeToPacked(time);
                return entry;
            }
            entry._LastModDateTime = Shared.DateTimeToPacked(entry._LastModified);
            return entry;
        }

        public void Extract()
        {
            this.Extract(".");
        }

        public void Extract(bool WantOverwrite)
        {
            this.Extract(".", WantOverwrite);
        }

        public void Extract(Stream s)
        {
            this.Extract(null, s);
        }

        public void Extract(string BaseDirectory)
        {
            this.Extract(BaseDirectory, (Stream) null);
        }

        public void Extract(string BaseDirectory, bool Overwrite)
        {
            this.OverwriteOnExtract = Overwrite;
            this.Extract(BaseDirectory, (Stream) null);
        }

        private void Extract(string basedir, Stream s)
        {
            string path = null;
            if (basedir != null)
            {
                path = Path.Combine(basedir, this.FileName);
                if (this.IsDirectory || this.FileName.EndsWith("/"))
                {
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    return;
                }
            }
            else
            {
                if (s == null)
                {
                    throw new Exception("Invalid input.");
                }
                if (this.IsDirectory || this.FileName.EndsWith("/"))
                {
                    return;
                }
            }
            using (MemoryStream stream = new MemoryStream(this._FileData))
            {
                Stream stream2 = null;
                try
                {
                    if (this.CompressedSize == this.UncompressedSize)
                    {
                        stream2 = stream;
                    }
                    else
                    {
                        stream2 = new DeflateStream(stream, CompressionMode.Decompress);
                    }
                    if ((path != null) && !Directory.Exists(Path.GetDirectoryName(path)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(path));
                    }
                    Stream stream3 = null;
                    try
                    {
                        int length;
                        if (path != null)
                        {
                            if (this.OverwriteOnExtract && File.Exists(path))
                            {
                                File.Delete(path);
                            }
                            stream3 = new FileStream(path, FileMode.CreateNew);
                        }
                        else
                        {
                            stream3 = s;
                        }
                        byte[] buffer = new byte[0x1000];
                        if (this._Debug)
                        {
                            Console.WriteLine("{0}: _FileData.Length= {1}", path, this._FileData.Length);
                            Console.WriteLine("{0}: memstream.Position: {1}", path, stream.Position);
                            length = this._FileData.Length;
                            if (length > 0x3e8)
                            {
                                length = 500;
                                Console.WriteLine("{0}: truncating dump from {1} to {2} bytes...", path, this._FileData.Length, length);
                            }
                            for (int i = 0; i < length; i += 2)
                            {
                                if ((i > 0) && ((i % 40) == 0))
                                {
                                    Console.WriteLine();
                                }
                                Console.Write(" {0:X2}", this._FileData[i]);
                                if ((i + 1) < length)
                                {
                                    Console.Write("{0:X2}", this._FileData[i + 1]);
                                }
                            }
                            Console.WriteLine("\n");
                        }
                        length = 1;
                        while (length != 0)
                        {
                            if (this._Debug)
                            {
                                Console.WriteLine("{0}: about to read...", path);
                            }
                            length = stream2.Read(buffer, 0, buffer.Length);
                            if (this._Debug)
                            {
                                Console.WriteLine("{0}: got {1} bytes", path, length);
                            }
                            if (length > 0)
                            {
                                if (this._Debug)
                                {
                                    Console.WriteLine("{0}: about to write...", path);
                                }
                                stream3.Write(buffer, 0, length);
                            }
                        }
                    }
                    finally
                    {
                        if ((stream3 != null) && (path != null))
                        {
                            stream3.Close();
                            stream3.Dispose();
                        }
                    }
                    if (path != null)
                    {
                        if (this.LastModified.IsDaylightSavingTime())
                        {
                            DateTime lastWriteTime = this.LastModified + new TimeSpan(1, 0, 0);
                            File.SetLastWriteTime(path, lastWriteTime);
                        }
                        else
                        {
                            File.SetLastWriteTime(path, this.LastModified);
                        }
                    }
                }
                finally
                {
                    if ((stream2 != null) && (stream2 != stream))
                    {
                        stream2.Close();
                        stream2.Dispose();
                    }
                }
            }
        }

        private static bool IsNotValidSig(int signature)
        {
            return (signature != 0x4034b50);
        }

        internal void MarkAsDirectory()
        {
            this._IsDirectory = true;
        }

        internal static ZipEntry Read(Stream s)
        {
            ZipEntry ze = new ZipEntry();
            if (!ReadHeader(s, ze))
            {
                return null;
            }
            ze.__filedata = new byte[ze.CompressedSize];
            if (s.Read(ze._FileData, 0, ze._FileData.Length) != ze._FileData.Length)
            {
                throw new Exception("badly formatted zip file.");
            }
            if ((ze._BitField & 8) == 8)
            {
                s.Seek(0x10L, SeekOrigin.Current);
            }
            return ze;
        }

        private static bool ReadHeader(Stream s, ZipEntry ze)
        {
            int signature = Shared.ReadSignature(s);
            if (IsNotValidSig(signature))
            {
                s.Seek(-4L, SeekOrigin.Current);
                if (ZipDirEntry.IsNotValidSig(signature))
                {
                    throw new Exception(string.Format("  ZipEntry::Read(): Bad signature ({0:X8}) at position  0x{1:X8}", signature, s.Position));
                }
                return false;
            }
            byte[] buffer = new byte[0x1a];
            if (s.Read(buffer, 0, buffer.Length) != buffer.Length)
            {
                return false;
            }
            int num3 = 0;
            ze._VersionNeeded = (short) (buffer[num3++] + (buffer[num3++] * 0x100));
            ze._BitField = (short) (buffer[num3++] + (buffer[num3++] * 0x100));
            ze._CompressionMethod = (short) (buffer[num3++] + (buffer[num3++] * 0x100));
            ze._LastModDateTime = ((buffer[num3++] + (buffer[num3++] * 0x100)) + ((buffer[num3++] * 0x100) * 0x100)) + (((buffer[num3++] * 0x100) * 0x100) * 0x100);
            if ((ze._BitField & 8) != 8)
            {
                ze._Crc32 = ((buffer[num3++] + (buffer[num3++] * 0x100)) + ((buffer[num3++] * 0x100) * 0x100)) + (((buffer[num3++] * 0x100) * 0x100) * 0x100);
                ze._CompressedSize = ((buffer[num3++] + (buffer[num3++] * 0x100)) + ((buffer[num3++] * 0x100) * 0x100)) + (((buffer[num3++] * 0x100) * 0x100) * 0x100);
                ze._UncompressedSize = ((buffer[num3++] + (buffer[num3++] * 0x100)) + ((buffer[num3++] * 0x100) * 0x100)) + (((buffer[num3++] * 0x100) * 0x100) * 0x100);
            }
            else
            {
                num3 += 12;
            }
            short num4 = (short) (buffer[num3++] + (buffer[num3++] * 0x100));
            short num5 = (short) (buffer[num3++] + (buffer[num3++] * 0x100));
            buffer = new byte[num4];
            int num2 = s.Read(buffer, 0, buffer.Length);
            ze._FileNameInArchive = Shared.StringFromBuffer(buffer, 0, buffer.Length);
            ze._LocalFileName = ze._FileNameInArchive;
            ze._Extra = new byte[num5];
            num2 = s.Read(ze._Extra, 0, ze._Extra.Length);
            ze._LastModified = Shared.PackedToDateTime(ze._LastModDateTime);
            if ((ze._BitField & 8) == 8)
            {
                long position = s.Position;
                long num7 = Shared.FindSignature(s, 0x8074b50);
                if (num7 == -1L)
                {
                    return false;
                }
                buffer = new byte[12];
                if (s.Read(buffer, 0, buffer.Length) != 12)
                {
                    return false;
                }
                num3 = 0;
                ze._Crc32 = ((buffer[num3++] + (buffer[num3++] * 0x100)) + ((buffer[num3++] * 0x100) * 0x100)) + (((buffer[num3++] * 0x100) * 0x100) * 0x100);
                ze._CompressedSize = ((buffer[num3++] + (buffer[num3++] * 0x100)) + ((buffer[num3++] * 0x100) * 0x100)) + (((buffer[num3++] * 0x100) * 0x100) * 0x100);
                ze._UncompressedSize = ((buffer[num3++] + (buffer[num3++] * 0x100)) + ((buffer[num3++] * 0x100) * 0x100)) + (((buffer[num3++] * 0x100) * 0x100) * 0x100);
                if (num7 != ze._CompressedSize)
                {
                    throw new Exception("Data format error (bit 3 is set)");
                }
                s.Seek(position, SeekOrigin.Begin);
            }
            return true;
        }

        internal void Write(Stream s)
        {
            byte[] bytes = new byte[0x1000];
            this.WriteHeader(s, bytes);
            if (!this.IsDirectory)
            {
                if (this._Debug)
                {
                    Console.WriteLine("{0}: writing compressed data to zipfile...", this.FileName);
                    Console.WriteLine("{0}: total data length: {1}", this.FileName, this._CompressedSize);
                }
                if (this._CompressedSize == 0)
                {
                    if (this._UnderlyingMemoryStream != null)
                    {
                        this._UnderlyingMemoryStream.Close();
                        this._UnderlyingMemoryStream = null;
                    }
                }
                else if (this._FileData != null)
                {
                    s.Write(this._FileData, 0, this._FileData.Length);
                }
                else
                {
                    int num;
                    this._UnderlyingMemoryStream.Position = 0L;
                    while ((num = this._UnderlyingMemoryStream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        if (this._Debug)
                        {
                            Console.WriteLine("{0}: transferring {1} bytes...", this.FileName, num);
                            for (int i = 0; i < num; i += 2)
                            {
                                if ((i > 0) && ((i % 40) == 0))
                                {
                                    Console.WriteLine();
                                }
                                Console.Write(" {0:X2}", bytes[i]);
                                if ((i + 1) < num)
                                {
                                    Console.Write("{0:X2}", bytes[i + 1]);
                                }
                            }
                            Console.WriteLine("\n");
                        }
                        s.Write(bytes, 0, num);
                    }
                    this._UnderlyingMemoryStream.Close();
                    this._UnderlyingMemoryStream = null;
                }
            }
        }

        internal void WriteCentralDirectoryEntry(Stream s)
        {
            byte[] buffer = new byte[0x1000];
            int count = 0;
            buffer[count++] = 80;
            buffer[count++] = 0x4b;
            buffer[count++] = 1;
            buffer[count++] = 2;
            buffer[count++] = this.Header[4];
            buffer[count++] = this.Header[5];
            int index = 0;
            index = 0;
            while (index < 0x1a)
            {
                buffer[count + index] = this.Header[4 + index];
                index++;
            }
            count += index;
            int length = 0;
            if ((this.Comment == null) || (this.Comment.Length == 0))
            {
                buffer[count++] = 0;
                buffer[count++] = 0;
            }
            else
            {
                length = this.Comment.Length;
                if ((length + count) > buffer.Length)
                {
                    length = buffer.Length - count;
                }
                buffer[count++] = (byte) (length & 0xff);
                buffer[count++] = (byte) ((length & 0xff00) >> 8);
            }
            buffer[count++] = 0;
            buffer[count++] = 0;
            buffer[count++] = this.IsDirectory ? ((byte) 0) : ((byte) 1);
            buffer[count++] = 0;
            buffer[count++] = this.IsDirectory ? ((byte) 0x10) : ((byte) 0x20);
            buffer[count++] = 0;
            buffer[count++] = 0xb6;
            buffer[count++] = 0x81;
            buffer[count++] = (byte) (this._RelativeOffsetOfHeader & 0xff);
            buffer[count++] = (byte) ((this._RelativeOffsetOfHeader & 0xff00) >> 8);
            buffer[count++] = (byte) ((this._RelativeOffsetOfHeader & 0xff0000) >> 0x10);
            buffer[count++] = (byte) ((this._RelativeOffsetOfHeader & 0xff000000L) >> 0x18);
            if (this._Debug)
            {
                Console.WriteLine("\ninserting filename into CDS: (length= {0})", this.Header.Length - 30);
            }
            index = 0;
            while (index < (this.Header.Length - 30))
            {
                buffer[count + index] = this.Header[30 + index];
                if (this._Debug)
                {
                    Console.Write(" {0:X2}", buffer[count + index]);
                }
                index++;
            }
            if (this._Debug)
            {
                Console.WriteLine();
            }
            count += index;
            if (length != 0)
            {
                char[] chArray = this.Comment.ToCharArray();
                index = 0;
                while ((index < length) && ((count + index) < buffer.Length))
                {
                    buffer[count + index] = BitConverter.GetBytes(chArray[index])[0];
                    index++;
                }
                count += index;
            }
            s.Write(buffer, 0, count);
        }

        private void WriteHeader(Stream s, byte[] bytes)
        {
            int num = 0;
            bytes[num++] = 80;
            bytes[num++] = 0x4b;
            bytes[num++] = 3;
            bytes[num++] = 4;
            short num2 = 20;
            bytes[num++] = (byte) (num2 & 0xff);
            bytes[num++] = (byte) ((num2 & 0xff00) >> 8);
            short num3 = 0;
            bytes[num++] = (byte) (num3 & 0xff);
            bytes[num++] = (byte) ((num3 & 0xff00) >> 8);
            short num4 = 0;
            if (!this.IsDirectory)
            {
                num4 = 8;
                if (this._FileData == null)
                {
                    FileInfo info = new FileInfo(this.LocalFileName);
                    if (info.Length == 0L)
                    {
                        num4 = 0;
                        this._UncompressedSize = 0;
                        this._CompressedSize = 0;
                        this._Crc32 = 0;
                    }
                    else
                    {
                        Stream stream;
                        uint num5;
                        CRC32 crc = new CRC32();
                        using (stream = File.OpenRead(this.LocalFileName))
                        {
                            num5 = crc.GetCrc32AndCopy(stream, this.CompressedStream);
                            this._Crc32 = (int) num5;
                        }
                        this.CompressedStream.Close();
                        this._CompressedStream = null;
                        this._UncompressedSize = crc.TotalBytesRead;
                        this._CompressedSize = (int) this._UnderlyingMemoryStream.Length;
                        if (this._CompressedSize > this._UncompressedSize)
                        {
                            using (stream = File.OpenRead(this.LocalFileName))
                            {
                                this._UnderlyingMemoryStream = new MemoryStream();
                                num5 = crc.GetCrc32AndCopy(stream, this._UnderlyingMemoryStream);
                                this._Crc32 = (int) num5;
                            }
                            this._UncompressedSize = crc.TotalBytesRead;
                            this._CompressedSize = (int) this._UnderlyingMemoryStream.Length;
                            if (this._CompressedSize != this._UncompressedSize)
                            {
                                throw new Exception("No compression but unequal stream lengths!");
                            }
                            num4 = 0;
                        }
                    }
                }
            }
            bytes[num++] = (byte) (num4 & 0xff);
            bytes[num++] = (byte) ((num4 & 0xff00) >> 8);
            bytes[num++] = (byte) (this._LastModDateTime & 0xff);
            bytes[num++] = (byte) ((this._LastModDateTime & 0xff00) >> 8);
            bytes[num++] = (byte) ((this._LastModDateTime & 0xff0000) >> 0x10);
            bytes[num++] = (byte) ((this._LastModDateTime & 0xff000000L) >> 0x18);
            bytes[num++] = (byte) (this._Crc32 & 0xff);
            bytes[num++] = (byte) ((this._Crc32 & 0xff00) >> 8);
            bytes[num++] = (byte) ((this._Crc32 & 0xff0000) >> 0x10);
            bytes[num++] = (byte) ((this._Crc32 & 0xff000000L) >> 0x18);
            bytes[num++] = (byte) (this._CompressedSize & 0xff);
            bytes[num++] = (byte) ((this._CompressedSize & 0xff00) >> 8);
            bytes[num++] = (byte) ((this._CompressedSize & 0xff0000) >> 0x10);
            bytes[num++] = (byte) ((this._CompressedSize & 0xff000000L) >> 0x18);
            if (this._Debug)
            {
                Console.WriteLine("Uncompressed Size: {0}", this._UncompressedSize);
            }
            bytes[num++] = (byte) (this._UncompressedSize & 0xff);
            bytes[num++] = (byte) ((this._UncompressedSize & 0xff00) >> 8);
            bytes[num++] = (byte) ((this._UncompressedSize & 0xff0000) >> 0x10);
            bytes[num++] = (byte) ((this._UncompressedSize & 0xff000000L) >> 0x18);
            short length = (short) this.FileName.Length;
            if ((this.TrimVolumeFromFullyQualifiedPaths && (this.FileName[1] == ':')) && (this.FileName[2] == '\\'))
            {
                length = (short) (length - 3);
            }
            if ((length + num) > bytes.Length)
            {
                length = (short) (bytes.Length - ((short) num));
            }
            bytes[num++] = (byte) (length & 0xff);
            bytes[num++] = (byte) ((length & 0xff00) >> 8);
            short num7 = 0;
            bytes[num++] = (byte) (num7 & 0xff);
            bytes[num++] = (byte) ((num7 & 0xff00) >> 8);
            char[] chArray = ((this.TrimVolumeFromFullyQualifiedPaths && (this.FileName[1] == ':')) && (this.FileName[2] == '\\')) ? this.FileName.Substring(3).Replace(@"\", "/").ToCharArray() : this.FileName.Replace(@"\", "/").ToCharArray();
            int index = 0;
            if (this._Debug)
            {
                Console.WriteLine("local header: writing filename, {0} chars", chArray.Length);
                Console.WriteLine("starting offset={0}", num);
            }
            index = 0;
            while ((index < chArray.Length) && ((num + index) < bytes.Length))
            {
                bytes[num + index] = BitConverter.GetBytes(chArray[index])[0];
                if (this._Debug)
                {
                    Console.Write(" {0:X2}", bytes[num + index]);
                }
                index++;
            }
            if (this._Debug)
            {
                Console.WriteLine();
            }
            num += index;
            this._RelativeOffsetOfHeader = (int) s.Length;
            if (this._Debug)
            {
                Console.WriteLine("\nAll header data:");
                for (index = 0; index < num; index++)
                {
                    Console.Write(" {0:X2}", bytes[index]);
                }
                Console.WriteLine();
            }
            s.Write(bytes, 0, num);
            this._header = new byte[num];
            if (this._Debug)
            {
                Console.WriteLine("preserving header of {0} bytes", this._header.Length);
            }
            for (index = 0; index < num; index++)
            {
                this._header[index] = bytes[index];
            }
        }

        private byte[] _FileData
        {
            get
            {
                if (this.__filedata == null)
                {
                }
                return this.__filedata;
            }
        }

        public short BitField
        {
            get
            {
                return this._BitField;
            }
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
            }
        }

        public int CompressedSize
        {
            get
            {
                return this._CompressedSize;
            }
        }

        private DeflateStream CompressedStream
        {
            get
            {
                if (this._CompressedStream == null)
                {
                    this._UnderlyingMemoryStream = new MemoryStream();
                    bool leaveOpen = true;
                    this._CompressedStream = new DeflateStream(this._UnderlyingMemoryStream, CompressionMode.Compress, leaveOpen);
                }
                return this._CompressedStream;
            }
        }

        public short CompressionMethod
        {
            get
            {
                return this._CompressionMethod;
            }
        }

        public double CompressionRatio
        {
            get
            {
                return (100.0 * (1.0 - ((1.0 * this.CompressedSize) / (1.0 * this.UncompressedSize))));
            }
        }

        public string FileName
        {
            get
            {
                return this._FileNameInArchive;
            }
        }

        internal byte[] Header
        {
            get
            {
                return this._header;
            }
        }

        public bool IsDirectory
        {
            get
            {
                return this._IsDirectory;
            }
        }

        public DateTime LastModified
        {
            get
            {
                return this._LastModified;
            }
        }

        public string LocalFileName
        {
            get
            {
                return this._LocalFileName;
            }
        }

        public bool OverwriteOnExtract
        {
            get
            {
                return this._OverwriteOnExtract;
            }
            set
            {
                this._OverwriteOnExtract = value;
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

        public int UncompressedSize
        {
            get
            {
                return this._UncompressedSize;
            }
        }

        public short VersionNeeded
        {
            get
            {
                return this._VersionNeeded;
            }
        }
    }
}

