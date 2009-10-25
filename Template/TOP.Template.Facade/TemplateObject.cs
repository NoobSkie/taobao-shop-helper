using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TOP.Template.Facade
{
    [Serializable]
    public class TemplateObject
    {
        public TemplateObject()
        {
            ShowTitle = true;
            ShowThis = true;
        }

        public string Id { get; set; }

        public string OuterHTML { get; set; }

        public string InnerHTML { get; set; }

        public string Category { get; set; }

        public string DisplayName { get; set; }

        public string DemoInput { get; set; }

        public string Information { get; set; }

        public string DataType { get; set; }

        public string DataSource { get; set; }

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
        /// 是否显示当前节点
        /// </summary>
        public bool ShowThis { get; set; }

        public string CssName { get; set; }

        /// <summary>
        /// 当前显示序号
        /// </summary>
        public int Index { get; set; }

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

        public bool NoUse { get; set; }

        private List<TemplateObject> children = null;
        public List<TemplateObject> Children
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

        public TemplateObject Clone()
        {
            TemplateObject obj = new TemplateObject();
            obj.Id = Id;
            obj.DemoInput = DemoInput;
            obj.Information = Information;
            obj.OuterHTML = OuterHTML;
            obj.InnerHTML = InnerHTML;
            obj.Category = Category;
            obj.DisplayName = DisplayName;
            obj.DataType = DataType;
            obj.CssName = CssName;
            obj.DefaultValue = DefaultValue;
            obj.ShowTitle = ShowTitle;
            obj.TitleWidth = TitleWidth;
            obj.InputWidth = InputWidth;
            obj.InputHeight = InputHeight;
            obj.NoUse = NoUse;
            return obj;
        }
    }

    public class TemplateComparer : IComparer<TemplateObject>
    {
        #region IComparer<TemplateInfo> Members

        public int Compare(TemplateObject x, TemplateObject y)
        {
            return x.Index.CompareTo(y.Index);
        }

        #endregion
    }
}
