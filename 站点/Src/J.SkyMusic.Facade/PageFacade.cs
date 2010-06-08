using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace J.SkyMusic.Facade
{
    public class PageFacade : BaseFacade
    {
        public PageFacade(string baseXmlDir) : base(baseXmlDir) { }

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

        public void AddList(ListItem list)
        {
            XmlDocument doc = GetXmlDocumentByFileName(DbListItemFile);
            XmlNodeList nodeList = doc.GetElementsByTagName("Lists");
            if (nodeList.Count > 0)
            {
                XmlNode root = nodeList[0];

                XmlElement listNode = doc.CreateElement("List");
                XmlElement nodeId = doc.CreateElement("Id");
                nodeId.InnerText = list.Id;
                listNode.AppendChild(nodeId);
                XmlElement nodeName = doc.CreateElement("Name");
                nodeName.InnerText = list.Name;
                listNode.AppendChild(nodeName);
                XmlElement nodeCode = doc.CreateElement("Code");
                nodeCode.InnerText = list.Code;
                listNode.AppendChild(nodeCode);
                XmlElement nodeFile = doc.CreateElement("SubFile");
                nodeFile.InnerText = list.SubDbFileName;
                listNode.AppendChild(nodeFile);
                XmlElement nodeCount = doc.CreateElement("ChildrenCount");
                nodeCount.InnerText = "0";
                listNode.AppendChild(nodeCount);

                root.AppendChild(listNode);
                SaveXmlDocument(doc, DbListItemFile);

                string dirPath = GetXmlFileName(string.Format(@"Contents\{0}", list.SubDbFileName));
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("数据库结构错误 - 列表");
            }
        }

        public void ModifyListName(string listId, string newName)
        {
            if (string.IsNullOrEmpty(listId))
            {
                return;
            }
            XmlDocument doc = GetXmlDocumentByFileName(DbListItemFile);
            XmlNodeList nodeList = doc.GetElementsByTagName("Lists");
            if (nodeList.Count > 0)
            {
                XmlNode root = nodeList[0];
                foreach (XmlNode listNode in root.ChildNodes)
                {
                    bool isTarget = false;
                    foreach (XmlNode sub in listNode.ChildNodes)
                    {
                        if (sub.Name.Equals("Id", StringComparison.OrdinalIgnoreCase))
                        {
                            if (sub.InnerText.Equals(listId, StringComparison.OrdinalIgnoreCase))
                            {
                                isTarget = true;
                            }
                            break;
                        }
                    }
                    if (isTarget)
                    {
                        foreach (XmlNode sub in listNode.ChildNodes)
                        {
                            if (sub.Name.Equals("Name", StringComparison.OrdinalIgnoreCase))
                            {
                                int currentCount = int.Parse(sub.InnerText);
                                sub.InnerText = newName;
                                break;
                            }
                        }
                    }
                }
                SaveXmlDocument(doc, DbListItemFile);
            }
            else
            {
                throw new ArgumentOutOfRangeException("数据库结构错误 - 列表");
            }
        }

        public void IncreaseListCount(string listId, int increaseNumber)
        {
            if (string.IsNullOrEmpty(listId))
            {
                return;
            }
            XmlDocument doc = GetXmlDocumentByFileName(DbListItemFile);
            XmlNodeList nodeList = doc.GetElementsByTagName("Lists");
            if (nodeList.Count > 0)
            {
                XmlNode root = nodeList[0];
                foreach (XmlNode listNode in root.ChildNodes)
                {
                    bool isTarget = false;
                    foreach (XmlNode sub in listNode.ChildNodes)
                    {
                        if (sub.Name.Equals("Id", StringComparison.OrdinalIgnoreCase))
                        {
                            if (sub.InnerText.Equals(listId, StringComparison.OrdinalIgnoreCase))
                            {
                                isTarget = true;
                            }
                            break;
                        }
                    }
                    if (isTarget)
                    {
                        foreach (XmlNode sub in listNode.ChildNodes)
                        {
                            if (sub.Name.Equals("ChildrenCount", StringComparison.OrdinalIgnoreCase))
                            {
                                int currentCount = int.Parse(sub.InnerText);
                                sub.InnerText = (currentCount + increaseNumber).ToString();
                                break;
                            }
                        }
                    }
                }
                SaveXmlDocument(doc, DbListItemFile);
            }
            else
            {
                throw new ArgumentOutOfRangeException("数据库结构错误 - 列表");
            }
        }

        public void AddContent(HtmlItem item)
        {
            string fileName = "DB_HtmlItem.xml";
            string contentPath = @"Contents\_None";
            if (!string.IsNullOrEmpty(item.ItsListId))
            {
                ListItem list = GetListItemById(item.ItsListId);
                if (list != null)
                {
                    fileName = string.Format("DB_Html_{0}.xml", list.Code);
                    contentPath = string.Format(@"Contents\{0}", list.Code);
                }
            }
            fileName = GetXmlFileName(fileName);
            XmlDocument doc = GetXmlDocumentByFileName(fileName);
            XmlNodeList nodeList = doc.GetElementsByTagName("Htmls");
            if (nodeList.Count > 0)
            {
                XmlNode root = nodeList[0];
                XmlElement contentNode = doc.CreateElement("Item");
                XmlElement nodeId = doc.CreateElement("Id");
                nodeId.InnerText = item.Id;
                contentNode.AppendChild(nodeId);
                XmlElement nodeName = doc.CreateElement("Name");
                nodeName.InnerText = item.Name;
                contentNode.AppendChild(nodeName);
                XmlElement nodeCreateTime = doc.CreateElement("CreateTime");
                nodeCreateTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:ss:mm");
                contentNode.AppendChild(nodeCreateTime);
                XmlElement nodeLastUpdateTime = doc.CreateElement("LastUpdateTime");
                nodeLastUpdateTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:ss:mm");
                contentNode.AppendChild(nodeLastUpdateTime);
                if (item.IncludeScriptFileList != null && item.IncludeScriptFileList.Count > 0)
                {
                    XmlElement scriptNode = doc.CreateElement("Scripts");
                    foreach (string script in item.IncludeScriptFileList)
                    {
                        XmlElement fileNode = doc.CreateElement("FileName");
                        fileNode.InnerText = script;
                        scriptNode.AppendChild(fileNode);
                    }
                    contentNode.AppendChild(scriptNode);
                }
                if (item.IncludeStyleFileList != null && item.IncludeStyleFileList.Count > 0)
                {
                    XmlElement styleNode = doc.CreateElement("Styles");
                    foreach (string style in item.IncludeStyleFileList)
                    {
                        XmlElement fileNode = doc.CreateElement("FileName");
                        fileNode.InnerText = style;
                        styleNode.AppendChild(fileNode);
                    }
                    contentNode.AppendChild(styleNode);
                }
                if (root.ChildNodes.Count == 0)
                {
                    root.AppendChild(contentNode);
                }
                else
                {
                    root.InsertBefore(contentNode, root.ChildNodes[0]);
                }
                SaveXmlDocument(doc, fileName);
                string nameFileName = GetXmlFileName(string.Format(@"{0}\{1}.Name.txt", contentPath, item.Id));
                string titleFileName = GetXmlFileName(string.Format(@"{0}\{1}.Title.txt", contentPath, item.Id));
                string contentFileName = GetXmlFileName(string.Format(@"{0}\{1}.Content.txt", contentPath, item.Id));
                File.WriteAllText(nameFileName, item.ListName);
                File.WriteAllText(titleFileName, item.Title);
                File.WriteAllText(contentFileName, item.Content);

                IncreaseListCount(item.ItsListId, 1);
            }
            else
            {
                throw new ArgumentOutOfRangeException("数据库结构错误 - " + fileName);
            }
        }

        public void AddMenu(MenuItem menu)
        {
            XmlDocument doc = GetXmlDocumentByFileName(DbMenuItemFile);
            XmlNodeList nodeList = doc.GetElementsByTagName("Menus");
            if (nodeList.Count > 0)
            {
                XmlNode root = nodeList[0];
                if (!string.IsNullOrEmpty(menu.ParentId))
                {
                    foreach (XmlNode menuItem in root.ChildNodes)
                    {
                        bool isTarget = false;
                        foreach (XmlNode item in menuItem.ChildNodes)
                        {
                            if (item.Name.Equals("Id", StringComparison.OrdinalIgnoreCase))
                            {
                                if (item.InnerText.Equals(menu.ParentId, StringComparison.OrdinalIgnoreCase))
                                {
                                    isTarget = true;
                                }
                                break;
                            }
                        }
                        if (isTarget)
                        {
                            bool hasChildrenNode = false;
                            foreach (XmlNode item in menuItem.ChildNodes)
                            {
                                if (item.Name.Equals("Children", StringComparison.OrdinalIgnoreCase))
                                {
                                    root = item;
                                    hasChildrenNode = true;
                                    break;
                                }
                            }
                            if (!hasChildrenNode)
                            {
                                XmlElement chilrenNode = doc.CreateElement("Children");
                                menuItem.AppendChild(chilrenNode);
                                root = chilrenNode;
                            }
                        }
                    }
                }

                XmlElement listNode = doc.CreateElement("Menu");
                XmlElement nodeId = doc.CreateElement("Id");
                nodeId.InnerText = menu.Id;
                listNode.AppendChild(nodeId);

                XmlElement nodeName = doc.CreateElement("Name");
                nodeName.InnerText = menu.Name;
                listNode.AppendChild(nodeName);

                XmlElement nodeIndex = doc.CreateElement("Index");
                nodeIndex.InnerText = menu.Index.ToString();
                listNode.AppendChild(nodeIndex);

                XmlElement nodeType = doc.CreateElement("Type");
                nodeType.InnerText = ((int)menu.Type).ToString();
                listNode.AppendChild(nodeType);

                XmlElement nodeOpenNew = doc.CreateElement("IsOpenNewWindow");
                nodeOpenNew.InnerText = menu.IsOpenNewWindow.ToString();
                listNode.AppendChild(nodeOpenNew);

                XmlElement nodeInnerCode = doc.CreateElement("InnerCode");
                nodeInnerCode.InnerText = menu.InnerCode;
                listNode.AppendChild(nodeInnerCode);

                XmlElement nodeInnerId = doc.CreateElement("InnerId");
                nodeInnerId.InnerText = menu.InnerId;
                listNode.AppendChild(nodeInnerId);

                XmlElement nodeOutUrl = doc.CreateElement("OutUrl");
                nodeOutUrl.InnerText = menu.OutUrl;
                listNode.AppendChild(nodeOutUrl);

                XmlElement nodeLevel = doc.CreateElement("Level");
                nodeLevel.InnerText = menu.Level.ToString();
                listNode.AppendChild(nodeLevel);

                root.AppendChild(listNode);
                SaveXmlDocument(doc, DbListItemFile);
            }
            else
            {
                throw new ArgumentOutOfRangeException("数据库结构错误 - 列表");
            }
        }

        public ListItem GetListItemById(string id)
        {
            XmlDocument doc = GetXmlDocumentByFileName(DbListItemFile);
            IList<ListItem> list = new List<ListItem>();
            XmlNodeList nodeList = doc.GetElementsByTagName("Lists");
            if (nodeList.Count > 0)
            {
                XmlNode root = nodeList[0];
                foreach (XmlNode node in root.ChildNodes)
                {
                    ListItem item = ListItem.LoadByXmlNode(node);
                    if (item.Id.Equals(id, StringComparison.OrdinalIgnoreCase))
                    {
                        return item;
                    }
                }
            }
            return null;
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
