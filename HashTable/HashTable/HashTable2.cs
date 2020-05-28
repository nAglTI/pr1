using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public class Items<K, V>
    {
        public K Key 
        { 
            get; set; 
        }
        public V Val 
        { 
            get; set; 
        }
        public Items(K key, V val)
        {
            Key = key; Val = val;
        }
    }
    public class HashTable2<K, V>
    {
        private int size;
        private LinkedList<Items<K, V>>[] items;

        public HashTable2(int size)
        {
            this.size = size;
            items = new LinkedList<Items<K, V>>[size];
        }
        private int gethash(K key)
        {
            return Math.Abs(key.GetHashCode() % size);
        }
        private LinkedList<Items<K, V>> getlist (int index)
        {
            LinkedList<Items<K, V>> gettinglist = items[index];
            if (gettinglist is null)
            {
                gettinglist = new LinkedList<Items<K, V>>();
                items[index] = gettinglist;
            }
            return gettinglist;
        }
        public V Find(K key)
        {
            int index = gethash(key);
            LinkedList<Items<K, V>> list = getlist(index);
            foreach (Items<K, V> item in list.Where(item => item.Key.Equals(key)).Select(item => item))
            {
                return item.Val;
            }

            return default;
        }

        public void Add(K key, V val)
        {
            int index = gethash(key);
            LinkedList<Items<K, V>> list = getlist(index);
            list.AddLast(new Items<K, V>(key, val));
        }

        public void RemoveAll()
        {
            for (int i = 0; i < size; i++)
                items[i].Clear();
        }

        public void Remove(K key)
        {
            int index = gethash(key);
            LinkedList<Items<K, V>> list = getlist(index);
            foreach (Items<K, V> item in list)
            {
                if (item.Key.Equals(key))
                {
                    list.Remove(item);
                }
            }
        }

    }
}
