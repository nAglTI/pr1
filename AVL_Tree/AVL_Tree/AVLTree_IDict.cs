using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVL_Tree
{
    public class AVLTree_IDict<TKey, TValue> : IDictionary<TKey, TValue>
        where TKey : IComparable<TKey>
    {
        private class Node
        {
            public Node left;
            public Node right;

            public TKey key;
            public TValue value;
            public int Height = 1;
            public Node(TKey k, TValue v)
            {
                key = k;
                value = v;
            }
        }

        private Node root;
        private int count = 0;



        int height(Node n)
        {
            return n != null ? n.Height : 0;
        }

        int balfactor(Node n)
        {
            return height(n.right) - height(n.left);
        }

        void fixheight(Node n)
        {
            int hleft = height(n.left);
            int hright = height(n.right);

            n.Height = Math.Max(hleft, hright) + 1;
        }

        Node RotateR(Node n)
        {
            Node g = n.left;
            n.left = g.right;
            g.right = n;
            fixheight(n); fixheight(g);
            return g;
        }

        Node RotateL(Node g)
        {
            Node n = g.right;
            g.right = n.left;
            n.left = g;
            fixheight(g); fixheight(n);
            return n;
        }

        Node balance(Node n)
        {
            fixheight(n);
            if (balfactor(n) == 2)
            {
                if (balfactor(n.right) < 0)
                    n.right = RotateR(n.right);
                return RotateL(n);
            }
            else if (balfactor(n) == -2)
            {
                if (balfactor(n.left) < 0)
                    n.left = RotateL(n.left);
                return RotateR(n);
            }
            return n;
        }

        Node insert(Node n, TKey k, TValue val)
        {
            if (n == null)
            {
                count++;
                return new Node(k, val);
            }
            int compare = k.CompareTo(n.key);

            if (compare < 0)
                n.left = insert(n.left, k, val);
            else if (compare > 0)
                n.right = insert(n.right, k, val);
            else
                return n;

            return balance(n);
        }

        public TValue this[TKey key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ICollection<TKey> Keys => throw new NotImplementedException();

        public ICollection<TValue> Values => throw new NotImplementedException();

        public int Count => count;

        public bool IsReadOnly => false;

        public void Add(TKey key, TValue value)
        {
            root = insert(root, key, value);
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            root = insert(root, item.Key, item.Value);
        }

        public void Clear()
        {
            root = null;
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            Node node = root;

            while (node != null)
            {
                int compK = item.Key.CompareTo(node.key); 
                bool compV = item.Value.Equals(node.value);

                if (compK < 0)
                    node = node.left;
                else if (compK > 0)
                    node = node.right;
                else
                    return compV;
            }
            return false;
        }

        public bool ContainsKey(TKey key)
        {
            Node node = root;

            while (node != null)
            {
                int compare = key.CompareTo(node.key);

                if (compare < 0)
                    node = node.left;
                else if (compare > 0)
                    node = node.right;
                else
                    return true;
            }

            return false;
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        Node findmin(Node n)
        {
            if (n.left != null)
                findmin(n.left);
            return n;
        }

        Node removemin(Node n)
        {
            if (n.left == null)
                return n.right;
            n.left = removemin(n.left);
            return balance(n);
        }

        Node removeK(Node n, TKey k)
        {
            if (n == null)
                return n;

            int compare = k.CompareTo(n.key);
            if (compare < 0)
                n.left = removeK(n.left, k);
            else if (compare > 0)
                n.right = removeK(n.right, k);
            else
            {
                Node l = n.left;
                Node r = n.right;
                count--;
                if (r == null)
                    return l;
                Node min = findmin(r);
                min.right = removemin(r);
                min.left = l;
                return balance(min);
            }
            return balance(n);
        }

        Node removeKV(Node n, TKey k, TValue v)
        {
            if (n == null)
                return n;

            int compare = k.CompareTo(n.key);
            if (compare < 0)
                n.left = removeKV(n.left, k, v);
            else if (compare > 0)
                n.right = removeKV(n.right, k, v);
            else
            {
                bool compV = v.Equals(n.value);
                if (compV)
                {
                    Node l = n.left;
                    Node r = n.right;
                    count--;
                    if (r == null)
                        return l;
                    Node min = findmin(r);
                    min.right = removemin(r);
                    min.left = l;
                    return balance(min);
                }
                return null;
            }
            return balance(n);
        }

        public bool Remove(TKey key)
        {
            Node GG = removeK(root, key);
            if (GG != null)
                return true;
            return false;
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            TKey k = item.Key;
            TValue v = item.Value;

            Node GG = removeKV(root, k, v);
            if (GG != null)
                return true;
            return false; ;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
