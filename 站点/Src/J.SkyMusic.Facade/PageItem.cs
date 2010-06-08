using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace J.SkyMusic.Facade
{
    public class PageItem
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }

    public class ListItem : PageItem
    {
        public string Code { get; set; }

        public string SubDbFileName { get; set; }

        public int ChildrenCount { get; set; }

        public static ListItem LoadByXmlNode(XmlNode xmlNode)
        {
            ListItem item = new ListItem();
            foreach (XmlNode child in xmlNode.ChildNodes)
            {
                switch (child.Name.ToUpper())
                {
                    case "ID":
                        item.Id = child.InnerText;
                        break;
                    case "NAME":
                        item.Name = child.InnerText;
                        break;
                    case "CODE":
                        item.Code = child.InnerText;
                        break;
                    case "SUBFILE":
                        item.SubDbFileName = child.InnerText;
                        break;
                    case "CHILDRENCOUNT":
                        item.ChildrenCount = int.Parse(child.InnerText);
                        break;
                }
            }
            return item;
        }
    }

    public class HtmlItem : PageItem
    {
        public string ListName { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ItsListId { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime LastUpdateTime { get; set; }

        public IList<string> IncludeScriptFileList { get; set; }

        public IList<string> IncludeStyleFileList { get; set; }

        public static HtmlItem LoadByXmlNode(XmlNode xmlNode)
        {
            HtmlItem item = new HtmlItem();
            foreach (XmlNode child in xmlNode.ChildNodes)
            {
                switch (child.Name.ToUpper())
                {
                    case "ID":
                        item.Id = child.InnerText;
                        break;
                    case "NAME":
                        item.Name = child.InnerText;
                        break;
                    case "CREATETIME":
                        item.CreateTime = DateTime.Parse(child.InnerText);
                        break;
                    case "LASTUPDATETIME":
                        item.LastUpdateTime = DateTime.Parse(child.InnerText);
                        break;
                }
            }
            return item;
        }
    }

    public class MenuItem : PageItem
    {
        public int Index { get; set; }

        public MenuType Type { get; set; }

        public bool IsOpenNewWindow { get; set; }

        public string InnerCode { get; set; }

        public string InnerId { get; set; }

        public string OutUrl { get; set; }

        public string ParentId { get; set; }

        public int Level { get; set; }

        internal XmlNode ChildrenNode { get; set; }

        public static MenuItem LoadByXmlNode(XmlNode xmlNode, string parentId)
        {
            MenuItem item = new MenuItem();
            item.ParentId = parentId;
            foreach (XmlNode child in xmlNode.ChildNodes)
            {
                switch (child.Name.ToUpper())
                {
                    case "ID":
                        item.Id = child.InnerText;
                        break;
                    case "NAME":
                        item.Name = child.InnerText;
                        break;
                    case "INDEX":
                        item.Index = int.Parse(child.InnerText);
                        break;
                    case "ISOPENNEWWINDOW":
                        item.IsOpenNewWindow = bool.Parse(child.InnerText);
                        break;
                    case "INNERCODE":
                        item.InnerCode = child.InnerText;
                        break;
                    case "INNERID":
                        item.InnerId = child.InnerText;
                        break;
                    case "OUTURL":
                        item.OutUrl = child.InnerText;
                        break;
                    case "LEVEL":
                        item.Level = int.Parse(child.InnerText);
                        break;
                    case "CHILDREN":
                        item.ChildrenNode = child;
                        break;
                }
            }
            return item;
        }
    }

    public enum MenuType
    {
        Auto = 0,
        HtmlPage = 1,
        ListPage = 2,
        OutUrl = 3,
    }
}
