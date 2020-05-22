using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVL_Tree
{
    public class Node<T>
    {
        public T Key;
        public int Height = 1;
        public Node<T> Left;
        public Node<T> Right;
    }
}
