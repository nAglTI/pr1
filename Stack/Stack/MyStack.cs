using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class MyStack<T>
    {
        private T[] array;
        private int count, num = 10;
        private T num1;

        public MyStack()
        {
            array = new T[num];
        }
        public MyStack(int n)
        {
            array = new T[n]; num = n;
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        public int Count()
        {
            return count;
        }

        public void Push(T x)
        {
            if (count == num)
                throw new Exception("StackOverflow");
            array[count++] = x;
        }

        public T Pop()
        {
            if (count == 0)
                throw new Exception("StackIsEmpty");
            num1 = array[--count];
            array[count] = default;
            return num1;
        }

        public T Peek()
        {
            if (count == 0)
                return default;
            return array[count - 1];
        }
    }
}
