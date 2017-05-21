using NUnit.Framework;
using System;


namespace DataStructures
{
    [TestFixture]
    class SinglyLinkedListTests
    {
        [Test]
        public void AddAt_PositionLessThanSize_And_MoreThanZero()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>() { 1, 2, 3, 4, 5 };
            int positionForAdding = 2;
            list.AddAt(positionForAdding, 100);
            Assert.AreEqual(100, list.ElementAt(positionForAdding));
        }

        [Test]
        public void AddAt_Position_0()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>() { 1, 2, 3, 4, 5 };
            list.AddAt(0, 100);
            Assert.AreEqual(100, list.ElementAt(0));
        }

        [Test]
        public void AddAt_LastPosition()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>() { 1, 2, 3, 4, 5 };
            list.AddAt(list.GetLength() - 1, 100);
            Assert.AreEqual(100, list.ElementAt(list.GetLength() - 2));
        }

        [Test]
        public void AddAt_PositionMoreThanLastElement()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>() { 1, 2, 3, 4, 5 };
            Assert.That(() => list.AddAt(list.GetLength() + 1, 100), Throws.TypeOf<IndexOutOfRangeException>());
        }

        [Test]
        public void AddAt_PositionLessThanZero()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>() { 1, 2, 3, 4, 5 };
            Assert.That(() => list.AddAt(-1, 100), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void RemoveAt_PositionLessThanSize_And_MoreThanZero()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>() { 1, 2, 3, 4, 5 };
            int positionForDeleting = 2;
            int newValue = list.ElementAt(positionForDeleting + 1);
            int sizeBefore = list.GetLength();

            list.RemoveAt(positionForDeleting);
            Assert.IsTrue(list.ElementAt(positionForDeleting).Equals(newValue) && list.GetLength() == sizeBefore - 1);
        }

        [Test]
        public void RemoveAt_Position_0()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>() { 1, 2, 3, 4, 5 };
            int positionForDeleting = 0;
            int newValue = list.ElementAt(positionForDeleting + 1);
            int sizeBefore = list.GetLength();

            list.RemoveAt(positionForDeleting);
            Assert.IsTrue(list.ElementAt(positionForDeleting).Equals(newValue) && list.GetLength() == sizeBefore - 1);
        }

        [Test]
        public void RemoveAt_LastPosition()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>() { 1, 2, 3, 4, 5 };
            int positionForDeleting = 4;
            int sizeBefore = list.GetLength();

            list.RemoveAt(positionForDeleting);
            Assert.IsTrue(list.GetLength() == sizeBefore - 1);
        }

        [Test]
        public void RemoveAt_PositionMoreThanLastElement()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>() { 1, 2, 3, 4, 5 };
            Assert.That(() => list.RemoveAt(list.GetLength()), Throws.TypeOf<IndexOutOfRangeException>());
        }

        [Test]
        public void RemoveAt_PositionLessThanZero()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>() { 1, 2, 3, 4, 5 };
            Assert.That(() => list.RemoveAt(-1), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void AddToTheBeginningOfEmptyList()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();
            int value = 200;
            list.AddFirst(value);

            Assert.AreEqual(value, list.ElementAt(0));
        }

        [Test]
        public void AddToTheEndOfEmptyList()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();
            int value = 200;
            list.AddLast(value);

            Assert.AreEqual(value, list.ElementAt(0));
        }

        [Test]
        public void RemoveFirstOfEmptyList()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();            

            Assert.That(() => list.RemoveFirst(), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void RemoveFirstOfListWithOneItem()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>() { 300 };
            list.RemoveFirst();

            Assert.AreEqual(0, list.GetLength());
        }

        [Test]
        public void RemoveLastOfEmptyList()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();

            Assert.That(() => list.RemoveLast(), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void RemoveLastOfListWithOneItem()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>() { 300 };
            list.RemoveLast();

            Assert.AreEqual(0, list.GetLength());
        }
    }
}
