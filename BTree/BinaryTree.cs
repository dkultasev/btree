using System;
using System.Collections.Generic;
using System.Linq;

namespace BTree
{
    public class Node<T>
    {
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public T Value;
    }
    public class BinaryTree<T> where T : IComparable<T>, IEquatable<T>
    {

        public Node<T> Root { get; set; }
        public T MinValue { get; set; }
        public T MaxValue { get; set; }
        public int Count { get; private set; }

        public void Insert(T value)
        {
            if (Count == 0)
            {
                Root = new Node<T>()
                {
                    Value = value
                };
                MinValue = MaxValue = value;
                Count++;
                return;
            }

            if (Root.Value.Equals(value)) return;
            var tmp = Root;
            while (true)
            {
                if (tmp.Value.CompareTo(value) > 0)
                {
                    if (tmp.Left == null)
                    {
                        tmp.Left = new Node<T>() { Value = value };
                        Count++;
                        break;
                    }
                    tmp = tmp.Left;
                }
                else if (tmp.Value.CompareTo(value) < 0)
                {
                    if (tmp.Right == null)
                    {
                        tmp.Right = new Node<T>() { Value = value };
                        Count++;
                        break;
                    }
                    tmp = tmp.Right;
                }
            }

            SetMinValue(value);
            SetMaxValue(value);
        }



        public void Remove(T value)
        {
            var current = Root;
            var next = current;
            Node<T> toDelete;

            while (true)
            {
                current = next;

                if (current.Value.CompareTo(value) > 0)
                {
                    if (current.Left.Value.Equals(value))
                    {
                        toDelete = GetMinimumFromRight(current.Left);
                        Count--;
                        if (toDelete == null) return;
                        current.Left.Value = toDelete.Value;
                        toDelete = null;
                        return;
                    };
                    next = current.Left;
                }
                else if (current.Value.CompareTo(value) < 0)
                {
                    if (current.Right.Value.Equals(value))
                    {
                        toDelete = GetMinimumFromRight(current.Right);
                        Count--;
                        if (toDelete == null) return;
                        current.Right.Value = toDelete.Value;
                        toDelete = null;
                        return;
                    }
                    ;
                    next = current.Left;
                }
                else
                {
                    current = GetMinimumFromRight(current);
                    Count--;
                    return;
                }
            }
        }

        private void SetMinValue(T value)
        {
            if (value.CompareTo(MinValue) < 0)
            {
                MinValue = value;
            }
        }
        private void SetMaxValue(T value)
        {
            if (value.CompareTo(MaxValue) > 0)
            {
                MaxValue = value;
            }
        }

        public void PrintLevelOrder()
        {
            int h = Height(Root);
            int i;
            for (i = 1; i <= h; i++)
            {
                PrintGivenLevel(Root, i, "");
                Console.WriteLine();
            }
        }

        private int Height(Node<T> root)
        {
            if (root == null)
                return 0;
            else
            {
                int lheight = Height(root.Left);
                int rheight = Height(root.Right);

                if (lheight > rheight)
                    return (lheight + 1);
                else return (rheight + 1);
            }
        }

        private void PrintGivenLevel(Node<T> root, int level, string position)
        {
            if (root == null)
                return;
            if (level == 1)
                Console.Write(position + root.Value + "          ");
            else if (level > 1)
            {
                PrintGivenLevel(root.Left, level - 1, "L(" + root.Value + ") - ");
                PrintGivenLevel(root.Right, level - 1, "R(" + root.Value + ") - ");
            }
        }

        public Node<T> GetMinimumFromRight<T>(Node<T> node)
        {
            if (node.Left == null && node.Right == null) return null;
            if (node.Right == null) return node.Left;
            if (node.Right.Left == null) return node.Right;
            return node.Right.Left;
        }
    }
}