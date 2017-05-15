using System;
using System.Collections;
using System.Collections.Generic;

namespace Stack
{
    //LIFO structure implemented via LinkedList
    class Stack<T> : IEnumerable<T>
    {
        private LinkedList<T> _list;
        public Stack()
        {
            _list = new LinkedList<T>();
        }

        //Add the specified item to the stack
        public void Push(T item)
        {
            _list.AddFirst(item);
        }

        //Removes and returns the first item from stack
        public T Pop()
        {
            if(_list.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }

            T value = _list.First.Value;
            _list.RemoveFirst();
            return value;
        }

        //Returns the topt item from stack without removing it
        public T Peek()
        {
            if (_list.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }

            return _list.First.Value;
        }

        public int Count
        {
            get
            {
                return _list.Count;
            }
        }

        public void Clear()
        {
            _list.Clear();
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
