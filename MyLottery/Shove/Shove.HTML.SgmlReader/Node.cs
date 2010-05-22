using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Shove.HTML.SgmlReader
{
    internal class Node
    {
        internal XmlNodeType NodeType;
        internal string Value;
        internal XmlSpace Space;
        internal string XmlLang;
        internal bool IsEmpty;
        internal string Name;
        internal ElementDecl DtdType; 
        internal State CurrentState;
        internal bool Simulated; 
        HWStack attributes = new HWStack(10);

   
        public void Reset(string name, XmlNodeType nt, string value)
        {
            this.Value = value;
            this.Name = name;
            this.NodeType = nt;
            this.Space = XmlSpace.None;
            this.XmlLang = null;
            this.IsEmpty = true;
            this.attributes.Count = 0;
            this.DtdType = null;
        }

        public Attribute AddAttribute(string name, string value, char quotechar, bool caseInsensitive)
        {
            Attribute a;
         
            for (int i = 0, n = this.attributes.Count; i < n; i++)
            {
                a = (Attribute)this.attributes[i];
                if (caseInsensitive && string.Compare(a.Name, name, true) == 0)
                {
                    return null;
                }
                else if ((object)a.Name == (object)name)
                {
                    return null;
                }
            }
       
            a = (Attribute)this.attributes.Push();
            if (a == null)
            {
                a = new Attribute();
                this.attributes[this.attributes.Count - 1] = a;
            }
            a.Reset(name, value, quotechar);
            return a;
        }

        public void RemoveAttribute(string name)
        {
            for (int i = 0, n = this.attributes.Count; i < n; i++)
            {
                Attribute a = (Attribute)this.attributes[i];
                if (a.Name == name)
                {
                    this.attributes.RemoveAt(i);
                    return;
                }
            }
        }
        public void CopyAttributes(Node n)
        {
            for (int i = 0, len = n.attributes.Count; i < len; i++)
            {
                Attribute a = (Attribute)n.attributes[i];
                Attribute na = this.AddAttribute(a.Name, a.Value, a.QuoteChar, false);
                na.DtdType = a.DtdType;
            }
        }

        public int AttributeCount
        {
            get
            {
                return this.attributes.Count;
            }
        }

        public int GetAttribute(string name)
        {
            for (int i = 0, n = this.attributes.Count; i < n; i++)
            {
                Attribute a = (Attribute)this.attributes[i];
                if (a.Name == name)
                {
                    return i;
                }
            }
            return -1;
        }

        public Attribute GetAttribute(int i)
        {
            if (i >= 0 && i < this.attributes.Count)
            {
                Attribute a = (Attribute)this.attributes[i];
                return a;
            }
            return null;
        }
    }
}
