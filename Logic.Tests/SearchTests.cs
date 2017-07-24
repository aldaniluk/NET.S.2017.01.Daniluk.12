using NUnit.Framework;
using System;
using System.Collections.Generic;
using Logic;

namespace Logic.Tests
{
    [TestFixture]
    public class SearchTests
    {
        #region int[]
        [TestCase(new int[]{1,4,5,7,9,10}, 7, ExpectedResult = 3)]
        [TestCase(new int[] {4,11,12,23,44}, 4, ExpectedResult = 0)]
        [TestCase(new int[] {4,7,12,15,55,66,77,88}, 88, ExpectedResult = 7)]
        [TestCase(new int[] { 4, 11, 12, 23, 44 }, 1, ExpectedResult = -1)]
        [TestCase(new int[] { 4, 11, 12, 23, 44 }, 45, ExpectedResult = -1)]
        [TestCase(new int[] { 4, 11, 12, 23, 44 }, 22, ExpectedResult = -1)]
        public int BinarySearchTest_IntArray_PositiveTest(int[] array, int element)
        {
            return Search.BinarySearch<int>(array, element, Comparer<int>.Default);

        }

        [Test]
        public void BinarySearchTest_NullIntArray_NegativeTest()
        {
            int[] array = null;
            int element = 10;
            Assert.Throws<ArgumentNullException>(() => Search.BinarySearch<int>(array, element, Comparer<int>.Default));
        }

        [Test]
        public void BinarySearchTest_EmptyIntArray_NegativeTest()
        {
            int[] array = new int[] { };
            int element = 10;
            Assert.Throws<ArgumentException>(() => Search.BinarySearch<int>(array, element, Comparer<int>.Default));
        }
        #endregion

        #region string[]
        [TestCase(new string[] { "bbbb", "cccc", "dddd" }, "dddd", ExpectedResult = 2)]
        [TestCase(new string[] { "bbbb", "cccc", "dddd" }, "bbbb", ExpectedResult = 0)]
        [TestCase(new string[] { "bbbb", "cccc", "dddd" }, "cccc", ExpectedResult = 1)]
        [TestCase(new string[] { "bbbb", "cccc", "dddd" }, "aaaa", ExpectedResult = -1)]
        [TestCase(new string[] { "bbbb", "cccc", "dddd" }, "eeee", ExpectedResult = -1)]
        [TestCase(new string[] { "bbbb", "cccc", "dddd" }, "cddd", ExpectedResult = -1)]
        public int BinarySearchTest_StringArray_PositiveTest(string[] array, string element)
        {
            return Search.BinarySearch<string>(array, element, Comparer<string>.Default);
        }

        [Test]
        public void BinarySearchTest_NullStringArray_NegativeTest()
        {
            string[] array = null;
            string element = "hello";
            Assert.Throws<ArgumentNullException>(() => Search.BinarySearch<string>(array, element, Comparer<string>.Default));
        }

        [Test]
        public void BinarySearchTest_EmptyStringArray_NegativeTest()
        {
            string[] array = new string[] { };
            string element = "hello";
            Assert.Throws<ArgumentException>(() => Search.BinarySearch<string>(array, element, Comparer<string>.Default));
        }
        #endregion
    }
}
