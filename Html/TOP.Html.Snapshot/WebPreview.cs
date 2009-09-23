using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;

namespace TOP.Html.Snapshot
{
    public class WebPreview
    {
        private int _timeout = 120 * 1000;//设置线程超时时长
        private string html = string.Empty;
        private string fileName = string.Empty;
        private string path = string.Empty;
        private string url = string.Empty;
        private bool isUrl = true;

        internal string GetWebPreview()
        {
            //Asp.Net引用Winform（类似ActiveX）控件，必须开单线程
            Thread t = new Thread(StaRun);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();

            if (!t.Join(_timeout))
            {
                t.Abort();
                throw new TimeoutException();
            }

            if (string.IsNullOrEmpty(fileName)) throw new ExecutionEngineException();

            return fileName;
        }

        public static string GetHtmlPreview(string html, string path)
        {
            WebPreview wp = new WebPreview();
            wp.html = html;
            wp.path = path;
            wp.isUrl = false;
            return wp.GetWebPreview();
        }

        public static string GetUrlPreview(string url, string path)
        {
            WebPreview wp = new WebPreview();
            wp.url = url;
            wp.path = path;
            wp.isUrl = true;
            return wp.GetWebPreview();
        }

        /// <summary>
        /// 为WebBrowser所开线程的启动入口函数，相当于Winform里面的Main()
        /// </summary>
        /// <param name="_wp"></param>
        private void StaRun()
        {
            try
            {
                HtmlPreview preview = new HtmlPreview();
                if (isUrl)
                {
                    fileName = preview.SavePageImageByUrl(url, path);
                }
                else
                {
                    fileName = preview.SavePageImageByHtml(html, path);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
