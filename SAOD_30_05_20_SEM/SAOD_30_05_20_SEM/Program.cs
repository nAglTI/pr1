using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAOD_30_05_20_SEM
{
    class Program
    {
        static void Main(string[] args)
        {
            var llist = new LinkedList<int>();

            llist.AddLast(1488);
            llist.AddLast(228);
            llist.AddLast(3);
            llist.AddLast(666);

            Console.WriteLine(llist.IndexOf(228));
            Console.WriteLine(llist.IndexOf(1488));
            Console.WriteLine(llist.IndexOf(2));
            Console.WriteLine(llist.IndexOf(-1));
        }
    }

    public static class IndexOfnerGGWP
    {
        public static int IndexOf<T>(this LinkedList<T> FList, T val)
        {
            int index = 0;

            foreach (T value in FList)
            {
                if (value.Equals(val))
                {
                    return index;
                }

                index++;
            }
            return -1;
        }
    }
}
