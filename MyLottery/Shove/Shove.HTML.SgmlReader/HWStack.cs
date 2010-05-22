using System;
using System.Collections.Generic;
using System.Text;

namespace Shove.HTML.SgmlReader
{
    internal class HWStack
    {
        object[] items;
        int size;
        int count;
        int growth;

        public HWStack(int growth)
        {
            this.growth = growth;
        }

        public int Count
        {
            get { return this.count; }
            set { this.count = value; }
        }
        public int Size
        {
            get { return this.size; }
        }

        public object this[int i]
        {
            get { return (i >= 0 && i < this.size) ? items[i] : null; }
            set { this.items[i] = value; }
        }
        public object Pop()
        {
            this.count--;
            if (this.count > 0)
            {
                return items[this.count - 1];
            }
            return null;
        }

        public object Push()
        {
            if (this.count == this.size)
            {
                int newsize = this.size + this.growth;
                object[] newarray = new object[newsize];
                if (this.items != null)
                    Array.Copy(this.items, newarray, this.size);
                this.size = newsize;
                this.items = newarray;
            }
            return items[this.count++];
        }
        public void RemoveAt(int i)
        {
            this.items[i] = null;
            Array.Copy(this.items, i + 1, this.items, i, this.count - i - 1);
            this.count--;

        }
    }
}
