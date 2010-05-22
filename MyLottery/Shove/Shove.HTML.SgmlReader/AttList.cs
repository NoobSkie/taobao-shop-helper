namespace Shove.HTML.SgmlReader
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class AttList : IEnumerable
    {
        Hashtable AttDefs;

        public AttList()
        {
            AttDefs = new Hashtable();
        }

        public void Add(AttDef a)
        {
            AttDefs.Add(a.Name, a);
        }

        public AttDef this[string name]
        {
            get
            {
                return (AttDef)AttDefs[name];
            }
        }

        public IEnumerator GetEnumerator()
        {
            return AttDefs.Values.GetEnumerator();
        }
    }
}

