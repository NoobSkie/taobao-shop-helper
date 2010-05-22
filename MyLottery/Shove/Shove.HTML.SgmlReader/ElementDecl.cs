namespace Shove.HTML.SgmlReader
{
    using System;

    public class ElementDecl
    {
        public Shove.HTML.SgmlReader.AttList AttList;
        public Shove.HTML.SgmlReader.ContentModel ContentModel;
        public bool EndTagOptional;
        public string[] Exclusions;
        public string[] Inclusions;
        public string Name;
        public bool StartTagOptional;

        public ElementDecl(string name, bool sto, bool eto, Shove.HTML.SgmlReader.ContentModel cm, string[] inclusions, string[] exclusions)
        {
            this.Name = name;
            this.StartTagOptional = sto;
            this.EndTagOptional = eto;
            this.ContentModel = cm;
            this.Inclusions = inclusions;
            this.Exclusions = exclusions;
        }

        public void AddAttDefs(Shove.HTML.SgmlReader.AttList list)
        {
            if (this.AttList == null)
            {
                this.AttList = list;
            }
            else
            {
                foreach (AttDef def in list)
                {
                    if (this.AttList[def.Name] == null)
                    {
                        this.AttList.Add(def);
                    }
                }
            }
        }

        public bool CanContain(string name, SgmlDtd dtd)
        {
            if (this.Exclusions != null)
            {
                foreach (string str in this.Exclusions)
                {
                    if (str == name)
                    {
                        return false;
                    }
                }
            }
            if (this.Inclusions != null)
            {
                foreach (string str2 in this.Inclusions)
                {
                    if (str2 == name)
                    {
                        return true;
                    }
                }
            }
            return this.ContentModel.CanContain(name, dtd);
        }

        public AttDef FindAttribute(string name)
        {
            return this.AttList[name.ToUpper()];
        }
    }
}

