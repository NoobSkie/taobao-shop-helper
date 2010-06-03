using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace J.SkyMusic.Facade
{
    public class ResFileFacade
    {
        private delegate bool CheckFileValidate(FileInfo file);

        private readonly string _root;
        public ResFileFacade(string baseDir)
        {
            _root = baseDir;
        }

        public IList<ResFileInfo> GetImageFileList(params string[] allowTypeList)
        {
            List<ResFileInfo> list = new List<ResFileInfo>();
            string path = Path.Combine(_root, "Imgs");
            return GetFileList(path, ResFileType.ImageFile
                , (fileInfo) =>
                {
                    return allowTypeList.Contains(fileInfo.Extension, StringComparer.OrdinalIgnoreCase);
                });
        }

        public IList<ResFileInfo> GetScriptFileList()
        {
            List<ResFileInfo> list = new List<ResFileInfo>();
            string path = Path.Combine(_root, "Scripts");
            return GetFileList(path, ResFileType.JsScriptFile
                , (fileInfo) =>
                {
                    return fileInfo.Extension.Equals("js", StringComparison.OrdinalIgnoreCase);
                });
        }

        public IList<ResFileInfo> GetStyleFileList(string[] allowTypeList)
        {
            List<ResFileInfo> list = new List<ResFileInfo>();
            string path = Path.Combine(_root, "Styles");
            return GetFileList(path, ResFileType.StyleFile
                , (fileInfo) =>
                {
                    return fileInfo.Extension.Equals("css", StringComparison.OrdinalIgnoreCase);
                });
        }

        private IList<ResFileInfo> GetFileList(string path, ResFileType type, CheckFileValidate checkMethod)
        {
            List<ResFileInfo> list = new List<ResFileInfo>();
            DirectoryInfo dir = new DirectoryInfo(path);
            if (dir.Exists)
            {
                foreach (FileInfo file in dir.GetFiles())
                {
                    if (checkMethod(file))
                    {
                        ResFileInfo resFile = new ResFileInfo();
                        resFile.FileName = file.Name;
                        resFile.Extension = file.Extension;
                        resFile.Type = type;
                        resFile.CreateTime = file.CreationTime;
                        resFile.UpdateTime = file.LastWriteTime;
                        resFile.Size = CountSize(file.Length);
                        list.Add(resFile);
                    }
                }
            }
            return list;
        }

        private string CountSize(long Size)
        {
            string m_strSize = "";
            long FactSize = 0;
            FactSize = Size;
            if (FactSize < 1024.00)
                m_strSize = FactSize.ToString("F2") + " Byte";
            else if (FactSize >= 1024.00 && FactSize < 1048576)
                m_strSize = (FactSize / 1024.00).ToString("F2") + " K";
            else if (FactSize >= 1048576 && FactSize < 1073741824)
                m_strSize = (FactSize / 1024.00 / 1024.00).ToString("F2") + " M";
            else if (FactSize >= 1073741824)
                m_strSize = (FactSize / 1024.00 / 1024.00 / 1024.00).ToString("F2") + " G";
            return m_strSize;
        }

    }
}
