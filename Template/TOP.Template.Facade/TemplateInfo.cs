using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TOP.Template.Facade
{
    [Serializable]
    public class TemplateInfo
    {
        public TemplateInfo()
        {
            ShowTitle = true;
        }

        public string OuterHTML { get; set; }

        public string InnerHTML { get; set; }

        public string Category { get; set; }

        public string DisplayName { get; set; }

        public string DataType { get; set; }

        public string CurrentValue { get; set; }

        /// <summary>
        /// 默认值
        /// </summary>
        public string DefaultValue { get; set; }

        /// <summary>
        /// 是否显示标题
        /// </summary>
        public bool ShowTitle { get; set; }

        /// <summary>
        /// 标题的宽度
        /// </summary>
        public int TitleWidth { get; set; }

        /// <summary>
        /// 输入项的宽度
        /// </summary>
        public int InputWidth { get; set; }

        /// <summary>
        /// 输入项的高度
        /// </summary>
        public int InputHeight { get; set; }

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

        public TemplateInfo Clone()
        {
            TemplateInfo obj = new TemplateInfo();
            obj.OuterHTML = OuterHTML;
            obj.InnerHTML = InnerHTML;
            obj.Category = Category;
            obj.DisplayName = DisplayName;
            obj.DataType = DataType;
            obj.DefaultValue = DefaultValue;
            obj.ShowTitle = ShowTitle;
            obj.TitleWidth = TitleWidth;
            obj.InputWidth = InputWidth;
            obj.InputHeight = InputHeight;
            return obj;
        }
    }
}
