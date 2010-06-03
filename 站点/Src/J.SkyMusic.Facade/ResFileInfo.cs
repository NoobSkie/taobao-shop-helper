using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace J.SkyMusic.Facade
{
    internal enum ResFileType
    {
        ImageFile = 0,
        JsScriptFile = 1,
        StyleFile = 2,
    }

    public class ResFileInfo
    {
        public string FileName { get; set; }

        public string Extension { get; set; }

        internal ResFileType Type { get; set; }

        public string IcoName
        {
            get
            {
                switch (Type)
                {
                    case ResFileType.ImageFile:
                        return "";
                    case ResFileType.JsScriptFile:
                        return "";
                    case ResFileType.StyleFile:
                        return "";
                }
                return "unkown.jpg";
            }
        }

        public string TypeName
        {
            get
            {
                switch (Type)
                {
                    case ResFileType.ImageFile:
                        return "图片文件";
                    case ResFileType.JsScriptFile:
                        return "脚本文件";
                    case ResFileType.StyleFile:
                        return "样式表文件";
                }
                return "未知";
            }
        }

        public DateTime CreateTime { get; set; }

        public DateTime UpdateTime { get; set; }

        public string Size { get; set; }
    }
}
