using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQueue_Очередь_
{
    class Queue<T> where T : IEquatable<T>
    {
        private QueueList2<T> list;

        public Queue()
        {

        }

        public void Enqueue(T x)
        {
            list.AddLast(x);
        }

        public T Dequeue()
        {
            return list.First();
        }

        public T Peek()
        {
            return list.Peek();
        }

        public int Size()
        {
            return list.Size();
        }
    }
}
