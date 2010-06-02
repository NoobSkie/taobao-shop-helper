using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace J.SkyMusic.Facade
{
    public class PageFacade
    {
        private readonly string _DbDirectory;
        private object lockObject = new object();
        public PageFacade(string baseXmlDir)
        {
            _DbDirectory = baseXmlDir;
        }

        private string DbListItemFile
        {
            get
            {
                return GetXmlFileName("DB_ListItem.xml");
            }
        }

        private string DbMenuItemFile
        {
            get
            {
                return GetXmlFileName("DB_MenuItem.xml");
            }
        }

        private string GetXmlFileName(string fileName)
        {
            return Path.Combine(_DbDirectory, fileName);
        }

        private XmlDocument GetXmlDocumentByFileName(string fileName)
        {
            XmlDocument doc = new XmlDocument();
            lock (lockObject)
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    doc.LoadXml(reader.ReadToEnd());
                }
            }
            return doc;
        }

        private string GetFileContent(string fileName)
        {
            lock (lockObject)
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public IList<ListItem> GetListItems()
        {
            XmlDocument doc = GetXmlDocumentByFileName(DbListItemFile);
            IList<ListItem> list = new List<ListItem>();
            XmlNodeList nodeList = doc.GetElementsByTagName("Lists");
            if (nodeList.Count > 0)
            {
                XmlNode root = nodeList[0];
                foreach (XmlNode node in root.ChildNodes)
                {
                    list.Add(ListItem.LoadByXmlNode(node));
                }
            }
            return list;
        }

        public IList<HtmlItem> GetHtmlItemsByParent(string fileName, int pageIndex, int pageSize)
        {
            string xmlFileName = GetXmlFileName(fileName);
            XmlDocument doc = GetXmlDocumentByFileName(xmlFileName);
            IList<HtmlItem> list = new List<HtmlItem>();
            XmlNodeList nodeList = doc.GetElementsByTagName("Htmls");
            if (nodeList.Count > 0)
            {
                XmlNode root = nodeList[0];
                for (int i = 0;
                    i < root.ChildNodes.Count
                    && i >= pageIndex * pageSize
                    && i < (pageIndex + 1) * pageSize;
                    i++)
                {
                    XmlNode node = root.ChildNodes[i];
                    list.Add(HtmlItem.LoadByXmlNode(node));
                }
            }
            return list;
        }

        public HtmlItem GetHtmlItemById(string fileName, string listCode, string itemId)
        {
            string xmlFileName = GetXmlFileName(fileName);
            XmlDocument doc = GetXmlDocumentByFileName(xmlFileName);
            HtmlItem thisItem = null;
            XmlNodeList nodeList = doc.GetElementsByTagName("Htmls");
            if (nodeList.Count > 0)
            {
                XmlNode root = nodeList[0];
                foreach (XmlNode node in root.ChildNodes)
                {
                    HtmlItem item = HtmlItem.LoadByXmlNode(node);
                    if (item.Id.Equals(itemId, StringComparison.OrdinalIgnoreCase))
                    {
                        thisItem = item;
                        break;
                    }
                }
            }
            if (thisItem != null)
            {
                string titleFileName = string.Format(@"Contents\{0}\{1}.Title.txt"
                    , listCode ?? "_None"
                    , itemId);
                thisItem.Title = GetFileContent(titleFileName);

                string contentFileName = string.Format(@"Contents\{0}\{1}.Content.txt"
                    , listCode ?? "_None"
                    , itemId);
                thisItem.Content = GetFileContent(contentFileName);
            }
            return thisItem;
        }

        public IList<MenuItem> GetTopMenuList()
        {
            XmlDocument doc = GetXmlDocumentByFileName(DbMenuItemFile);
            IList<MenuItem> list = new List<MenuItem>();
            XmlNodeList nodeList = doc.GetElementsByTagName("Menus");
            if (nodeList.Count > 0)
            {
                XmlNode root = nodeList[0];
                foreach (XmlNode node in root.ChildNodes)
                {
                    list.Add(MenuItem.LoadByXmlNode(node, null));
                }
            }
            return list;
        }

        public IList<MenuItem> GetChildrenMenuList(string parentId)
        {
            XmlDocument doc = GetXmlDocumentByFileName(DbMenuItemFile);
            IList<MenuItem> list = new List<MenuItem>();
            XmlNodeList nodeList = doc.GetElementsByTagName("Menus");
            if (nodeList.Count > 0)
            {
                XmlNode root = nodeList[0];
                foreach (XmlNode node in root.ChildNodes)
                {
                    MenuItem item = MenuItem.LoadByXmlNode(node, null);
                    if (item.Id.Equals(parentId, StringComparison.OrdinalIgnoreCase) && item.ChildrenNode != null)
                    {
                        foreach (XmlNode child in item.ChildrenNode.ChildNodes)
                        {
                            list.Add(MenuItem.LoadByXmlNode(child, item.Id));
                        }
                        break;
                    }
                }
            }
            return list;
        }

        public ListItem GetListItemByMenu(string menuId)
        {
            return null;
        }

        public HtmlItem GetHtmlItemByMenu(string menuId)
        {
            return null;
        }
    }
}
