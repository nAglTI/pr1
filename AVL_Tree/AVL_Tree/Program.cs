using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVL_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            var avl = new AVLTree_IDict<int, bool>();

            avl.Add(23, true);
            avl.Add(19, true);
            avl.Add(228, false);
            avl.Add(1, true);
            avl.Add(23, false);



            avl.Remove(228);
            avl.Remove(new KeyValuePair<int, bool>(19, true));


        }
    }
}
