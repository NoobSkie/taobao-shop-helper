using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TOP.Applications.TaobaoShopHelper._Common;

namespace TOP.Applications.TaobaoShopHelper.WebControls.Common
{
    public class InformationObject
    {
        public string Message { get; set; }

        public string CssName { get; set; }

        private List<LinkItem> _linkList;
        public List<LinkItem> LinkList
        {
            get
            {
                return _linkList;
            }
        }

        public void AddLink(string name, string url)
        {
            if (_linkList == null)
            {
                _linkList = new List<LinkItem>();
            }
            LinkItem item = new LinkItem();
            item.Name = name;
            item.Url = url;
            _linkList.Add(item);
        }
    }

    public class LinkItem
    {
        public string Name { get; set; }

        public string Url { get; set; }
    }
}
