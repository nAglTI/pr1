using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btree_3tema
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new BTree();

            var rnd = new System.Random(1);
            var init = Enumerable.Range(0, 5).OrderBy(x => rnd.Next()).ToArray();
            foreach (var i in init)
                obj.Insert(i); obj.Insert(10);
            obj.Insert(5);
            obj.Insert(15);
            obj.Insert(8);
            obj.Insert(2);
            obj.Insert(12);

            obj.Print();

            Console.Read();
        }
    }
}
