using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class F
    {
        public F(int n)
        {
            var stack = new MyStack<int>(n);
            int num = n;
            while (stack.Count() != n)
            {
                if (num > 0)
                {
                    stack.Push(num--);
                    Console.WriteLine(stack.Peek());
                }

            }
            while (!stack.IsEmpty())
            {
                Console.WriteLine(stack.Pop().ToString());
            }
        }


    }
}
