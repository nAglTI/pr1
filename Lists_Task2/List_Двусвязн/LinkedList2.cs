using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_Двусвязн
{
    class LinkedList2<T> where T : IEquatable<T>
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

        public LinkedList2()
        {

        }

        public T First()
        {
            return head.Value;
        }

        public T Last()
        {
            return tail.Value;
        }
        public void Insert(int index, T x)
        {
            if (head == null)
            {
                var toAdd = new Node2<T>(x);
                head = toAdd;
                tail = toAdd;
            }
            else
            {
                if (index == 0)
                    AddFirst(x);
                else if (index == Count - 1)
                    AddLast(x);
                else
                {
                    var toAdd = new Node2<T>(x);
                    Node2<T> current = head;
                    Node2<T> previous = head;
                    for (int i = 0; i < index; i++)
                    {
                        previous = current;
                        current = current.Next;
                    }
                    previous.Next = toAdd;
                    toAdd.Previous = previous;
                    toAdd.Next = current;
                    current.Previous = toAdd;
                }
            }
            Count++;
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

        public int IndexOf(T x)
        {
            if (x.Equals(head.Value))
                return 0;
            else if (x.Equals(tail.Value))
                return Count - 1;
            else
            {
                int index = 1;
                Node2<T> current = head.Next;
                for (int i = 0; i < Count - 1 && current != null; i++)
                {
                    if (x.Equals(current.Value))
                        return index;
                    current = current.Next;
                    ++index;
                }
                return 404;
            }
        }
        public void AddFirst(T x)
        {
            var toAdd = new Node2<T>(x);
            toAdd.Next = head;
            head = toAdd;
            if (Count == 0)
                tail = head;
            else
                toAdd.Next.Previous = toAdd;
            Count++;
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
