using Shove._Net;
using System;
using System.Threading;
using Shove._IO;

namespace SLS.Site.App_Code
{
    public class SendEmailTask
    {
        private string Body;
        public string EmailServer_EmailServer = "";
        public string EmailServer_From = "";
        public string EmailServer_Password = "";
        public string EmailServer_User = "";
        private string MailTo;
        private Sites Site;
        private string Subject;
        private Thread thread;

        public SendEmailTask(Sites site, string mailto, string subject, string body)
        {
            this.Site = site;
            this.MailTo = mailto;
            this.Subject = subject;
            this.Body = body;
        }

        public void Do()
        {
            Thread.Sleep(0x7d0);
            int num = 0;
            int num2 = -1;
            while ((num2 < 0) && (num++ < 3))
            {
                num2 = Email.SendEmail(this.EmailServer_From, this.MailTo, this.Subject, this.Body, this.EmailServer_EmailServer, this.EmailServer_User, this.EmailServer_Password);
            }
            if (num2 < 0)
            {
                new Log("System").Write("Send Email: Send Mail fail. Tryed: " + num.ToString());
            }
            this.Stop();
        }

        public void Run()
        {
            if ((this.Site != null) && (this.Site.ID >= 1L))
            {
                if (((this.MailTo == "") || (this.Subject == "")) || (this.Body == ""))
                {
                    new Log("System").Write("Send Email: MailTo, Subject or Body parameters error.");
                }
                else
                {
                    this.EmailServer_From = this.Site.SiteOptions["Opt_EmailServer_From"].Value.ToString();
                    this.EmailServer_EmailServer = this.Site.SiteOptions["Opt_EmailServer_EmailServer"].Value.ToString();
                    this.EmailServer_User = this.Site.SiteOptions["Opt_EmailServer_UserName"].Value.ToString();
                    this.EmailServer_Password = this.Site.SiteOptions["Opt_EmailServer_Password"].Value.ToString();
                    if (((this.EmailServer_From == "") || (this.EmailServer_EmailServer == "")) || (this.EmailServer_User == ""))
                    {
                        new Log("System").Write("Send Email: Read EmailServer configure fail.");
                    }
                    else
                    {
                        lock (this)
                        {
                            this.thread = new Thread(new ThreadStart(this.Do));
                            this.thread.IsBackground = true;
                            this.thread.Start();
                        }
                    }
                }
            }
        }

        private void Stop()
        {
        }
    }
}
