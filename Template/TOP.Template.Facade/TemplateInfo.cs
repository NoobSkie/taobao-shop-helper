using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TOP.Template.Facade
{
    public class TemplateInfo
    {
        public TemplateInfo()
        {
            ShowTitle = true;
            IsFloat = true;
        }

        public string OuterHTML { get; set; }

        public string InnerHTML { get; set; }

        public string Category { get; set; }

        public string DisplayName { get; set; }

        public string DataType { get; set; }

        /// <summary>
        /// 默认值
        /// </summary>
        public string DefaultValue { get; set; }

        /// <summary>
        /// 是否显示标题
        /// </summary>
        public bool ShowTitle { get; set; }

        /// <summary>
        /// 是否与上一个标签在同一行
        /// </summary>
        public bool IsFloat { get; set; }

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
    }
}
