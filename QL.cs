using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _102210105
{
    internal class QL<T>
    {
        private T[] list;
        private int length;
        public int GetLength() { return length; }
        public int IndexOf(T item) 
        {
            for(int i = 0; i < this.length; ++i)
            {
                if (list[i].Equals(item)) return i;
            }
            return -1;
        }
        public T At(int index)
        {
            return this.list[index];
        }
        public void InsertAt(T item, int index)
        {
            T[] newList = new T[this.length + 1];
            for (int i = 0; i < index; ++i)
            {
                newList[i] = list[i];
            }
            newList[index] = item;
            for (int i = index + 1; i < this.length; ++i)
            {
                newList[i] = list[i - 1];
            }
            this.list = newList;
            this.length++;
        }
        public void Insert(T item)
        {
            InsertAt(item, length);
        }
        public void RemoveAt(int index)
        {
            T[] newList = new T[this.length - 1];
            for (int i = 0; i < index; ++i)
            {
                newList[i] = list[i];
            }
            for(int i = index; i < this.length; ++i)
            {
                newList[i] = list[i + 1];
            }
            this.list = newList;
            this.length--;
        }
        public void RemoveAll()
        {
            T[] newList = new T[0];
            this.list = newList;
        }
       

    }
}
