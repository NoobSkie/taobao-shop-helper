namespace Ionic.Utils.Zip
{
    using System;
    using System.IO;

    public class ZipDirEntry
    {
        private short _BitField;
        private string _Comment;
        private int _CompressedSize;
        private short _CompressionMethod;
        private int _Crc32;
        private int _ExternalFileAttrs;
        private byte[] _Extra;
        private string _FileName;
        private short _InternalFileAttrs;
        private int _LastModDateTime;
        private DateTime _LastModified;
        private int _UncompressedSize;
        private short _VersionMadeBy;
        private short _VersionNeeded;

        private ZipDirEntry()
        {
        }

        internal ZipDirEntry(ZipEntry ze)
        {
        }

        public static bool IsNotValidSig(int signature)
        {
            return (signature != 0x2014b50);
        }

        public static ZipDirEntry Read(Stream s)
        {
            ZipDirEntry entry;
            int signature = Shared.ReadSignature(s);
            if (IsNotValidSig(signature))
            {
                s.Seek(-4L, SeekOrigin.Current);
                if (signature != 0x6054b50L)
                {
                    throw new Exception(string.Format("  ZipDirEntry::Read(): Bad signature ({0:X8}) at position 0x{1:X8}", signature, s.Position));
                }
                return null;
            }
            byte[] buffer = new byte[0x2a];
            if (s.Read(buffer, 0, buffer.Length) != buffer.Length)
            {
                return null;
            }
            int num3 = 0;
            entry = new ZipDirEntry {
                _VersionMadeBy = (short) (buffer[num3++] + (buffer[num3++] * 0x100)),
                _VersionNeeded = (short) (buffer[num3++] + (buffer[num3++] * 0x100)),
                _BitField = (short) (buffer[num3++] + (buffer[num3++] * 0x100)),
                _CompressionMethod = (short) (buffer[num3++] + (buffer[num3++] * 0x100)),
                _LastModDateTime = ((buffer[num3++] + (buffer[num3++] * 0x100)) + ((buffer[num3++] * 0x100) * 0x100)) + (((buffer[num3++] * 0x100) * 0x100) * 0x100),
                _Crc32 = ((buffer[num3++] + (buffer[num3++] * 0x100)) + ((buffer[num3++] * 0x100) * 0x100)) + (((buffer[num3++] * 0x100) * 0x100) * 0x100),
                _CompressedSize = ((buffer[num3++] + (buffer[num3++] * 0x100)) + ((buffer[num3++] * 0x100) * 0x100)) + (((buffer[num3++] * 0x100) * 0x100) * 0x100),
                _UncompressedSize = ((buffer[num3++] + (buffer[num3++] * 0x100)) + ((buffer[num3++] * 0x100) * 0x100)) + (((buffer[num3++] * 0x100) * 0x100) * 0x100),
                _LastModified = Shared.PackedToDateTime(entry._LastModDateTime)
            };
            short num4 = (short) (buffer[num3++] + (buffer[num3++] * 0x100));
            short num5 = (short) (buffer[num3++] + (buffer[num3++] * 0x100));
            short num6 = (short) (buffer[num3++] + (buffer[num3++] * 0x100));
            short num7 = (short) (buffer[num3++] + (buffer[num3++] * 0x100));
            entry._InternalFileAttrs = (short) (buffer[num3++] + (buffer[num3++] * 0x100));
            entry._ExternalFileAttrs = ((buffer[num3++] + (buffer[num3++] * 0x100)) + ((buffer[num3++] * 0x100) * 0x100)) + (((buffer[num3++] * 0x100) * 0x100) * 0x100);
            int num8 = ((buffer[num3++] + (buffer[num3++] * 0x100)) + ((buffer[num3++] * 0x100) * 0x100)) + (((buffer[num3++] * 0x100) * 0x100) * 0x100);
            buffer = new byte[num4];
            int num2 = s.Read(buffer, 0, buffer.Length);
            entry._FileName = Shared.StringFromBuffer(buffer, 0, buffer.Length);
            if (num5 > 0)
            {
                entry._Extra = new byte[num5];
                num2 = s.Read(entry._Extra, 0, entry._Extra.Length);
            }
            if (num6 > 0)
            {
                buffer = new byte[num6];
                num2 = s.Read(buffer, 0, buffer.Length);
                entry._Comment = Shared.StringFromBuffer(buffer, 0, buffer.Length);
            }
            return entry;
        }

        public string Comment
        {
            get
            {
                return this._Comment;
            }
        }

        public int CompressedSize
        {
            get
            {
                return this._CompressedSize;
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
                return this._FileName;
            }
        }

        public bool IsDirectory
        {
            get
            {
                return ((this._InternalFileAttrs == 0) && ((this._ExternalFileAttrs & 0x10) == 0x10));
            }
        }

        public DateTime LastModified
        {
            get
            {
                return this._LastModified;
            }
        }

        public int UncompressedSize
        {
            get
            {
                return this._UncompressedSize;
            }
        }

        public short VersionMadeBy
        {
            get
            {
                return this._VersionMadeBy;
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

