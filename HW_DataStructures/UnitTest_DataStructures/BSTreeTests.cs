using DataStructuresLibrary;

namespace UnitTest_DataStructures
{
    [TestClass]
    public class BSTreeTests
    {
        [TestMethod]
        public void AddTest()
        {
            BSTree<int> tree = new BSTree<int>(5);
            tree.Add(3);
            tree.Add(7);

            Assert.AreEqual(3, tree.Left.Value);
            Assert.AreEqual(7, tree.Right.Value);
        }

        [TestMethod]
        public void ContainsTest()
        {
            BSTree<int> tree = new BSTree<int>(5);
            tree.Add(3);
            tree.Add(7);

            Assert.IsTrue(tree.Contains(3));
            Assert.IsTrue(tree.Contains(7));
            Assert.IsFalse(tree.Contains(4));
        }

        [TestMethod]
        public void CountTest()
        {
            BSTree<int> tree = new BSTree<int>(5);
            tree.Add(3);
            tree.Add(7);

            Assert.AreEqual(3, tree.Count);
        }

        [TestMethod]
        public void AddTest2()
        {
            BSTree<int> tree = new BSTree<int>(5);
            tree.Add(3);
            tree.Add(7);
            tree.Add(4);

            Assert.AreEqual(4, tree.Left.Right.Value);
        }

        [TestMethod]
        public void ClearTest()
        {
            BSTree<int> tree = new BSTree<int>(5);
            tree.Add(3);
            tree.Add(7);
            tree.Clear();

            Assert.AreEqual(0, tree.Count);
        }

        [TestMethod]
        public void ToArrayTest()
        {
            BSTree<int> tree = new BSTree<int>(5);
            tree.Add(3);
            tree.Add(7);
            tree.Add(4);
            tree.Add(6);
            tree.Add(7);

            Assert.AreEqual(6, tree.Count);

            int[] array = tree.ToArray();

            Assert.AreEqual(5, array[0]);
            Assert.AreEqual(3, array[1]);
            Assert.AreEqual(4, array[2]);
            Assert.AreEqual(7, array[3]);
            Assert.AreEqual(6, array[4]);
            Assert.AreEqual(7, array[5]);

        }
    }
}