using DataStructures;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Stack
{
    //LIFO structure implemented via SinglyLinkedList
    class Stack<T> : IEnumerable<T>
    {
        private SinglyLinkedList<T> _list;
        public Stack()
        {
            _list = new SinglyLinkedList<T>();
        }

        //Add the specified item to the stack
        public void Push(T item)
        {
            _list.AddFirst(item);
        }

        //Removes and returns the first item from stack
        public T Pop()
        {
            if(_list.GetLength() == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }

            T value = _list.ElementAt(0);
            _list.RemoveFirst();
            return value;
        }

        //Returns the topt item from stack without removing it
        public T Peek()
        {
            if (_list.GetLength() == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }

            return _list.ElementAt(0);
        }

        public int Count
        {
            get
            {
                return _list.GetLength();
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
