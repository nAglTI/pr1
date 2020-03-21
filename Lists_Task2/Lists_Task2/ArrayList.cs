using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists_Task2
{
    class MyList<T>
    {
        private T[] array;
        public int Count { get; private set; }
        public MyList()
        {
            array = new T[Count];
        }

        public IEnumerator GetEnumerator()
        {
            return array.GetEnumerator();
        }

        public T this[int index]
        {
            get => array[index];
            set => array[index] = value;
        }

        public void Add(T item)
        {
            Array.Resize(ref array, Count + 1);
            array[Count++] = item;
        }
        
        public void Insert(int index, T item)
        {
            Array.Resize(ref array, Count + 1);
            for (int i = Count - 1; i >= index; i--)
                array[i + 1] = array[i];
            array[index] = item;
            ++Count;
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < Count - 1; i++)
                array[i] = array[i + 1];
            Array.Resize(ref array, --Count);
        }

        public T Last()
        {
            return array[Count - 1];
        }

        public T First()
        {
            return array[0];
        }

        public void Clear()
        {
            Count = 0;
            Array.Resize(ref array, Count);
        }

        public int Size()
        {
            return Count;
        }

        
    }
}
