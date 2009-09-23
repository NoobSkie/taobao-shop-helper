using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using mshtml;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing.Imaging;
using System.Net;

namespace TOP.Applications.PicWatermark
{
    public partial class frmGenPicFromHtml : Form
    {
        public frmGenPicFromHtml()
        {
            InitializeComponent();
        }

        private void btnGenPic_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://www.google.cn");
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                mshtml.IHTMLDocument2 myDoc = (mshtml.IHTMLDocument2)webBrowser1.Document.DomDocument;

                (myDoc as HTMLDocumentClass).documentElement.setAttribute("scroll", "yes", 0);

                int ctrlHeight = webBrowser1.Height;
                int ctrlWidth = webBrowser1.Width;

                //document完整高度
                int heightsize = (int)(myDoc as HTMLDocumentClass).documentElement.getAttribute("scrollHeight", 0);
                int widthsize = (int)(myDoc as HTMLDocumentClass).documentElement.getAttribute("scrollWidth", 0);

                ////Get Screen Height
                int screenHeight = (int)(myDoc as HTMLDocumentClass).documentElement.getAttribute("clientHeight", 0);
                int screenWidth = (int)(myDoc as HTMLDocumentClass).documentElement.getAttribute("clientWidth", 0);

                e.ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        private int currentHeight = 0;
        private void btnDown_Click(object sender, EventArgs e)
        {
            int times = GetPageImage(textBox1.Text, Directory.GetCurrentDirectory() + "\\snapshots");
            MessageBox.Show(times.ToString());
        }

        #region DLLImport
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr FindWindowEx(IntPtr parent /*HWND*/, IntPtr next /*HWND*/, string sClassName, IntPtr sWindowTitle);
        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        private static extern IntPtr GetWindow(IntPtr hWnd, int uCmd);
        [DllImport("user32.dll")]
        private static extern void GetClassName(int h, StringBuilder s, int nMaxCount);
        [DllImport("user32.dll")]
        private static extern bool PrintWindow(IntPtr hwnd, IntPtr hdcBlt, uint nFlags);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        public const int GW_CHILD = 5;
        public const int GW_HWNDNEXT = 2;

        #endregion

