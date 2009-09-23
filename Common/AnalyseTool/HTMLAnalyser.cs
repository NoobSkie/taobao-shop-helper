using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TOP.Common.AnalyseTool
{
    public class HTMLAnalyser
    {
        public List<InputItem> Analyse(string html)
        {
            List<InputItem> itemList = new List<InputItem>();
            string reg = @"<tag:[^<>]+?>[\S\s]*</tag>";
            Regex regex = new Regex(reg);
            Match match = regex.Match(html);
            while (match.Success)
            {
                string itemHTML = match.Value;
                itemList.Add(GetItemByHTML(itemHTML));

                match = match.NextMatch();
            }
            return itemList;
        }

        public InputItem GetItemByHTML(string html)
        {
            InputItem item = new InputItem();
            item.OuterHTML = html;

            string reg = @"<[^<>]*>";
            Regex regex = new Regex(reg);
            Match match = regex.Match(html);
            if (match.Success) html = match.Value.TrimStart('<').TrimEnd('>');
            else return null;

            foreach (string str in html.Split(' '))
            {
                if (str.StartsWith("tag:", StringComparison.OrdinalIgnoreCase))
                {
                    string type = str.Substring("tag:".Length);
                    item.InputType = (InputType)Enum.Parse(typeof(InputType), type, true);
                }
                else if (str.StartsWith("displayname=", StringComparison.OrdinalIgnoreCase))
                {
                    item.DisplayName = str.Substring("displayname=".Length).Trim('"');
                }
                else if (str.StartsWith("valuetype=", StringComparison.OrdinalIgnoreCase))
                {
                    string type = str.Substring("valuetype=".Length).Trim('"');
                    item.ValueType = (ValueType)Enum.Parse(typeof(ValueType), type, true);
                }
                else if (str.StartsWith("itemvalue=", StringComparison.OrdinalIgnoreCase))
                {
                    item.ItemValue = str.Substring("itemvalue=".Length).Trim('"');
                }
                else if (str.StartsWith("defaultvalue=", StringComparison.OrdinalIgnoreCase))
                {
                    item.DefaultValue = str.Substring("defaultvalue=".Length).Trim('"');
                }
                else if (str.StartsWith("width=", StringComparison.OrdinalIgnoreCase))
                {
                    item.Width = int.Parse(str.Substring("width=".Length).Trim('"'));
                }
                else if (str.StartsWith("height=", StringComparison.OrdinalIgnoreCase))
                {
                    item.Height = int.Parse(str.Substring("height=".Length).Trim('"'));
                }
            }
            return item;
        }
    }

    public class InputItem
    {
        public InputType InputType { get; set; }

        public string DisplayName { get; set; }

        public string ItemValue { get; set; }

        public string DefaultValue { get; set; }

        public ValueType ValueType { get; set; }

        public string OuterHTML { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public string InnerHTML
        {
            get
            {
                string reg = @">[\s\S]*<";
                Regex regex = new Regex(reg);
                Match match = regex.Match(OuterHTML);
                if (match.Success)
                {
                    return match.Value.TrimStart('>').TrimEnd('<');
                }
                else
                {
                    return string.Empty;
                }
            }
        }
    }

    public enum ValueType
    {
        String = 0,
        Image = 1,
        Text = 2,
    }

    public enum InputType
    {
        Item = 0,
        List = 1,
        // 以下是系统定义类型
        /// <summary>
        /// 选择商品
        /// </summary>
        SelectItemList = 10,
    }
}
