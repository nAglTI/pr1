using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 100;

            HashTable1 hashtable1 = new HashTable1(size);

            for (int i = 0; i < size; i++)
            {
                hashtable1.Add(i);
            }

            hashtable1.Remove(3);

            LinkedList<int> list1 = hashtable1.Find(3);


            // тест 2го варианта хэш-таблицы

            HashTable2<int, string> hashtable2 = new HashTable2<int, string>(size);


            hashtable2.Add(1, "1");
            hashtable2.Add(2, "2");
            hashtable2.Add(3, "3");
            hashtable2.Remove(3);
            hashtable2.Add(4, "4");

            string first = hashtable2.Find(1);
            string second = hashtable2.Find(2);
            string fourth = hashtable2.Find(4);
            Console.WriteLine($"{first}, {second}, {fourth}");
            hashtable2.RemoveAll();

            Console.ReadLine();

        }
    }
}
