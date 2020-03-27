using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyQueue_Очередь_
{
    class Node2<T> where T : IEquatable<T>
    {
        public T Value { get; set; }
        public Node2<T> Previous { get; set; }
        public Node2<T> Next { get; set; }

        public Node2(T x)
        {
            Value = x;
        }
    }
}
