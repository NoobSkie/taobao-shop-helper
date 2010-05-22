namespace Shove.HTML.SgmlReader
{
    using System;
    using System.Collections;

    public class Group
    {
        public Group Parent;
        public ArrayList Members;
        public GroupType GroupType;
        public Occurrence Occurrence;
        public bool Mixed;

        public bool TextOnly
        {
            get { return this.Mixed && Members.Count == 0; }
        }

        public Group(Group parent)
        {
            Parent = parent;
            Members = new ArrayList();
            this.GroupType = GroupType.None;
            Occurrence = Occurrence.Required;
        }
        public void AddGroup(Group g)
        {
            Members.Add(g);
        }
        public void AddSymbol(string sym)
        {
            if (sym == "#PCDATA")
            {
                Mixed = true;
            }
            else
            {
                Members.Add(sym);
            }
        }
        public void AddConnector(char c)
        {
            if (!Mixed && Members.Count == 0)
            {
                throw new Exception(
                    String.Format("Missing token before connector '{0}'.", c)
                    );
            }
            GroupType gt = GroupType.None;
            switch (c)
            {
                case ',':
                    gt = GroupType.Sequence;
                    break;
                case '|':
                    gt = GroupType.Or;
                    break;
                case '&':
                    gt = GroupType.And;
                    break;
            }
            if (GroupType != GroupType.None && GroupType != gt)
            {
                throw new Exception(
                    String.Format("Connector '{0}' is inconsistent with {1} group.", c, GroupType.ToString())
                    );
            }
            GroupType = gt;
        }

        public void AddOccurrence(char c)
        {
            Occurrence o = Occurrence.Required;
            switch (c)
            {
                case '?':
                    o = Occurrence.Optional;
                    break;
                case '+':
                    o = Occurrence.OneOrMore;
                    break;
                case '*':
                    o = Occurrence.ZeroOrMore;
                    break;
            }
            Occurrence = o;
        }


        public bool CanContain(string name, SgmlDtd dtd)
        {
            foreach (object obj in Members)
            {
                if (obj is String)
                {
                    if (obj == (object)name) 
                        return true;
                }
            }

            foreach (object obj in Members)
            {
                if (obj is String)
                {
                    string s = (string)obj;
                    ElementDecl e = dtd.FindElement(s);
                    if (e != null)
                    {
                        if (e.StartTagOptional)
                        {
                            if (e.CanContain(name, dtd))
                                return true;
                        }
                    }
                }
                else
                {
                    Group m = (Group)obj;
                    if (m.CanContain(name, dtd))
                        return true;
                }
            }
            return false;
        }
    }
}

