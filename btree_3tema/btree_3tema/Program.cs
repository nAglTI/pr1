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
            var obj = new Btree();

            var rnd = new System.Random(1);
            var init = Enumerable.Range(0, 5).OrderBy(x => rnd.Next()).ToArray();
            foreach (var i in init)
                obj.Insert(i); obj.Insert(10);
            obj.Insert(5);
            obj.Insert(15);
            obj.Insert(8);
            obj.Insert(2);
            obj.Insert(12);
           


            //obj.Print();

            obj.root = obj.buildtree(obj.root);

            obj.Print();


            // var lst = new LinkedList<int>();
            // lst.FindIndex(); // FindIndex List

            // k7k
            // kk6
            // 5kk
            // kk3
            // k2k
            // kk1

            //     10
            //  5     15
            //2  8   12
            obj.Print();

            Console.Read();
        }
    }
}
