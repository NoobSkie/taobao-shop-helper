namespace Shove.WordSplit
{
    using System;
    using System.Collections;
    using System.Runtime.InteropServices;

    [Serializable, StructLayout(LayoutKind.Sequential)]
    public struct WordsList
    {
        public ArrayList m_List;
        static WordsList()
        {
        }
    }
}

