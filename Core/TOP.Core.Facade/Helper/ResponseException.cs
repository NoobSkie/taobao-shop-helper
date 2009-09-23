using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Reflection;
using System.IO;
using System.Configuration;

namespace TOP.Core.Facade
{
    public class ResponseException : Exception
    {
        private string errorXml = string.Empty;
        public string ErrorXml
        {
            get
            {
                return errorXml;
            }
        }

        private string errorCode = string.Empty;
        public string ErrorCode
        {
            get
            {
                return errorCode;
            }
        }

        private string errorMessageEn = string.Empty;
        public string ErrorMessageEn
        {
            get
            {
                return errorMessageEn;
            }
        }

        private string errorMessageCh = string.Empty;
        public string ErrorMessageCh
        {
            get
            {
                return errorMessageCh;
            }
        }

        private string errorDescription = string.Empty;
        public string ErrorDescription
        {
            get
            {
                return errorDescription;
            }
        }

        private ResponseErrorType errorType = ResponseErrorType.Unkown;
        public ResponseErrorType ErrorType
        {
            get
            {
                return errorType;
            }
        }

        private List<Arg> argList = new List<Arg>();
        public List<Arg> ArgList
        {
            get
            {
                return argList;
            }
        }

        public string ToArgListString()
        {
            string rtn = string.Empty;
            foreach (Arg arg in ArgList)
            {
                rtn += arg.Name + ": " + arg.Value + "\n";
            }
            return rtn;
        }

        public ResponseException(string xml)
            : base()
        {
            SetXml(xml);
        }

        public ResponseException(string xml, string msg)
            : base(msg)
        {
            SetXml(xml);
        }

        private void SetXml(string xml)
        {
            errorXml = xml;

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(errorXml);
            SaveXmlLog(doc);
            
            XmlElement element = doc.DocumentElement;

            foreach (XmlNode node in element.ChildNodes)
            {
                switch (node.Name.ToLower())
                {
                    case "args":
                        foreach (XmlNode sub in node.ChildNodes)
                        {
                            if (sub.Name.Equals("arg", StringComparison.OrdinalIgnoreCase))
                            {
                                Arg arg = new Arg();
                                arg.Name = sub.Attributes["name"].Value;
                                arg.Value = sub.InnerText;
                                argList.Add(arg);
                            }
                        }
                        break;
                    case "code":
                        errorCode = node.InnerText;
                        GetMessage(errorCode);
                        break;
                    case "msg":
                        errorDescription = node.InnerText;
                        break;
                }
            }
        }

        private void SaveXmlLog(XmlDocument doc)
        {
            DateTime now = DateTime.Now;
            string path = ConfigurationManager.AppSettings["ErrorResponseLogPath"];
            path += "\\" + now.ToString("yyyy") + "\\" + now.ToString("MM") + "\\" + now.ToString("dd");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }            
            string filePath = path + "\\" + now.ToString("HH.mm.ss.fffff") + ".xml";
            using (XmlTextWriter writer = new XmlTextWriter(filePath, Encoding.UTF8))
            {
                doc.Save(writer);
                writer.Flush();
                writer.Close();
            }
        }

        private void GetMessage(string code)
        {
            Assembly assem = Assembly.GetExecutingAssembly();

            using (Stream stream = assem.GetManifestResourceStream("TOP.Core.Facade.ErrorMessage.xml"))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(stream);

                XmlElement element = doc.DocumentElement;
                foreach (XmlNode node in element.ChildNodes)
                {
                    if (node.Name.Equals("error", StringComparison.OrdinalIgnoreCase))
                    {
                        XmlAttribute attrCode = node.Attributes["code"];
                        if (attrCode != null)
                        {
                            if (attrCode.Value == code)
                            {
                                XmlAttribute attrType = node.Attributes["type"];
                                XmlAttribute attrMsgEn = node.Attributes["description"];
                                XmlAttribute attrMsgCh = node.Attributes["message"];
                                if (attrType != null)
                                {
                                    if (attrType.Value.Equals("system", StringComparison.OrdinalIgnoreCase))
                                    {
                                        errorType = ResponseErrorType.System;
                                    }
                                    else if (attrType.Value.Equals("business", StringComparison.OrdinalIgnoreCase))
                                    {
                                        errorType = ResponseErrorType.Business;
                                    }
                                }
                                if (attrMsgEn != null)
                                {
                                    errorMessageEn = attrMsgEn.Value;
                                }
                                if (attrMsgCh != null)
                                {
                                    errorMessageCh = attrMsgCh.Value;
                                }
                                break;
                            }
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// 请求TOP服务器错误类型
    /// </summary>
    public enum ResponseErrorType
    {
        /// <summary>
        /// 未知
        /// </summary>
        Unkown = 0,
        /// <summary>
        /// 系统级错误
        /// </summary>
        System = 1,
        /// <summary>
        /// 业务级错误
        /// </summary>
        Business = 2,
    }
}
