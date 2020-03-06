using System;
using System.Collections.Generic;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Diagnostics.Stopwatch watch, watch1, watch2;
            long elapsedMs;
            int N = 1000000;

            var mystack = new MyStack<int>(N);

            var stack = new Stack<int>();
            watch = System.Diagnostics.Stopwatch.StartNew();
            watch1 = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i != N; i++)
            {
                stack.Push(i);
            }
            watch1.Stop();
            watch2 = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i != N; i++)
            {
                stack.Pop();
            }
            watch2.Stop();
            watch.Stop();

            elapsedMs = watch1.ElapsedMilliseconds;
            Console.WriteLine("Stack: PushTime - {0} ms", elapsedMs);

            elapsedMs = watch2.ElapsedMilliseconds;
            Console.WriteLine("Poptime - {0} ms", elapsedMs);

            elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("Fulltime - {0} ms", elapsedMs);

            Console.WriteLine();
            Console.ReadKey();

            watch = System.Diagnostics.Stopwatch.StartNew();
            watch1 = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i != N; i++)
            {
                mystack.Push(i);
            }
            watch1.Stop();
            watch2 = System.Diagnostics.Stopwatch.StartNew();
            for (int i = 0; i != N; i++)
            {
                mystack.Pop();
            }
            watch2.Stop();
            watch.Stop();

            elapsedMs = watch1.ElapsedMilliseconds;
            Console.WriteLine("MyStack: PushTime - {0} ms;", elapsedMs);

            elapsedMs = watch2.ElapsedMilliseconds;
            Console.WriteLine("Poptime - {0} ms;", elapsedMs);

            elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("Fulltime - {0} ms.", elapsedMs);

            var f = new F(3);

            /////////////////// Обратная польская запись

            void ReversePolish(string notOPZstr)
            {
                MyStack<char> myStack2 = new MyStack<char>();
                string result = string.Empty;

                for (var i = 0; i < notOPZstr.Length; i++)
                {
                    if (char.IsNumber(notOPZstr[i]))
                    {
                        if (i != 0 && !char.IsNumber(notOPZstr[i - 1]))
                            result += ' ';
                        result += notOPZstr[i];
                    }
                    else
                        switch (notOPZstr[i])
                        {
                            case '(':
                                myStack2.Push(notOPZstr[i]);
                                break;
                            case ')':
                            {
                                while (myStack2.Peek() != '(' && SignPrioritet(myStack2.Peek()) >= SignPrioritet(notOPZstr[i]))
                                {
                                    result += $" {myStack2.Peek()}";
                                    myStack2.Pop();
                                }
                                myStack2.Pop();
                                break;
                            }
                            default:
                            {
                                while (!myStack2.IsEmpty() && SignPrioritet(myStack2.Peek()) >= SignPrioritet(notOPZstr[i]))
                                {
                                    result += $" {myStack2.Peek()}";
                                    myStack2.Pop();
                                }
                                myStack2.Push(notOPZstr[i]);
                                break;
                            }
                        }
                }

                while (!myStack2.IsEmpty())
                {
                    result += $" {myStack2.Peek()}";
                    myStack2.Pop();
                }
                Console.WriteLine(result);
            }

            int SignPrioritet(char sign)
            {
                int priority = 0;
                switch (sign)
                {
                    case '^': priority = 3; break;
                    case '*': priority = 2; break;
                    case '/': priority = 2; break;
                    case '+': priority = 1; break;
                    case '-': priority = 1; break;
                }
                return priority;
            }


            Console.ReadKey();
        }

        
    }
}
