using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_Односвязн
{
    class Node
    {
        public int value;
        public Node next;

        public Node(int x)
        {
            value = x;
            //next = null;
        }
    }

    class LList
    {
        public Node head;
        public int Count;
        public int this[int index]
        {
            get
            {
                Node current = head;
                for (int i = 0; i != index && current != null; i++)
                    current = current.next;
                return current.value;

            }
            set
            {
                Node current = head;
                for (int i = 0; i != index && current != null; i++)
                    current = current.next;
                current.value = value;
            }
        }

        public LList()
        {

        }

        public void Insert(int index, int x)
        {
            if (head == null)
            {
                var toAdd = new Node(x);
                head = toAdd;
                Count++;
            }
            else
            {
                if (index == 0)
                {
                    AddFirst(x);
                }
                else
                {
                    var toAdd = new Node(x);
                    Node current = head;
                    Node previous = head;
                    for (int i = 0; i < index; i++)
                    {
                        previous = current;
                        current = current.next;
                    }
                    previous.next = toAdd;
                    toAdd.next = current;
                }
                Count++;
            }
        }

        public void Clear()
        {
            head = null;
            Count = 0;
        }

        public void AddFirst(int x)
        {
            var toAdd = new Node(x);
            toAdd.next = head;
            head = toAdd;
            Count++;
        }

        public void AddLast(int x)
        {
            var toAdd = new Node(x);
            if (head == null)
            {
                head = toAdd;
            }
            else
            {
                Node current = head;
                while (current.next != null)
                    current = current.next;
                current.next = toAdd;
            }
            Count++;
        }

        public void Remove(int index)
        {
            if (head != null)
            {
                if (index == 0)
                {
                    head = head.next;
                    Count--;
                }
                else if (index < Count - 1)
                {
                    Node current = head;
                    for (int i = 0; i < index - 1 && current != null; i++)
                    {
                        current = current.next;
                    }
                    current.next = current.next.next;
                    Count--;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var lst = new LList();
            lst.AddLast(1);
            lst.AddLast(2);
            lst.AddLast(3);
            lst.AddLast(4);
            //lst.AddFirst(100);
            //lst.Insert(2, 6);
            lst.Remove(2);

            for (int i = 0; i != lst.Count; i++)
            {
                Console.Write(lst[i] + " -> ");
            }

            //Console.WriteLine(lst.head.value);
            //Console.WriteLine(lst.head.next.value);
            //Console.WriteLine(lst.head.next.next.value);
            Console.ReadLine();
        }
    }
}
