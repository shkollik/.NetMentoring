using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    //FIFO structure implemented via LinkedList
    class Queue<T> : IEnumerable<T>
    {
        LinkedList<T> _list;

        public Queue()
        {
            _list = new LinkedList<T>();
        }

        //Add the specified item to the queue
        public void Enqueue(T item)
        {
            _list.AddLast(item);
        }

        //Removes and returns the first item from the queue
        public T Dequeue()
        {
            if(_list.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }

            T value = _list.First.Value;
            _list.RemoveFirst();

            return value;
        }

        //Returns the first item from the queue
        public T Peek()
        {
            if (_list.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
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
