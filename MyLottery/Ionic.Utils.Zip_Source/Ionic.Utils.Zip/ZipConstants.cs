namespace Ionic.Utils.Zip
{
    using System;

    internal class ZipConstants
    {
        public const uint EndOfCentralDirectorySignature = 0x6054b50;
        public const int ZipDirEntrySignature = 0x2014b50;
        public const int ZipEntryDataDescriptorSignature = 0x8074b50;
        public const int ZipEntrySignature = 0x4034b50;
    }
}

