using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists_Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<object> list1 = new MyList<object>();

            for (int i = 0; i < 11; i++)
                list1.Add(i);

            Console.WriteLine(list1.First());
            Console.WriteLine(list1.Last());
            Console.WriteLine();

            list1.RemoveAt(4);
            list1.Insert(3, 4);
            
            Console.WriteLine();
            foreach (var item in list1)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
