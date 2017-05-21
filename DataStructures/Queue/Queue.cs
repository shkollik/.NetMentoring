using DataStructures;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Queue
{
    //FIFO structure implemented via SinglyLinkedList
    class Queue<T> : IEnumerable<T>
    {
        SinglyLinkedList<T> _list;

        public Queue()
        {
            _list = new SinglyLinkedList<T>();
        }

        //Add the specified item to the queue
        public void Enqueue(T item)
        {
            _list.AddLast(item);
        }

        //Removes and returns the first item from the queue
        public T Dequeue()
        {
            if(_list.GetLength() == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }

            T value = _list.ElementAt(0);
            _list.RemoveFirst();

            return value;
        }

        //Returns the first item from the queue
        public T Peek()
        {
            if (_list.GetLength() == 0)
            {
                throw new InvalidOperationException("The queue is empty");
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
