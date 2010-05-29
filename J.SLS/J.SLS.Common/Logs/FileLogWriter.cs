using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using J.SLS.Common.Exceptions;

namespace J.SLS.Common.Logs
{
    public class FileLogWriter : ILogWriter
    {
        public FileLogWriter() : this("yyyy-MM-dd") { }

        public FileLogWriter(string fileNameDateFormart)
        {
            FileNameDateFormart = fileNameDateFormart;
        }

        public string FileNameDateFormart { get; set; }

        private string CreateFileName()
        {
            // Logs\2010\05\2010-05-23.log
            string dir = string.Format(@"{0}\{1}\{2}\{3}"
                , "Logs"
                , DateTime.Today.Year.ToString().PadLeft(4, '0')
                , DateTime.Today.Month.ToString().PadLeft(2, '0')
                , DateTime.Today.ToString(FileNameDateFormart) + ".log");
            return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dir);
        }

        private void AppendTextToFile(string text)
        {
            string fileName = CreateFileName();
            try
            {
                string path = Path.GetDirectoryName(fileName);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                using (StreamWriter sw = System.IO.File.AppendText(fileName))
                {
                    sw.WriteLine(text);
                }
            }
            catch (IOException ex)
            {
                throw new LogException("写文件日志失败 - 文件或文件夹访问失败：" + fileName, ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new LogException("写文件日志失败 - 当前用户没有足够权限写日志文件：" + fileName, ex);
            }
            catch (Exception ex)
            {
                throw new LogException("写文件日志失败 - 未知错误：" + fileName, ex);
            }
        }

        public void Write(string category, string source, LogType logType, string logMsg, string detail)
        {
            AppendTextToFile(LogHelper.GetLogMessage(category, source, logType, logMsg, detail));
        }

        public void Write(string category, string source, Exception exception)
        {
            AppendTextToFile(LogHelper.GetLogMessage(category, source, exception));
        }
    }
}
