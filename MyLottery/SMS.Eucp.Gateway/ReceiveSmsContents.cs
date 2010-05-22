namespace SMS.Eucp.Gateway
{
    using System;
    using System.Collections;
    using System.Reflection;

    public class ReceiveSmsContents
    {
        private ArrayList list = new ArrayList();

        public void Add(string FromMobile, string Content)
        {
            this.list.Add(new SMS(FromMobile, Content));
        }

        public void Clear()
        {
            this.list.Clear();
        }

        public int Count
        {
            get
            {
                return this.list.Count;
            }
        }

        public SMS this[int Index]
        {
            get
            {
                if ((Index >= 0) && (Index < this.Count))
                {
                    return (SMS) this.list[Index];
                }
                return null;
            }
        }
    }
}

