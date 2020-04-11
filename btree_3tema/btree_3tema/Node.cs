using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btree_3tema
{
    public class Node
    {
        private int val;
        public Node left;
        public Node right;

        public int Val { get => val; set => val = value; }

        public Node(int x)
        {
            Val = x;
        }
    }
}
