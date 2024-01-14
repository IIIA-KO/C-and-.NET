using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.BinaryTrees
{
    public class Node<T> : IEnumerable<T> where T : IComparable
    {
        public T Value { get; set; }
        public Node<T> Left;
        public Node<T> Right;

        public Node() => Left = Right = null;
        public Node(T value) => Value = value;

        public void Add(T value)
        {
            if (Value == null)
                Value = value;
            else if (value.CompareTo(Value) > 0)
            {
                if (Right == null)
                    Right = new Node<T> { Value = value };
                else
                    Right.Add(value);
            }
            else
            {
                if (Left == null)
                    Left = new Node<T> { Value = value };
                else
                    Left.Add(value);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (Left is not null)
                foreach (var node in Left)
                    yield return node;

            if (Value is not null) yield return Value;

            if (Right is not null)
                foreach (var node in Right)
                    yield return node;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class BinaryTree<T> : IEnumerable<T> where T : IComparable
    {
        private Node<T> Root { get; set; }

        public T Value => Root.Value;
        public Node<T> Left => Root.Left;
        public Node<T> Right => Root.Right;

        public BinaryTree() => Root = null;

        public void Add(T newValue)
        {
            if (Root == null)
                Root = new Node<T> { Value = newValue };
            else
                Root.Add(newValue);
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (Root is null)
                return Enumerable.Empty<T>().GetEnumerator();
            return Root.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public static class BinaryTree
    {
        public static BinaryTree<T> Create<T>(params T[] arr) where T : IComparable
        {
            BinaryTree<T> Tree = new();
            foreach (var item in arr) Tree.Add(item);
            return Tree;
        }
    }

}
