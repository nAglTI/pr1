using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQueue_Очередь_
{
    class QueueList2<T> where T : IEquatable<T>
    {
        public Node2<T> head;
        public Node2<T> tail;
        public int Count;
        public T this[int index]
        {
            get
            {
                Node2<T> current = head;
                for (int i = 0; i != index && current != null; i++)
                    current = current.Next;
                return current.Value;

            }
            set
            {
                Node2<T> current = head;
                for (int i = 0; i != index && current != null; i++)
                    current = current.Next;
                current.Value = value;
            }
        }

        public QueueList2()
        {

        }

        public T First()
        {
            T num = head.Value;
            Remove(0);
            return num;
        }
        public T Peek()
        {
            return head.Value;
        }
        public T Last()
        {
            return tail.Value;
        }
        

        public void Clear()
        {
            head = null;
            tail = null;
            Count = 0;
        }

        public int Size()
        {
            return Count;
        }

        public void AddLast(T x)
        {
            var toAdd = new Node2<T>(x);
            
            if (head == null)
            {
                head = toAdd;
            }
            else
            {
                tail.Next = toAdd;
                toAdd.Previous = tail;
            }
            tail = toAdd;
            Count++;
        }

        public void Remove(int index)
        {
            if (head != null)
            {
                if (index == 0)
                {
                    head = head.Next;
                }
                else if (index == Count - 1)
                {
                    tail = tail.Previous;
                }
                else if (index < Count - 1)
                {
                    Node2<T> current = head;
                    for (int i = 0; i < index - 1 && current != null; i++)
                    {
                        current = current.Next;
                    }
                    current.Next.Previous = current.Previous;
                    current.Previous.Next = current.Next;
                }
                Count--;
            }
        }

    }
}
