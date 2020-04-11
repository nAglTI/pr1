using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btree_3tema
{
    class BTree
    {
        public Node root;
        public BTree()
        {

        }

        public void Insert(int x)
        {
            if (root == null)
                root = new Node(x);
            else
                insert(root, x);
        }
        private void insert(Node p, int x)
        {
            if (x < p.Val)
                if (p.left != null)
                    insert(p.left, x);
                else
                    p.left = new Node(x);
            else
                if (p.right != null)
                    insert(p.right, x);
                else
                    p.right = new Node(x);
        }

        public void Print()
        {
            print(root, 0);
        }

        private void print(Node p, int shift)
        {
            if (p.right != null)
                print(p.right, shift + 1);

            for (int i = 0; i != shift; i++)
                Console.Write("k");
            Console.WriteLine(p.Val);

            if (p.left != null)
                print(p.left, shift + 1);
        }

        public void store(Node p, List<Node> nodes)
        {
            if (p == null)
                return;
            store(p.left, nodes);
            nodes.Add(p);
            store(p.right, nodes);
        }
        public Node buildtree(Node p)
        {
            var nodes = new List<Node>();
            store(p, nodes);
            return buildit(nodes, 0, nodes.Count - 1);
        }
        public Node buildit(List<Node> nodes, int start, int end)
        {
            if (start > end)
                return null;
            int mid = (start + end) / 2;
            Node p = nodes[mid];
            p.left = buildit(nodes, start, mid - 1);
            p.right = buildit(nodes, mid + 1, end);
            return p;
        }
    }
}
