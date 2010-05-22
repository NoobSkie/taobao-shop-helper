namespace Shove._Net.Ftp
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;

    [Serializable]
    public class TransProcessCollection : ICollection<TransmissionProcess>, IEnumerable<TransmissionProcess>, IEnumerable
    {
        private List<TransmissionProcess> transProcessList = new List<TransmissionProcess>();

        public void Add(TransmissionProcess item)
        {
            this.transProcessList.Add(item);
        }

        public void Clear()
        {
            this.transProcessList.Clear();
        }

        public bool Contains(TransmissionProcess item)
        {
            return this.transProcessList.Contains(item);
        }

        public void CopyTo(TransmissionProcess[] array, int arrayIndex)
        {
            this.transProcessList.CopyTo(array, arrayIndex);
        }

        public IEnumerator<TransmissionProcess> GetEnumerator()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(TransmissionProcess item)
        {
            return this.transProcessList.Remove(item);
        }

        public int Count
        {
            get
            {
                return this.transProcessList.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public TransmissionProcess this[int index]
        {
            get
            {
                return this.transProcessList[index];
            }
            set
            {
                this.transProcessList[index] = value;
            }
        }

        public List<TransmissionProcess> TransProcessList
        {
            get
            {
                return this.transProcessList;
            }
            set
            {
                this.transProcessList = value;
            }
        }
    }
}

