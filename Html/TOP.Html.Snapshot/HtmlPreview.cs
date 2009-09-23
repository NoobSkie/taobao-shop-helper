using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using okpower.Utility;
using mshtml;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.IO;

namespace TOP.Html.Snapshot
{
    public class HtmlPreview
    {
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

        public WebBrowser GetBrowser(string content, bool isUrl)
        {
            WebBrowser browser = new WebBrowser();
            browser.Size = new Size(750, 500);
            if (isUrl)
            {
                browser.Navigate(content);
            }
            else
            {
                browser.DocumentText = content;
            }
            while (browser.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }
            return browser;
        }

        public string SavePageImageByHtml(string html, string path)
        {
            WebBrowser browser = GetBrowser(html, false);
            return GetPageImage(browser, path);
        }

        public string SavePageImageByUrl(string url, string path)
        {
            WebBrowser browser = GetBrowser(url, true);
            return GetPageImage(browser, path);
        }

        public string GetPageImage(WebBrowser browser, string path)
        {
            WebSnapshot snapshot = new WebSnapshot();
            IHTMLDocument2 myDoc = (IHTMLDocument2)browser.Document.DomDocument;
            //处理由于webbrowser上、左边框阴影带来的拼接bug
            int URLExtraHeight = 3;
            int URLExtraLeft = 3;
            (myDoc as HTMLDocumentClass).documentElement.setAttribute("scroll", "yes", 0);
            //document完整高度
            int totalHeight = (int)(myDoc as HTMLDocumentClass).documentElement.getAttribute("scrollHeight", 0);
            int totalWidth = (int)(myDoc as HTMLDocumentClass).documentElement.getAttribute("scrollWidth", 0);
            ////Get Screen Height             
            int screenHeight = (int)(myDoc as HTMLDocumentClass).documentElement.getAttribute("clientHeight", 0);
            int screenWidth = (int)(myDoc as HTMLDocumentClass).documentElement.getAttribute("clientWidth", 0);

            Bitmap image = new Bitmap(totalWidth, totalHeight, System.Drawing.Imaging.PixelFormat.Format16bppRgb555);
            Graphics g = Graphics.FromImage(image);
            string savePath = string.Empty;
            int vNum = 0;
            int currentTop = vNum++ * (screenHeight - 5);
            while (currentTop < totalHeight)
            {
                (myDoc as HTMLDocumentClass).documentElement.setAttribute("scrollTop", currentTop, 0);
                int hNum = 0;
                int currentLeft = hNum++ * (screenWidth - 5);
                while (currentLeft < totalWidth)
                {
                    (myDoc as HTMLDocumentClass).documentElement.setAttribute("scrollLeft", currentLeft, 0);
                    int brwTop = (int)(myDoc as HTMLDocumentClass).documentElement.getAttribute("scrollTop", 0);
                    int brwLeft = (int)(myDoc as HTMLDocumentClass).documentElement.getAttribute("scrollLeft", 0);

                    int imgWidth, imgLeft;
                    if (brwLeft < currentLeft)
                    {
                        imgWidth = currentLeft - brwLeft;
                        imgLeft = currentLeft - imgWidth;
                    }
                    else
                    {
                        imgLeft = 0;
                        imgWidth = screenWidth;
                    }

                    int imgHeight, imgTop;
                    if (brwTop < currentTop)
                    {
                        imgHeight = currentTop - brwTop;
                        imgTop = currentTop - imgHeight;
                    }
                    else
                    {
                        imgTop = 0;
                        imgHeight = screenHeight;
                    }

                    Bitmap bmtmp = snapshot.TakeSnapshot(browser.ActiveXInstance, new Rectangle(3, 3, screenWidth, screenHeight));
                    g.DrawImage(bmtmp, new Point(brwLeft - hNum * 5, brwTop - vNum * 5));

                    // savePath = SaveImage(bmtmp, path);

                    currentLeft = hNum++ * (screenWidth - 5);
                }
                currentTop = vNum++ * (screenHeight - 5);
            }
            // Bitmap pic = snapshot.TakeSnapshot(browser.ActiveXInstance, new Rectangle(0, 0, totalWidth, totalHeight));
            return SaveImage(image, path);

            //bool flag = firstScreen;
            //mshtml.IHTMLDocument2 myDoc = (mshtml.IHTMLDocument2)browser.Document.DomDocument;
            ////处理由于webbrowser上、左边框阴影带来的拼接bug         
            //int URLExtraHeight = 3;
            //int URLExtraLeft = 3;
            //(myDoc as HTMLDocumentClass).documentElement.setAttribute("scroll", "yes", 0);
            ////document完整高度          
            //int heightsize = (int)(myDoc as HTMLDocumentClass).documentElement.getAttribute("scrollHeight", 0);
            //int widthsize = (int)(myDoc as HTMLDocumentClass).documentElement.getAttribute("scrollWidth", 0);
            //////Get Screen Height             
            //int screenHeight = (int)(myDoc as HTMLDocumentClass).documentElement.getAttribute("clientHeight", 0);
            //int screenWidth = (int)(myDoc as HTMLDocumentClass).documentElement.getAttribute("clientWidth", 0);
            //IntPtr myIntptr = (IntPtr)browser.Handle;
            ////寻找IE对象句柄          
            //IntPtr wbHandle = FindWindowEx(myIntptr, IntPtr.Zero, "Shell Embedding", null);
            //wbHandle = FindWindowEx(wbHandle, IntPtr.Zero, "Shell DocObject View", null);
            //wbHandle = FindWindowEx(wbHandle, IntPtr.Zero, "Internet Explorer_Server", null);
            //IntPtr hwnd = wbHandle;
            //Bitmap bm = new Bitmap(screenWidth, screenHeight, System.Drawing.Imaging.PixelFormat.Format16bppRgb555);
            //Bitmap bm2 = new Bitmap(widthsize, heightsize, System.Drawing.Imaging.PixelFormat.Format16bppRgb555);
            //Graphics g = null;
            //Graphics g2 = Graphics.FromImage(bm2);
            ////切割用的临时对象         
            //Bitmap tempbm = null;
            //Graphics tempg = null;
            //IntPtr hdc;
            //Image screenfrag = null;
            //Image firstScreenfrag = null;

            //#region 拼接

            //int brwTop = 0;
            //int brwLeft = 0;
            //int myPage = 0;
            ////Get Screen Height (for bottom up screen drawing)         
            //while ((myPage * screenHeight) < heightsize)
            //{
            //    (myDoc as HTMLDocumentClass).documentElement.setAttribute("scrollTop", (screenHeight - 5) * myPage, 0);
            //    ++myPage;
            //}
            ////Rollback the page count by one       
            //--myPage;
            //int myPageWidth = 0;
            ////screenWidth+ URLExtraLeft        
            //while ((myPageWidth * screenWidth) < widthsize)
            //{
            //    (myDoc as HTMLDocumentClass).documentElement.setAttribute("scrollLeft", (screenWidth - 5) * myPageWidth, 0);
            //    brwLeft = (int)(myDoc as HTMLDocumentClass).documentElement.getAttribute("scrollLeft", 0);
            //    for (int i = myPage; i >= 0; --i)
            //    {
            //        //Shoot visible window         
            //        g = Graphics.FromImage(bm);
            //        hdc = g.GetHdc();
            //        (myDoc as HTMLDocumentClass).documentElement.setAttribute("scrollTop", (screenHeight - 5) * i, 0);
            //        brwTop = (int)(myDoc as HTMLDocumentClass).documentElement.getAttribute("scrollTop", 0);
            //        PrintWindow(hwnd, hdc, 0);
            //        g.ReleaseHdc(hdc);
            //        g.Flush();
            //        screenfrag = Image.FromHbitmap(bm.GetHbitmap());
            //        //切除URLExtraLeft、URLExtraHeight长度的webbrowser带来的bug        
            //        tempbm = new Bitmap(screenWidth - URLExtraLeft, screenHeight - URLExtraHeight, System.Drawing.Imaging.PixelFormat.Format16bppRgb555);
            //        tempg = Graphics.FromImage(tempbm);
            //        tempg.DrawImage(screenfrag, -URLExtraLeft, -URLExtraHeight);
            //        //拼接到g2                     
            //        g2.DrawImage(tempbm, brwLeft + URLExtraLeft, brwTop + URLExtraLeft);
            //    }
            //    //是否得到第一屏
            //    if (flag)
            //    {
            //        firstScreenfrag = (Image)tempbm.Clone();
            //        flag = false;
            //    }
            //    ++myPageWidth;
            //}
            //int finalWidth = (int)widthsize;
            //int finalHeight = (int)heightsize;
            //Bitmap finalImage = new Bitmap(finalWidth, finalHeight, System.Drawing.Imaging.PixelFormat.Format16bppRgb555);
            //Graphics gFinal = Graphics.FromImage((Image)finalImage);
            //gFinal.DrawImage(bm2, 0, 0, finalWidth, finalHeight);

            //#endregion

            //string guid = Guid.NewGuid().ToString();
            ////Create Directory to save image to.          
            //Directory.CreateDirectory(path);
            ////Write Image.          
            //EncoderParameters eps = new EncoderParameters(1);
            //long myQuality = Convert.ToInt64(100);
            //eps.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, myQuality);
            //ImageCodecInfo ici = GetEncoderInfo("image/jpeg");
            ////保存              
            //finalImage.Save(path + @"\img_" + guid + ".jpg", ici, eps);
            ////保存第一屏             
            //if (firstScreen)
            //{
            //    firstScreenfrag.Save(path + @"\snapshot_" + guid + ".jpg", ici, eps);
            //    firstScreenfrag.Dispose();
            //}
            ////Process.Start("explorer.exe", path);   

            //#region Clean
            ////Clean Up.         
            //myDoc.close();
            //myDoc = null;
            //g.Dispose();
            //g2.Dispose();
            //gFinal.Dispose();
            //bm.Dispose();
            //bm2.Dispose();
            //finalImage.Dispose();
            //tempbm.Dispose();
            //tempg.Dispose();

            //#endregion
        }
        int index = 1;
        private string SaveImage(Bitmap pic, string path)
        {
            string guid = Guid.NewGuid().ToString();
            //Create Directory to save image to.          
            Directory.CreateDirectory(path);
            //Write Image.          
            EncoderParameters eps = new EncoderParameters(1);
            long myQuality = Convert.ToInt64(100);
            eps.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, myQuality);
            ImageCodecInfo ici = GetEncoderInfo("image/jpeg");
            //保存              
            pic.Save(path + @"\img_" + index++.ToString() + "_" + guid + ".jpg", ici, eps);
            return guid;
        }
    }
}
