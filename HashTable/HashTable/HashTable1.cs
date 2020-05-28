using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class HashTable1
    {
        private int size;
        private LinkedList<int>[] items;

        public HashTable1(int size)
        {
            this.size = size;
            items = new LinkedList<int>[size];
        }

        private int gethash(int val)
        {
            return val % size;
        }

        public LinkedList<int> Find(int key)
        {
            return items[key];
        }

        public void Add(int val)
        {
            int index = gethash(val);
            items[index].AddLast(val);
        }

        public void RemoveAll()
        {
            for (int i = 0; i < size; i++)
                items[i].Clear();
        }

        public void Remove(int key)
        {
            items[key].Clear();
        }
    }
}
