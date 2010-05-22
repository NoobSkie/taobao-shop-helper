namespace Shove.HTML.HtmlParse
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class AttributeList : Shove.HTML.HtmlParse.Attribute
    {
        protected ArrayList m_list;

        public AttributeList() : base("", "")
        {
            this.m_list = new ArrayList();
        }

        public void Add(Shove.HTML.HtmlParse.Attribute a)
        {
            this.m_list.Add(a);
        }

        public void Clear()
        {
            this.m_list.Clear();
        }

        public override object Clone()
        {
            AttributeList list = new AttributeList();
            for (int i = 0; i < this.m_list.Count; i++)
            {
                list.Add((Shove.HTML.HtmlParse.Attribute) this[i].Clone());
            }
            return list;
        }

        public bool IsEmpty()
        {
            return (this.m_list.Count <= 0);
        }

        public void Set(string name, string value)
        {
            if (name != null)
            {
                if (value == null)
                {
                    value = "";
                }
                Shove.HTML.HtmlParse.Attribute a = this[name];
                if (a == null)
                {
                    a = new Shove.HTML.HtmlParse.Attribute(name, value);
                    this.Add(a);
                }
                else
                {
                    a.Value = value;
                }
            }
        }

        public int Count
        {
            get
            {
                return this.m_list.Count;
            }
        }

        public Shove.HTML.HtmlParse.Attribute this[int index]
        {
            get
            {
                if (index < this.m_list.Count)
                {
                    return (Shove.HTML.HtmlParse.Attribute) this.m_list[index];
                }
                return null;
            }
        }

        public Shove.HTML.HtmlParse.Attribute this[string index]
        {
            get
            {
                for (int i = 0; this[i] != null; i++)
                {
                    if (this[i].Name.ToLower().Equals(index.ToLower()))
                    {
                        return this[i];
                    }
                }
                return null;
            }
        }

        public ArrayList List
        {
            get
            {
                return this.m_list;
            }
        }
    }
}

