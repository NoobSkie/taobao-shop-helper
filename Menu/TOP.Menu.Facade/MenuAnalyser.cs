using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace TOP.Menu.Facade
{
    public class MenuAnalyser
    {
        public List<MenuInfo> Analyser(string xmlPath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlPath);

            List<MenuInfo> list = new List<MenuInfo>();
            foreach (XmlNode root in doc.ChildNodes)
            {
                if (root.Name.Equals("Menus", StringComparison.OrdinalIgnoreCase))
                {
                    foreach (XmlNode child in root.ChildNodes)
                    {
                        if (child.Name.Equals("Menu", StringComparison.OrdinalIgnoreCase))
                        {
                            MenuInfo menu = new MenuInfo();
                            foreach (XmlNode info in child.ChildNodes)
                            {
                                if (info.Name.Equals("Id", StringComparison.OrdinalIgnoreCase))
                                {
                                    menu.Id = info.InnerText;
                                }
                                else if (info.Name.Equals("Title", StringComparison.OrdinalIgnoreCase))
                                {
                                    menu.Title = info.InnerText;
                                }
                                else if (info.Name.Equals("Url", StringComparison.OrdinalIgnoreCase))
                                {
                                    menu.Url = info.InnerText;
                                }
                            }
                            list.Add(menu);
                        }
                    }
                }
            }
            return list;
        }
    }
}
