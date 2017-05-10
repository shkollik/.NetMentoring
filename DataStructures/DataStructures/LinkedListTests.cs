using NUnit.Framework;
using System;

namespace DataStructures
{
    [TestFixture]
    class LinkedListTests
    {
        [Test]
        public void AddAt_PositionLessThanSize_And_MoreThanZero()
        {
            LinkedList<int> list = new LinkedList<int>() { 1, 2, 3, 4, 5 };
            list.AddAt(2, 100);
            Assert.AreEqual(100, list.ElementAt(2));
        }

        [Test]
        public void AddAt_Position_0()
        {
            LinkedList<int> list = new LinkedList<int>() { 1, 2, 3, 4, 5 };
            list.AddAt(0, 100);
            Assert.AreEqual(100, list.ElementAt(0));
        }

        [Test]
        public void AddAt_LastPosition()
        {
            LinkedList<int> list = new LinkedList<int>() { 1, 2, 3, 4, 5 };
            list.AddAt(list.GetLength() - 1, 100);
            Assert.AreEqual(100, list.ElementAt(list.GetLength() - 2));
        }

        [Test]
        public void AddAt_PositionMoreThanLastElement()
        {
            LinkedList<int> list = new LinkedList<int>() { 1, 2, 3, 4, 5 };
            Assert.That(() => list.AddAt(list.GetLength(), 100), Throws.TypeOf<IndexOutOfRangeException>());
        }

        [Test]
        public void AddAt_PositionLessThanZero()
        {
            LinkedList<int> list = new LinkedList<int>() { 1, 2, 3, 4, 5 };
            Assert.That(() => list.AddAt(-1, 100), Throws.TypeOf<IndexOutOfRangeException>());
        }

        [Test]
        public void RemoveAt_PositionLessThanSize_And_MoreThanZero()
        {
            LinkedList<int> list = new LinkedList<int>() { 1, 2, 3, 4, 5 };
            int positionForDeleting = 2;
            int newValue = list.ElementAt(positionForDeleting + 1);
            int sizeBefore = list.GetLength();

            list.RemoveAt(positionForDeleting);
            Assert.IsTrue(list.ElementAt(positionForDeleting).Equals(newValue) && list.GetLength() == sizeBefore - 1);
        }

        [Test]
        public void RemoveAt_Position_0()
        {
            LinkedList<int> list = new LinkedList<int>() { 1, 2, 3, 4, 5 };
            int positionForDeleting = 0;
            int newValue = list.ElementAt(positionForDeleting + 1);
            int sizeBefore = list.GetLength();

            list.RemoveAt(positionForDeleting);
            Assert.IsTrue(list.ElementAt(positionForDeleting).Equals(newValue) && list.GetLength() == sizeBefore - 1);
        }

        [Test]
        public void RemoveAt_LastPosition()
        {
            LinkedList<int> list = new LinkedList<int>() { 1, 2, 3, 4, 5 };
            int positionForDeleting = 4;
            int sizeBefore = list.GetLength();

            list.RemoveAt(positionForDeleting);
            Assert.IsTrue(list.GetLength() == sizeBefore - 1);
        }

        [Test]
        public void RemoveAt_PositionMoreThanLastElement()
        {
            LinkedList<int> list = new LinkedList<int>() { 1, 2, 3, 4, 5 };
            Assert.That(() => list.RemoveAt(list.GetLength()), Throws.TypeOf<IndexOutOfRangeException>());
        }

        [Test]
        public void RemoveAt_PositionLessThanZero()
        {
            LinkedList<int> list = new LinkedList<int>() { 1, 2, 3, 4, 5 };
            Assert.That(() => list.RemoveAt(-1), Throws.TypeOf<IndexOutOfRangeException>());
        }

        [Test]
        public void AddToTheBeginningOfEmptyList()
        {
            LinkedList<int> list = new LinkedList<int>();
            int value = 200;
            list.AddToTheBeginning(value);

            Assert.AreEqual(value, list.ElementAt(0));
        }

        [Test]
        public void AddToTheEndOfEmptyList()
        {
            LinkedList<int> list = new LinkedList<int>();
            int value = 200;
            list.AddToTheEnd(value);

            Assert.AreEqual(value, list.ElementAt(0));
        }

        [Test]
        public void RemoveFromTheBeginningOfEmptyList()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.RemoveFromTheBeginning();

            Assert.AreEqual(0, list.GetLength());
        }

        [Test]
        public void RemoveFromTheBeginningOfListWithOneItem()
        {
            LinkedList<int> list = new LinkedList<int>() { 300 };
            list.RemoveFromTheBeginning();

            Assert.AreEqual(0, list.GetLength());
        }

        [Test]
        public void RemoveFromTheEndOfEmptyList()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.RemoveFromTheEnd();

            Assert.AreEqual(0, list.GetLength());
        }

        [Test]
        public void RemoveFromTheEndOfListWithOneItem()
        {
            LinkedList<int> list = new LinkedList<int>() { 300 };
            list.RemoveFromTheEnd();

            Assert.AreEqual(0, list.GetLength());
        }

    }
}
