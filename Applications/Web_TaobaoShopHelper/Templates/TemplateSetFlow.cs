using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TOP.Applications.TaobaoShopHelper.Templates
{
    /// <summary>
    /// 模板设置流程
    /// </summary>
    public class TemplateSetFlow
    {
        private List<TemplateSetItem> currentFlow;
        public List<TemplateSetItem> CurrentFlow
        {
            get
            {
                if (currentFlow == null)
                {
                    currentFlow = new List<TemplateSetItem>();
                }
                return currentFlow;
            }
            set
            {
                currentFlow = value;
            }
        }
    }

    public class TemplateSetItem
    {
        public string Action { get; set; }

        public string ContainerId { get; set; }

        public int ChildrenCount { get; set; }

        public string Value { get; set; }
    }
}
