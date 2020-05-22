using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVL_Tree
{
    public class AVL_Tree<T> where T : IComparable<T>
    {
        private Node<T> root;
        public int Size { get; set; }

        public void Insert(T key)
        {
            root = insert(root, key);
        }

        private Node<T> insert(Node<T> node, T key)
        {
            if (node == null)
            {
                Size++;
                return new Node<T> { Key = key };
            }

            int result = key.CompareTo(node.Key);

            if (result < 0)
                node.Left = insert(node.Left, key);
            else if (result > 0)
                node.Right = insert(node.Right, key);
            else
                return node;

            return balance(node);
        }

        private static Node<T> balance(Node<T> node)
        {
            fixHeight(node);
            switch (BalanceFactor(node))
            {
                case 2:
                    {
                        if (BalanceFactor(node.Right) < 0)
                            node.Right = RotateRight(node.Right);
                        return RotateLeft(node);
                    }
                case -2:
                    {
                        if (BalanceFactor(node.Left) > 0)
                            node.Left = RotateLeft(node.Left);
                        return RotateRight(node);
                    }
                default:
                    return node;
            }
        }

        private static int BalanceFactor(Node<T> node)
        {
            return Height(node.Right) - Height(node.Left);
        }

        public bool Contains(T key)
        {
            Node<T> cur_node = root;

            while (cur_node != null)
            {
                int result = key.CompareTo(cur_node.Key);

                if (result < 0)
                    cur_node = cur_node.Left;
                else if (result > 0)
                    cur_node = cur_node.Right;
                else
                    return true;
            }

            return false;
        }

        public void Remove(T key)
        {
            root = remove(root, key);
        }

        private Node<T> remove(Node<T> node, T key)
        {
            if (node == null)
                return null;

            int res = key.CompareTo(node.Key);

            if (res < 0)
                node.Left = remove(node.Left, key);
            else if (res > 0)
                node.Right = remove(node.Right, key);
            else
            {
                Node<T> left = node.Left;
                Node<T> right = node.Right;

                Size--;

                if (right == null)
                    return left;

                Node<T> min = FindMinNode(right);

                min.Right = RemoveMin(right);
                min.Left = left;

                return balance(min);
            }

            return balance(node);
        }

        public void Clear()
        {
            root = null;
        }

        public override string ToString()
        {
            return toStringHelper(root).Item2;
        }

        private static (int, string) toStringHelper(Node<T> n)
        {
            if (n == null)
            {
                return (1, "\n");
            }

            var (leftSize, leftString) = toStringHelper(n.Left);
            var (rightSize, rightString) = toStringHelper(n.Right);

            var objString = n.Key.ToString();

            var stringBuilder = new StringBuilder();

            stringBuilder.Append(' ', leftSize - 1);
            stringBuilder.Append(objString);
            stringBuilder.Append(' ', rightSize - 1);
            stringBuilder.Append('\n');

            var i = 0;

            while (i * leftSize < leftString.Length && i * rightSize < rightString.Length)
            {
                stringBuilder.Append(leftString, i * leftSize, leftSize - 1);
                stringBuilder.Append(' ', objString.Length);
                stringBuilder.Append(rightString, i * rightSize, rightSize);

                ++i;
            }

            while (i * leftSize < leftString.Length)
            {
                stringBuilder.Append(leftString, i * leftSize, leftSize - 1);
                stringBuilder.Append(' ', objString.Length + rightSize - 1);
                stringBuilder.Append('\n');

                ++i;
            }

            while (i * rightSize < rightString.Length)
            {
                stringBuilder.Append(' ', leftSize + objString.Length - 1);
                stringBuilder.Append(rightString, i * rightSize, rightSize);

                ++i;
            }

            return (leftSize + objString.Length + rightSize - 1, stringBuilder.ToString());
        }

        private static void fixHeight(Node<T> node)
        {
            var left = Height(node.Left);
            var right = Height(node.Right);

            node.Height = Math.Max(left, right) + 1;
        }

        private static int Height(Node<T> node)
        {
            if (node == null)
                return 0;
            return node.Height;
        }

        private static Node<T> RotateLeft(Node<T> node)
        {
            Node<T> right = node.Right;
            node.Right = right.Left;
            right.Left = node;

            fixHeight(node);
            fixHeight(right);
            return right;
        }

        private static Node<T> RotateRight(Node<T> node)
        {
            Node<T> left = node.Left;
            node.Left = left.Right;
            left.Right = node;

            fixHeight(node);
            fixHeight(left);
            return left;
        }

        private static Node<T> FindMinNode(Node<T> node)
        {
            if (node != null)
            {
                while (node.Left != null)
                {
                    node = node.Left;
                }
            }
            return node;
        }

        private static Node<T> RemoveMin(Node<T> node)
        {
            if (node.Left == null)
            {
                return node.Right;
            }

            node.Left = RemoveMin(node.Left);

            return balance(node);
        }
    }
}