        public bool firstScreen = true;        //测试网络连通状况    
        private bool TestInternet(string url)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(new Uri(url));
            req.AllowAutoRedirect = true;
            req.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.0; SLCC1; .NET CLR 2.0.50727; .NET CLR 3.0.04506; .NET CLR 3.5.21022; .NET CLR 1.0.3705; .NET CLR 1.1.4322)";
            req.Referer = "http://www.google.com";
            req.ContentType = "text/html";
            req.AllowWriteStreamBuffering = true;
            req.AutomaticDecompression = DecompressionMethods.GZip;
            req.Method = "GET";
            req.Proxy = null;
            req.ReadWriteTimeout = 20;
            HttpStatusCode status;
            using (HttpWebResponse resp = (HttpWebResponse)req.GetResponse())
            {
                status = resp.StatusCode;
            }
            if (status == HttpStatusCode.OK || status == HttpStatusCode.Moved)
            {
                return true;
            }
            return false;
        }

        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }

        public int GetPageImage(string url, string path)
        {
            //Test Is OK       
            if (TestInternet(url))
            {
                bool flag = firstScreen;
                webBrowser1.Navigate(url);
                //浏览器Dom载入完毕          
                while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                }
                mshtml.IHTMLDocument2 myDoc = (mshtml.IHTMLDocument2)webBrowser1.Document.DomDocument;
                //处理由于webbrowser上、左边框阴影带来的拼接bug         
                int URLExtraHeight = 3;
                int URLExtraLeft = 3;
                (myDoc as HTMLDocumentClass).documentElement.setAttribute("scroll", "yes", 0);
                //document完整高度          
                int heightsize = (int)(myDoc as HTMLDocumentClass).documentElement.getAttribute("scrollHeight", 0);
                int widthsize = (int)(myDoc as HTMLDocumentClass).documentElement.getAttribute("scrollWidth", 0);
                ////Get Screen Height             
                int screenHeight = (int)(myDoc as HTMLDocumentClass).documentElement.getAttribute("clientHeight", 0);
                int screenWidth = (int)(myDoc as HTMLDocumentClass).documentElement.getAttribute("clientWidth", 0);
                IntPtr myIntptr = (IntPtr)webBrowser1.Handle;
                //寻找IE对象句柄          
                IntPtr wbHandle = FindWindowEx(myIntptr, IntPtr.Zero, "Shell Embedding", null);
                wbHandle = FindWindowEx(wbHandle, IntPtr.Zero, "Shell DocObject View", null);
                wbHandle = FindWindowEx(wbHandle, IntPtr.Zero, "Internet Explorer_Server", null);
                IntPtr hwnd = wbHandle;
                Bitmap bm = new Bitmap(screenWidth, screenHeight, System.Drawing.Imaging.PixelFormat.Format16bppRgb555);
                Bitmap bm2 = new Bitmap(widthsize, heightsize, System.Drawing.Imaging.PixelFormat.Format16bppRgb555);
                Graphics g = null;
                Graphics g2 = Graphics.FromImage(bm2);
                //切割用的临时对象         
                Bitmap tempbm = null;
                Graphics tempg = null;
                IntPtr hdc;
                Image screenfrag = null;
                Image firstScreenfrag = null;

                #region 拼接

                int brwTop = 0;
                int brwLeft = 0;
                int myPage = 0;
                //Get Screen Height (for bottom up screen drawing)         
                while ((myPage * screenHeight) < heightsize)
                {
                    (myDoc as HTMLDocumentClass).documentElement.setAttribute("scrollTop", (screenHeight - 5) * myPage, 0);
                    ++myPage;
                }
                //Rollback the page count by one       
                --myPage;
                int myPageWidth = 0;
                int times = 0;
                //screenWidth+ URLExtraLeft        
                while ((myPageWidth * screenWidth) < widthsize)
                {
                    (myDoc as HTMLDocumentClass).documentElement.setAttribute("scrollLeft", (screenWidth - 5) * myPageWidth, 0);
                    brwLeft = (int)(myDoc as HTMLDocumentClass).documentElement.getAttribute("scrollLeft", 0);
                    for (int i = myPage; i >= 0; --i)
                    {
                        times++;
                        //Shoot visible window         
                        g = Graphics.FromImage(bm);
                        hdc = g.GetHdc();
                        (myDoc as HTMLDocumentClass).documentElement.setAttribute("scrollTop", (screenHeight - 5) * i, 0);
                        brwTop = (int)(myDoc as HTMLDocumentClass).documentElement.getAttribute("scrollTop", 0);
                        PrintWindow(hwnd, hdc, 0);
                        g.ReleaseHdc(hdc);
                        g.Flush();
                        screenfrag = Image.FromHbitmap(bm.GetHbitmap());
                        //切除URLExtraLeft、URLExtraHeight长度的webbrowser带来的bug        
                        tempbm = new Bitmap(screenWidth - URLExtraLeft, screenHeight - URLExtraHeight, System.Drawing.Imaging.PixelFormat.Format16bppRgb555);
                        tempg = Graphics.FromImage(tempbm);
                        tempg.DrawImage(screenfrag, -URLExtraLeft, -URLExtraHeight);
                        //拼接到g2                     
                        g2.DrawImage(tempbm, brwLeft + URLExtraLeft, brwTop + URLExtraLeft);
                    }
                    //是否得到第一屏
                    if (flag)
                    {
                        firstScreenfrag = (Image)tempbm.Clone();
                        flag = false;
                    }
                    ++myPageWidth;
                }
                int finalWidth = (int)widthsize;
                int finalHeight = (int)heightsize;
                Bitmap finalImage = new Bitmap(finalWidth, finalHeight, System.Drawing.Imaging.PixelFormat.Format16bppRgb555);
                Graphics gFinal = Graphics.FromImage((Image)finalImage);
                gFinal.DrawImage(bm2, 0, 0, finalWidth, finalHeight);
                #endregion
                //Get Time Stamp       
                DateTime myTime = DateTime.Now;
                String format = "yyyy_MM_dd_hh_mm_ss";
                //Create Directory to save image to.          
                Directory.CreateDirectory(path);
                //Write Image.          
                EncoderParameters eps = new EncoderParameters(1);
                long myQuality = Convert.ToInt64(100);
                eps.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, myQuality);
                ImageCodecInfo ici = GetEncoderInfo("image/jpeg");
                //保存              
                finalImage.Save(path + @"\Img_" + myTime.ToString(format) + ".jpg", ici, eps);
                //保存第一屏             
                if (firstScreen)
                {
                    firstScreenfrag.Save(path + @"\Img_FirstScreen_" + myTime.ToString(format) + ".jpg", ici, eps);
                    firstScreenfrag.Dispose();
                }
                //Process.Start("explorer.exe", path);   
                #region Clean
                //Clean Up.         
                myDoc.close();
                myDoc = null;
                g.Dispose();
                g2.Dispose();
                gFinal.Dispose();
                bm.Dispose();
                bm2.Dispose();
                finalImage.Dispose();
                tempbm.Dispose();
                tempg.Dispose();

                #endregion
                return times;
            }
            return 0;
        }
    }
}
