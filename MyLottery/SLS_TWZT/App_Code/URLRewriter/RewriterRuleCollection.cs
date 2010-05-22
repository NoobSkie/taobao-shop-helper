namespace URLRewriter
{
    using System;
    using System.Collections;
    using System.Reflection;

    [Serializable]
    public class RewriterRuleCollection : CollectionBase
    {
        public virtual void Add(RewriterRule r)
        {
            base.InnerList.Add(r);
        }

        public RewriterRule this[int index]
        {
            get
            {
                return (RewriterRule) base.InnerList[index];
            }
            set
            {
                base.InnerList[index] = value;
            }
        }
    }
}

