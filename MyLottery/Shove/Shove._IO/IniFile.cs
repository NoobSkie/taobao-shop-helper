namespace Shove._IO
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;

    public class IniFile
    {
        public string FileName;

        public IniFile(string IniFileName)
        {
            this.FileName = IniFileName;
        }

        [DllImport("kernel32", EntryPoint = "WritePrivateProfileString")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32", EntryPoint = "GetPrivateProfileString")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        public string Read(string Section, string Key)
        {
            StringBuilder builder = new StringBuilder(0xff);
            GetPrivateProfileString(Section, Key, "", builder, 0xff, this.FileName);
            return builder.ToString();
        }

        public bool Write(string Section, string Key, object Value)
        {
            if (0L == WritePrivateProfileString(Section, Key, Value.ToString(), this.FileName))
            {
                return false;
            }
            return true;
        }
    }
}

