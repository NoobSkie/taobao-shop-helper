using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TOP.Template.Facade
{
    public class TemplateInfo
    {
        public string OuterHTML { get; set; }

        public string InnerHTML { get; set; }

        public string Category { get; set; }

        public string DisplayName { get; set; }

        public string DataType { get; set; }

        private List<TemplateInfo> children = null;
        public List<TemplateInfo> Children
        {
            get
            {
                if (children == null)
                {
                    children = TemplateAnalyser.AnalyseTemplateList(InnerHTML);
                }
                return children;
            }
        }
    }
}
