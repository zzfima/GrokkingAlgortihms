using BinarySearch;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[] array = { 4, 5, 6, 8, 33, 55, 77, 88, 4343 };
            Assert.AreEqual(BinarySearcher.Search(array, 55), 5);
        }

        [TestMethod]
        public void TestMethod2()
        {
            int[] array = { 4, 5, 6, 8, 33, 55, 77, 88, 4343, 6565 };
            Assert.AreEqual(BinarySearcher.Search(array, 55), 5);
        }
    }
}