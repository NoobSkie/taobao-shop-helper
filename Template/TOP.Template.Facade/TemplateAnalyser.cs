using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TOP.Template.Facade
{
    public static class TemplateAnalyser
    {
        private const string Pattern_OuterText = "{template[:]?[^}]*}[^{}]*(((?'Level'{template[:]?[^}]*})[^{}]*)+((?'-Level'{/template})[^{}]*)+)*{/template}";
        private const string Pattern_InnerText = "(?<={template[:]?[^}]*}).*(?={/template})";
        private const string Pattern_Category = "(?<=template:)\\w*|(?<=\\{template) ";
        private const string Pattern_Properties = "(?<=\\{template([\\S]*) ).*(?=\\})";
        private const string Pattern_Property = "\\w+\\s*=\\s*(?:\"[^\"]*\"|'[^']*')";

        public static List<TemplateInfo> AnalyseTemplateList(string html)
        {
            List<TemplateInfo> tempList = new List<TemplateInfo>();

            Regex regex = new Regex(Pattern_OuterText, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.IgnorePatternWhitespace);
            Match match = regex.Match(html);
            while (match.Success)
            {
                tempList.Add(AnalyseTemplate(match.Value));

                match = match.NextMatch();
            }
            return tempList;
        }

        public static TemplateInfo AnalyseTemplate(string html)
        {
            if (string.IsNullOrEmpty(html))
            {
                throw new ArgumentException("分析模板 - 参数不能为空。", "html");
            }
            TemplateInfo info = new TemplateInfo();

            #region 外部文本

            info.OuterHTML = html;

            #endregion

            #region 内部文本

            Regex regex_InnerText = new Regex(Pattern_InnerText, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match match_InnerText = regex_InnerText.Match(html, 0);
            if (match_InnerText.Success)
            {
                info.InnerHTML = match_InnerText.Value;
            }
            else
            {
                info.InnerHTML = string.Empty;
            }

            #endregion

            #region 模板分类

            Regex regex_Category = new Regex(Pattern_Category, RegexOptions.IgnoreCase);
            Match match_Category = regex_Category.Match(html, 0);
            if (match_Category.Success)
            {
                info.Category = match_Category.Value;
            }
            else
            {
                info.Category = string.Empty;
            }

            #endregion

            #region 属性

            Regex regex_Properties = new Regex(Pattern_Properties, RegexOptions.IgnoreCase);
            Match match_Properties = regex_Properties.Match(html, 0);
            if (match_Properties.Success)
            {
                Regex regex_Property = new Regex(Pattern_Property, RegexOptions.IgnoreCase);
                Match match_Property = regex_Property.Match(match_Properties.Value, 0);
                while (match_Property.Success)
                {
                    string text = match_Property.Value;
                    int index = text.IndexOf("=");
                    string title = text.Substring(0, index);
                    string value = text.Substring(index + 1).Trim('"');
                    switch (title.ToLower())
                    {
                        case "displayname":
                            info.DisplayName = value;
                            break;
                        case "datatype":
                            info.DataType = value;
                            break;
                        case "datasource":
                            info.DataSource = value;
                            break;
                        case "defaultvalue":
                            info.DefaultValue = value;
                            break;
                        case "showtitle":
                            info.ShowTitle = bool.Parse(value);
                            break;
                        case "showthis":
                            info.ShowThis = bool.Parse(value);
                            break;
                        case "index":
                            info.Index = int.Parse(value);
                            break;
                        case "titlewidth":
                            info.TitleWidth = int.Parse(value);
                            break;
                        case "inputwidth":
                            info.InputWidth = int.Parse(value);
                            break;
                        case "inputheight":
                            info.InputHeight = int.Parse(value);
                            break;
                    }

                    match_Property = match_Property.NextMatch();
                }
            }

            #endregion

            return info;
        }
    }
}
