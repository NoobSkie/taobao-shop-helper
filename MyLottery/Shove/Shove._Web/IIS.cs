namespace Shove._Web
{
    using Shove;
    using System;
    using System.Collections;
    using System.DirectoryServices;
    using System.Runtime.InteropServices;
    using System.Text.RegularExpressions;

    public class IIS
    {
        private string hostName = "localhost";
        private string userName;
        private string password;

        public void AddHostHeader(long SiteNum, string IPAddress, string Port, string Url)
        {
            if (SiteNum < 0L)
            {
                throw new Exception("IIS 站点号“" + SiteNum.ToString() + "”打开失败。");
            }
            string entryPath = string.Format("IIS://{0}/w3svc/{1}", this.HostName, SiteNum);
            DirectoryEntry directoryEntry = this.GetDirectoryEntry(entryPath);
            if (directoryEntry == null)
            {
                throw new Exception("IIS 站点号“" + SiteNum.ToString() + "”打开失败。");
            }
            PropertyValueCollection values = directoryEntry.Properties["ServerBindings"];
            string str2 = string.Format("{0}:{1}:{2}", IPAddress, Port, Url);
            if (!values.Contains(str2))
            {
                values.Add(str2);
                directoryEntry.CommitChanges();
            }
        }

        public void AddHostHeader(string SiteName, string IPAddress, string Port, string Url)
        {
            this.AddHostHeader(this.GetWebSiteNum(SiteName), IPAddress, Port, Url);
        }

        public void CreateApplicationPool(string PoolName, int PeriodicRestartTime)
        {
            DirectoryEntry entry = new DirectoryEntry("IIS://localhost/W3SVC/AppPools");
            DirectoryEntry entry2 = entry.Children.Add(PoolName, "IISApplicationPool");
            entry2.Properties["PeriodicRestartTime"][0] = PeriodicRestartTime;
            entry2.CommitChanges();
        }

        public void CreateWebSite(SiteInfo siteInfo)
        {
            if (!this.EnsureNewSiteEnavaible(siteInfo.BindString))
            {
                throw new Exception("站点已经存在。" + Environment.NewLine + siteInfo.BindString);
            }
            string entryPath = string.Format("IIS://{0}/w3svc", this.HostName);
            DirectoryEntry directoryEntry = this.GetDirectoryEntry(entryPath);
            if (directoryEntry == null)
            {
                throw new Exception("IIS 目录打开失败。");
            }
            long newWebSiteID = this.GetNewWebSiteID();
            DirectoryEntry entry2 = directoryEntry.Children.Add(newWebSiteID.ToString(), "IIsWebServer");
            entry2.CommitChanges();
            entry2.Properties["ServerBindings"].Value = siteInfo.BindString;
            entry2.Properties["ServerComment"].Value = siteInfo.CommentOfWebSite;
            entry2.CommitChanges();
            DirectoryEntry entry3 = entry2.Children.Add("root", "IIsWebVirtualDir");
            entry3.CommitChanges();
            entry3.Properties["Path"].Value = siteInfo.WebPath;
            entry3.CommitChanges();
        }

        public void DeleteHostHeader(long SiteNum, string IPAddress, string Port, string Url)
        {
            if (SiteNum < 0L)
            {
                throw new Exception("IIS 站点号“" + SiteNum.ToString() + "”打开失败。");
            }
            string entryPath = string.Format("IIS://{0}/w3svc/{1}", this.HostName, SiteNum);
            DirectoryEntry directoryEntry = this.GetDirectoryEntry(entryPath);
            if (directoryEntry == null)
            {
                throw new Exception("IIS 站点号“" + SiteNum.ToString() + "”打开失败。");
            }
            PropertyValueCollection values = directoryEntry.Properties["ServerBindings"];
            string str2 = string.Format("{0}:{1}:{2}", IPAddress, Port, Url);
            if (values.Contains(str2))
            {
                values.Remove(str2);
                directoryEntry.CommitChanges();
            }
        }

        public void DeleteHostHeader(string SiteName, string IPAddress, string Port, string Url)
        {
            this.DeleteHostHeader(this.GetWebSiteNum(SiteName), IPAddress, Port, Url);
        }

        public void DeleteWebSiteByName(string SiteName)
        {
            long webSiteNum = this.GetWebSiteNum(SiteName);
            if (webSiteNum < 0L)
            {
                throw new Exception("IIS 站点“" + SiteName + "”打开失败。");
            }
            string entryPath = string.Format("IIS://{0}/w3svc/{1}", this.HostName, webSiteNum);
            DirectoryEntry directoryEntry = this.GetDirectoryEntry(entryPath);
            if (directoryEntry == null)
            {
                throw new Exception("IIS 站点“" + SiteName + "”打开失败。");
            }
            string str2 = string.Format("IIS://{0}/w3svc", this.HostName);
            DirectoryEntry entry2 = this.GetDirectoryEntry(str2);
            if (entry2 == null)
            {
                throw new Exception("IIS 目录打开失败。");
            }
            entry2.Children.Remove(directoryEntry);
            entry2.CommitChanges();
        }

        public bool EnsureNewSiteEnavaible(string bindStr)
        {
            string entryPath = string.Format("IIS://{0}/w3svc", this.HostName);
            DirectoryEntry directoryEntry = this.GetDirectoryEntry(entryPath);
            if (directoryEntry == null)
            {
                throw new Exception("IIS 目录打开失败。");
            }
            foreach (DirectoryEntry entry2 in directoryEntry.Children)
            {
                if (((entry2.SchemaClassName == "IIsWebServer") && (entry2.Properties["ServerBindings"].Value != null)) && (entry2.Properties["ServerBindings"].Value.ToString() == bindStr))
                {
                    return false;
                }
            }
            return true;
        }

        public string[] GetApplicationPools()
        {
            DirectoryEntry entry = new DirectoryEntry("IIS://localhost/W3SVC/AppPools");
            DirectoryEntries children = entry.Children;
            ArrayList list = new ArrayList();
            foreach (DirectoryEntry entry2 in children)
            {
                list.Add(entry2.Name);
            }
            if (list.Count < 1)
            {
                return null;
            }
            string[] strArray = new string[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                strArray[i] = list[i].ToString();
            }
            return strArray;
        }

        public DirectoryEntry GetDirectoryEntry(string EntryPath)
        {
            if (string.IsNullOrEmpty(this.UserName))
            {
                return new DirectoryEntry(EntryPath);
            }
            return new DirectoryEntry(EntryPath, this.UserName, this.Password, AuthenticationTypes.Secure);
        }

        public long GetNewWebSiteID()
        {
            ArrayList list = new ArrayList();
            string entryPath = string.Format("IIS://{0}/w3svc", this.HostName);
            DirectoryEntry directoryEntry = this.GetDirectoryEntry(entryPath);
            if (directoryEntry == null)
            {
                throw new Exception("IIS 目录打开失败。");
            }
            foreach (DirectoryEntry entry2 in directoryEntry.Children)
            {
                if (entry2.SchemaClassName == "IIsWebServer")
                {
                    string str = entry2.Name.ToString();
                    list.Add(Convert.ToInt32(str));
                }
            }
            list.Sort();
            long num = 1L;
            foreach (long num2 in list)
            {
                if (num == num2)
                {
                    num += 1L;
                }
            }
            return num;
        }

        public long GetWebSiteNum(string SiteName)
        {
            Regex regex = new Regex(SiteName);
            string entryPath = string.Format("IIS://{0}/w3svc", this.HostName);
            foreach (DirectoryEntry entry2 in this.GetDirectoryEntry(entryPath).Children)
            {
                if (entry2.SchemaClassName == "IIsWebServer")
                {
                    string str;
                    if (entry2.Properties["ServerBindings"].Value != null)
                    {
                        str = entry2.Properties["ServerBindings"].Value.ToString();
                        if (regex.Match(str).Success)
                        {
                            return _Convert.StrToLong(entry2.Name, -1L);
                        }
                    }
                    if (entry2.Properties["ServerComment"].Value != null)
                    {
                        str = entry2.Properties["ServerComment"].Value.ToString();
                        if (regex.Match(str).Success)
                        {
                            return _Convert.StrToLong(entry2.Name, -2L);
                        }
                    }
                }
            }
            return -3L;
        }

        public void RemoteConfig(string hostName, string userName, string password)
        {
            this.HostName = hostName;
            this.UserName = userName;
            this.Password = password;
        }

        public void RestartApplicationPool(string applicationPoolName, ApplicationPoolOperateType OperateType)
        {
            new DirectoryEntry("IIS://localhost/W3SVC/AppPools/" + applicationPoolName).Invoke(OperateType.ToString(), new object[0]);
        }

        public void StartWebSite(string SiteName)
        {
            long webSiteNum = this.GetWebSiteNum(SiteName);
            if (webSiteNum < 0L)
            {
                throw new Exception("IIS 站点“" + SiteName + "”打开失败。");
            }
            string entryPath = string.Format("IIS://{0}/w3svc/{1}", this.HostName, webSiteNum);
            DirectoryEntry directoryEntry = this.GetDirectoryEntry(entryPath);
            if (directoryEntry == null)
            {
                throw new Exception("IIS 站点“" + SiteName + "”打开失败。");
            }
            directoryEntry.Invoke("Start", new object[0]);
        }

        public void StopWebSite(string SiteName)
        {
            long webSiteNum = this.GetWebSiteNum(SiteName);
            if (webSiteNum < 0L)
            {
                throw new Exception("IIS 站点“" + SiteName + "”打开失败。");
            }
            string entryPath = string.Format("IIS://{0}/w3svc/{1}", this.HostName, webSiteNum);
            DirectoryEntry directoryEntry = this.GetDirectoryEntry(entryPath);
            if (directoryEntry == null)
            {
                throw new Exception("IIS 站点“" + SiteName + "”打开失败。");
            }
            directoryEntry.Invoke("Stop", new object[0]);
        }

        public string HostName
        {
            get
            {
                return this.hostName;
            }
            set
            {
                this.hostName = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                if (this.UserName.Length <= 1)
                {
                    throw new ArgumentException("还没有指定好用户名。请先指定用户名");
                }
                this.password = value;
            }
        }

        public string UserName
        {
            get
            {
                return this.userName;
            }
            set
            {
                this.userName = value;
            }
        }

        public enum ApplicationPoolOperateType
        {
            Start,
            Stop,
            Recycle
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SiteInfo
        {
            private string _HostIP;
            private string _PortNum;
            private string _DescOfWebSite;
            private string _CommentOfWebSite;
            private string _WebPath;
            public SiteInfo(string hostIP, string portNum, string descOfWebSite, string commentOfWebSite, string webPath)
            {
                this._HostIP = hostIP;
                this._PortNum = portNum;
                this._DescOfWebSite = descOfWebSite;
                this._CommentOfWebSite = commentOfWebSite;
                this._WebPath = webPath;
            }

            static SiteInfo()
            {
            }

            public string BindString
            {
                get
                {
                    return string.Format("{0}:{1}:{2}", this._HostIP, this._PortNum, this._DescOfWebSite);
                }
            }
            public string CommentOfWebSite
            {
                get
                {
                    return this._CommentOfWebSite;
                }
            }
            public string WebPath
            {
                get
                {
                    return this._WebPath;
                }
            }
        }
    }
}

