namespace Shove.HTML.HtmlParse
{
    using System;

    public class ParseHTML : Shove.HTML.HtmlParse.Parse
    {
        public string BuildTag()
        {
            string str = "<";
            str = str + base.m_tag;
            for (int i = 0; base[i] != null; i++)
            {
                str = str + " ";
                if (base[i].Value == null)
                {
                    if (base[i].Delim != '\0')
                    {
                        str = str + base[i].Delim;
                    }
                    str = str + base[i].Name;
                    if (base[i].Delim != '\0')
                    {
                        str = str + base[i].Delim;
                    }
                }
                else
                {
                    str = str + base[i].Name;
                    if (base[i].Value != null)
                    {
                        str = str + "=";
                        if (base[i].Delim != '\0')
                        {
                            str = str + base[i].Delim;
                        }
                        str = str + base[i].Value;
                        if (base[i].Delim != '\0')
                        {
                            str = str + base[i].Delim;
                        }
                    }
                }
            }
            return (str + ">");
        }

        public AttributeList GetTag()
        {
            AttributeList list = new AttributeList();
            list.Name = base.m_tag;
            foreach (Shove.HTML.HtmlParse.Attribute attribute in base.List)
            {
                list.Add((Shove.HTML.HtmlParse.Attribute) attribute.Clone());
            }
            return list;
        }

        public char Parse()
        {
            if (base.GetCurrentChar() != '<')
            {
                return base.AdvanceCurrentChar();
            }
            base.Advance();
            char ch = char.ToUpper(base.GetCurrentChar());
            if (((ch < 'A') || (ch > 'Z')) && ((ch != '!') && (ch != '/')))
            {
                return base.AdvanceCurrentChar();
            }
            this.ParseTag();
            return '\0';
        }

        protected void ParseTag()
        {
            base.m_tag = "";
            base.Clear();
            if (((base.GetCurrentChar() != '!') || (base.GetCurrentChar(1) != '-')) || (base.GetCurrentChar(2) != '-'))
            {
                while (!base.Eof())
                {
                    if (Shove.HTML.HtmlParse.Parse.IsWhiteSpace(base.GetCurrentChar()) || (base.GetCurrentChar() == '>'))
                    {
                        break;
                    }
                    base.m_tag = base.m_tag + base.GetCurrentChar();
                    base.Advance();
                }
            }
            else
            {
                while (!base.Eof())
                {
                    if (((base.GetCurrentChar() == '-') && (base.GetCurrentChar(1) == '-')) && (base.GetCurrentChar(2) == '>'))
                    {
                        break;
                    }
                    if (base.GetCurrentChar() != '\r')
                    {
                        base.m_tag = base.m_tag + base.GetCurrentChar();
                    }
                    base.Advance();
                }
                base.m_tag = base.m_tag + "--";
                base.Advance();
                base.Advance();
                base.Advance();
                base.ParseDelim = '\0';
                return;
            }
            base.EatWhiteSpace();
            while (base.GetCurrentChar() != '>')
            {
                base.ParseName = "";
                base.ParseValue = "";
                base.ParseDelim = '\0';
                base.ParseAttributeName();
                if (base.GetCurrentChar() == '>')
                {
                    base.AddAttribute();
                    break;
                }
                base.ParseAttributeValue();
                base.AddAttribute();
            }
            base.Advance();
        }
    }
}

