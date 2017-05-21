using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_ArrayBased
{
    class StackTests
    {
        [Test]
        public void TestPush()
        {
            Stack<int> stack = new Stack<int>();
            int value = 1;
            stack.Push(value);

            Assert.AreEqual(value, stack.Peek());
        }

        [Test]
        public void PopIfStackIsNotEmptyReturnsTheTopItem()
        {
            Stack<int> stack = new Stack<int>();
            int firstValue = 1;
            int secondValue = 2;
            stack.Push(firstValue);
            stack.Push(secondValue);

            Assert.AreEqual(secondValue, stack.Pop());
        }

        [Test]
        public void PopIfStackIsNotEmptyRemovesTheTopItem()
        {
            Stack<int> stack = new Stack<int>();
            int firstValue = 1;
            int secondValue = 2;
            int countBeforePop = 2;

            stack.Push(firstValue);
            stack.Push(secondValue);
            stack.Pop();

            Assert.AreEqual(countBeforePop - 1, stack.Count);
        }

        [Test]
        public void PopIfStackIsEmpty()
        {
            Stack<int> stack = new Stack<int>();

            Assert.That(() => stack.Pop(), Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void PeekIfStackIsNotEmpty()
        {
            Stack<int> stack = new Stack<int>();
            int firstValue = 1;
            int secondValue = 2;
            stack.Push(firstValue);
            stack.Push(secondValue);

            Assert.AreEqual(secondValue, stack.Peek());
        }

        [Test]
        public void PeekIfStackIsEmpty()
        {
            Stack<int> stack = new Stack<int>();

            Assert.That(() => stack.Peek(), Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void TestClear()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(100);

            stack.Clear();

            Assert.AreEqual(0, stack.Count);
        }

        [Test]
        public void TestCount()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(100);

            Assert.AreEqual(1, stack.Count);
        }

        [Test]
        public void TestResize()
        {
            int initialCapacity = 2;
            Stack<int> stack = new Stack<int>(initialCapacity);
            stack.Push(1);
            stack.Push(2);

            stack.Push(3);
            Assert.AreEqual(initialCapacity + 1, stack.Count);
        }
    }
}
