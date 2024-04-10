using DataStructuresLibrary;

namespace UnitTest_DataStructures
{
    [TestClass]
    public class ListXTests
    {
        [TestMethod]
        public void AddTest()
        {
            ListX<int> list = new ListX<int>();
            list.Add(1);
            list.Add(3);

            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(3, list[1]);
        }

        [TestMethod]
        public void InsertTest()
        {
            ListX<int> list = new ListX<int>();
            list.Add(1);
            list.Add(2);
            list.Insert(1, 3);

            Assert.AreEqual(3, list[1]);
            Assert.AreEqual(2, list[2]);
        }

        [TestMethod]
        public void RemoveTest()
        {
            ListX<int> list = new ListX<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Remove(2);

            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(3, list[1]);
        }

        [TestMethod]
        public void RemoveAtTest()
        {
            ListX<int> list = new ListX<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.RemoveAt(1);

            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(3, list[1]);
        }

        [TestMethod]
        public void IndexOfTest()
        {
            ListX<int> list = new ListX<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            Assert.AreEqual(1, list.IndexOf(2));
        }

        [TestMethod]
        public void ContainsTest()
        {
            ListX<int> list = new ListX<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            Assert.IsTrue(list.Contains(2));
        }

        [TestMethod]
        public void ClearTest()
        {
            ListX<int> list = new ListX<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Clear();

            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void ReverseTest()
        {
            ListX<int> list = new ListX<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Reverse();

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(3, list[0]);
            Assert.AreEqual(2, list[1]);
            Assert.AreEqual(1, list[2]);
        }
    }
}