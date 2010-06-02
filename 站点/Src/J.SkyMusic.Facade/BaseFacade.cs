using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using J.SLS.Database.ORM;
using J.SLS.Database.DBAccess;
using J.SLS.Database.Configuration;
using J.SLS.Common.Logs;
using J.SLS.Common.Exceptions;
using System.IO;
using System.Xml;

namespace J.SkyMusic.Facade
{
    public abstract class BaseFacade
    {
        private readonly string _DbDirectory;
        private object lockObject = new object();
        public BaseFacade(string baseXmlDir)
        {
            _DbDirectory = baseXmlDir;
        }

        [ThreadStatic]
        protected static ILogWriter _logWriter;
        protected ILogWriter LogWriter
        {
            get
            {
                if (_logWriter == null)
                {
                    _logWriter = LogWriterGetter.GetLogWriter();
                }
                return _logWriter;
            }
        }

        protected FacadeException HandleException(string category, string source, string errMsg, Exception innerException)
        {
            FacadeException ex = new FacadeException(errMsg, innerException);
            if (LogWriter != null)
            {
                LogWriter.Write(category, source, ex);
            }
            return ex;
        }

        protected FacadeException HandleException(string category, string errMsg, Exception innerException)
        {
            FacadeException ex = new FacadeException(errMsg, innerException);
            if (LogWriter != null)
            {
                LogWriter.Write(category, category, ex);
            }
            return ex;
        }

        protected string DbListItemFile
        {
            get
            {
                return GetXmlFileName("DB_ListItem.xml");
            }
        }

        protected string DbMenuItemFile
        {
            get
            {
                return GetXmlFileName("DB_MenuItem.xml");
            }
        }

        protected string DbParamsFile
        {
            get
            {
                return GetXmlFileName("DB_Parameters.xml");
            }
        }

        protected string GetXmlFileName(string fileName)
        {
            return Path.Combine(_DbDirectory, fileName);
        }

        protected XmlDocument GetXmlDocumentByFileName(string fileName)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(GetFileContent(fileName));
            return doc;
        }

        protected void SaveXmlDocument(XmlDocument doc, string fileName)
        {
            lock (lockObject)
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    doc.Save(writer);
                    writer.Flush();
                }
            }
        }

        protected string GetFileContent(string fileName)
        {
            lock (lockObject)
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
