namespace Shove._Web
{
    using Shove;
    using System;
    using System.Collections.Specialized;
    using System.IO;
    using System.Web.Configuration;
    using System.Xml;

    public sealed class WebConfig
    {
        public static bool GetAppSettingsBool(string Key)
        {
            return GetAppSettingsBool(Key, false);
        }

        public static bool GetAppSettingsBool(string Key, bool Default)
        {
            return _Convert.StrToBool(WebConfigurationManager.AppSettings.Get(Key), Default);
        }

        public static double GetAppSettingsDouble(string Key)
        {
            return GetAppSettingsDouble(Key, 0.0);
        }

        public static double GetAppSettingsDouble(string Key, double Defalut)
        {
            return _Convert.StrToDouble(WebConfigurationManager.AppSettings.Get(Key).Trim(), Defalut);
        }

        public static int GetAppSettingsInt(string Key)
        {
            return GetAppSettingsInt(Key, 0);
        }

        public static int GetAppSettingsInt(string Key, int Default)
        {
            return _Convert.StrToInt(WebConfigurationManager.AppSettings.Get(Key), Default);
        }

        public static string GetAppSettingsString(string Key)
        {
            string str = "";
            try
            {
                str = WebConfigurationManager.AppSettings.Get(Key).Trim();
            }
            catch
            {
            }
            return str;
        }

        public static decimal GetConfigDecimal(string SectionName, string Key)
        {
            decimal num = 0M;
            string configString = GetConfigString(SectionName, Key);
            if ((configString != null) && (string.Empty != configString))
            {
                num = decimal.Parse(configString);
            }
            return num;
        }

        public static int GetConfigInt(string SectionName, string Key)
        {
            int num = 0;
            string configString = GetConfigString(SectionName, Key);
            if ((configString != null) && (string.Empty != configString))
            {
                num = int.Parse(configString);
            }
            return num;
        }

        public static string GetConfigString(string SectionName, string Key)
        {
            if ((SectionName == null) || (SectionName == ""))
            {
                NameValueCollection appSettings = WebConfigurationManager.AppSettings;
                if ((appSettings[Key] == null) || (appSettings[Key] == ""))
                {
                    throw new Exception("在 Web.config 文件中未发现配置项: \"" + Key + "\"");
                }
                return appSettings[Key];
            }
            NameValueCollection section = (NameValueCollection) WebConfigurationManager.GetSection(SectionName);
            if ((section[Key] == null) || (section[Key] == ""))
            {
                throw new Exception("在 Web.config 文件中未发现配置项: \"" + Key + "\"");
            }
            return section[Key];
        }

        public static void RemoveSectionKey(string SectionName, string Key)
        {
            RemoveSectionKey(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, SectionName, Key);
        }

        public static void RemoveSectionKey(string ConfigFileName, string SectionName, string Key)
        {
            XmlDocument document = new XmlDocument();
            try
            {
                document.Load(ConfigFileName);
            }
            catch (FileNotFoundException exception)
            {
                throw new Exception("No configuration file found.", exception);
            }
            XmlNode node = document.SelectSingleNode("//" + SectionName);
            if (node == null)
            {
                throw new InvalidOperationException(SectionName + " section not found in config file.");
            }
            try
            {
                node.RemoveChild(node.SelectSingleNode(string.Format("//add[@key='{0}']", Key)));
                document.Save(ConfigFileName);
            }
            catch (NullReferenceException exception2)
            {
                throw new Exception(string.Format("The key {0} does not exist.", Key), exception2);
            }
        }

        public static void SetConfigKeyValue(string SectionName, string Key, string Value)
        {
            SetConfigKeyValue(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, SectionName, Key, Value);
        }

        public static void SetConfigKeyValue(string ConfigFileName, string SectionName, string Key, string Value)
        {
            XmlDocument document = new XmlDocument();
            try
            {
                document.Load(ConfigFileName);
            }
            catch (FileNotFoundException exception)
            {
                throw new Exception("No configuration file found.", exception);
            }
            XmlNode node = document.SelectSingleNode("//" + SectionName);
            if (node == null)
            {
                throw new InvalidOperationException(SectionName + " section not found in config file.");
            }
            try
            {
                XmlElement newChild = (XmlElement) node.SelectSingleNode(string.Format("//add[@key='{0}']", Key));
                if (newChild != null)
                {
                    newChild.SetAttribute("value", Value);
                }
                else
                {
                    newChild = document.CreateElement("add");
                    newChild.SetAttribute("key", Key);
                    newChild.SetAttribute("value", Value);
                    node.AppendChild(newChild);
                }
                document.Save(ConfigFileName);
            }
            catch
            {
                throw;
            }
        }
    }
}

