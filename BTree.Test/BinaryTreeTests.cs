using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BTree.Test
{
    [TestClass]
    public class BinaryTreeTests
    {
        [TestMethod]
        public void TestWhenIntegersInsertedQtyIsRight()
        {
            var b = new BinaryTree<int>();
            b.Insert(17);
            b.Insert(1);
            b.Insert(10);
            b.Insert(5);
            b.Insert(17);
            b.Insert(9);
            b.Insert(20);
            
            Assert.AreEqual(b.Count, 6);
        }

        [TestMethod]
        public void TestWhenIntegerValuesIsRemovedQtyIsRight()
        {
            var b = new BinaryTree<int>();
            b.Insert(17);
            b.Insert(1);
            b.Insert(10);
            b.Insert(5);
            b.Insert(17);
            b.Insert(9);
            b.Insert(20);

            b.Remove(17);
            b.Remove(20);

            Assert.AreEqual(b.Count, 4);

        }

        [TestMethod]
        public void TestThanGreaterValueIsInsertedToTheRight()
        {
            var b = new BinaryTree<int>();
            b.Insert(1);
            b.Insert(10);

            Assert.AreEqual(b.Root.Right.Value, 10);
        }

        [TestMethod]
        public void TestWhenMultipleValuesInsertedThenFirstElementIsInsertedItSetAsRoot()
        {
            var b = new BinaryTree<int>();
            b.Insert(1);
            b.Insert(20);

            Assert.AreEqual(b.Root.Value, 1);
        }

        [TestMethod]
        public void TestWhenMultipleValuesInsertedThenMinValueIsUpdated()
        {
            var b = new BinaryTree<int>();
            b.Insert(10);
            b.Insert(20);
            b.Insert(1);
            b.Insert(2);

            Assert.AreEqual(b.MinValue, 1);
        }

        [TestMethod]
        public void TestWhenMultipleValuesInsertedThenMaxValueIsUpdated()
        {
            var b = new BinaryTree<int>();
            b.Insert(10);
            b.Insert(20);
            b.Insert(1);
            b.Insert(2);

            Assert.AreEqual(b.MaxValue, 20);
        }

        [TestMethod]
        public void Print()
        {
            var b = new BinaryTree<int>();
            b.Insert(6);
            b.Insert(7);
            b.Insert(9);
            b.Insert(4);
            b.Insert(5);

            b.Insert(10);
            b.Insert(3);

            b.Remove(4);
            b.PrintLevelOrder();
        }

        [TestMethod]
        public void TestWhenNodeWithNoRightDeletedThenLeftNodeTakesPlace()
        {
            var b = new BinaryTree<int>();
            b.Insert(6);
            b.Insert(5);
            b.Insert(7);
            b.Insert(9);
            b.Insert(4);
            b.Insert(10);
            b.Insert(3);

            b.Remove(4);

            Assert.AreEqual(b.Root.Left.Left.Value,3);
        }

        [TestMethod]
        public void TestWhenMinimalRightIsOnThe2ndLevel()
        {
            var b = new BinaryTree<int>();
            b.Insert(6);
            b.Insert(5);
            b.Insert(8);
            b.Insert(7);
            b.Insert(9);
            b.Insert(4);
            b.Insert(10);
            b.Insert(3);

            Assert.AreEqual(b.GetMinimumFromRight(b.Root), b.Root.Right.Left);
        }


        [TestMethod]
        public void TestRemoveWhenMinimalIsRoot()
        {
            var b = new BinaryTree<int>();
            b.Insert(6);
            b.Insert(5);
            b.Insert(4);
            b.Insert(3);


            Assert.AreEqual(b.GetMinimumFromRight(b.Root), b.Root.Left);
        }

        [TestMethod]
        public void TestWhenMinimalSubNodeWithNoLeft()
        {
            var b = new BinaryTree<int>();
            b.Insert(6);
            b.Insert(5);
            b.Insert(8);
            b.Insert(7);
            b.Insert(9);
            b.Insert(4);
            b.Insert(10);
            b.Insert(3);

            Assert.AreEqual(b.GetMinimumFromRight(b.Root.Right.Right), b.Root.Right.Right.Right);
        }

        [TestMethod]
        public void TestWhenMinimalSubNodeWithNoRight()
        {
            var b = new BinaryTree<int>();
            b.Insert(6);
            b.Insert(5);
            b.Insert(8);
            b.Insert(7);
            b.Insert(9);
            b.Insert(4);
            b.Insert(10);
            b.Insert(3);

            Assert.AreEqual(b.GetMinimumFromRight(b.Root.Left.Left), b.Root.Left.Left.Left);
        }

        [TestMethod]
        public void TestWhenMinimalSubNodeWithRight()
        {
            var b = new BinaryTree<int>();
            b.Insert(6);
            b.Insert(8);
            b.Insert(7);
            b.Insert(9);
            b.Insert(4);
            b.Insert(5);
            b.Insert(10);
            b.Insert(3);

            Assert.AreEqual(b.GetMinimumFromRight(b.Root.Left), b.Root.Left.Right);
        }

        [TestMethod]
        public void TestWhenLeftNodeWithLRIsDeleted()
        {
            var b = new BinaryTree<int>();
            b.Insert(6);
            b.Insert(7);
            b.Insert(9);
            b.Insert(4);
            b.Insert(5);

            b.Insert(10);
            b.Insert(3);

            b.Remove(4);

            Assert.AreEqual(b.Root.Left.Left.Value, 3);
        }

        [TestMethod]
        public void Test_Always_Run()
        {
            var b = new BinaryTree<MyInt>();

            b.Insert(new MyInt(1));
            b.Insert(new MyInt(1));

            Assert.AreEqual(b.Count, 1);
        }

        class MyInt : IComparable<MyInt>, IEquatable<MyInt>
        {
            public MyInt(int value)
            {
                Value = value;
            }

            private int Value { get; set; }
            public int CompareTo(MyInt other)
            {
                return Value.CompareTo(other.Value);
            }

            public bool Equals(MyInt other)
            {
                return other != null && Value.Equals(other.Value);
            }
        }
    }
}


