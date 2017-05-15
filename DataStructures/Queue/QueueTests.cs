using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class QueueTests
    {
        [Test]
        public void TestEnqueu()
        {
            Queue<int> queue = new Queue<int>();
            int value = 1;
            queue.Enqueue(value);

            Assert.AreEqual(value, queue.Peek());
        }

        [Test]
        public void DequeueIfQueueIsNotEmptyReturnsTheFirstItem()
        {
            Queue<int> queue = new Queue<int>();
            int firstValue = 1;
            int secondValue = 2;
            queue.Enqueue(firstValue);
            queue.Enqueue(secondValue);

            Assert.AreEqual(firstValue, queue.Dequeue());
        }

        [Test]
        public void DequeueIfQueueIsNotEmptyRemovesFirstItem()
        {
            Queue<int> queue = new Queue<int>();
            int firstValue = 1;
            int secondValue = 2;
            int countBeforeEnqueu = 2;

            queue.Enqueue(firstValue);
            queue.Enqueue(secondValue);
            queue.Dequeue();

            Assert.AreEqual(countBeforeEnqueu - 1, queue.Count);
        }

        [Test]
        public void DequeueIfQueueIsEmpty()
        {
            Queue<int> queue = new Queue<int>();

            Assert.That(() => queue.Dequeue(), Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void PeekIfQueueIsNotEmpty()
        {
            Queue<int> queue = new Queue<int>();
            int firstValue = 1;
            int secondValue = 2;
            queue.Enqueue(firstValue);
            queue.Enqueue(secondValue);

            Assert.AreEqual(firstValue, queue.Dequeue());
        }

        [Test]
        public void PeekIfQueueIsEmpty()
        {
            Queue<int> queue = new Queue<int>();

            Assert.That(() => queue.Peek(), Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void TestCount()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(200);

            Assert.AreEqual(1, queue.Count);
        }
    }
}
