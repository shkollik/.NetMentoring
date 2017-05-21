using System;
using System.Collections;
using System.Collections.Generic;


namespace Queue_ArrayBased
{
    class Queue<T> : IEnumerable<T>
    {
        private T[] _array;
        private int _size;

        public Queue() : this(0)
        {

        }

        public Queue(int capacity)
        {
            _array = new T[capacity];
        }

        public void Enqueue(T value)
        {
            if(_size == _array.Length)
            {
                int newLength = _size == 0 ? 4 : _size * 2;
                T[] tempArray = new T[newLength];
                _array.CopyTo(tempArray, 0);
                _array = tempArray;
            }

            _array[_size++] = value;
        }

        public T Dequeue()
        {
            if(_size == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }

            _size--;
            T value = _array[0];

            if(_array.Length > 1)
            {
                for (int i = 0; i < _array.Length - 1; i++)
                {
                    _array[i] = _array[i + 1];
                }
            }

            return value;
        }

        public T Peek()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }

            return _array[0];
        }

        public int Count
        {
            get
            {
                return _size;
            }
        }

        public void Clear()
        {
            _size = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for(int i = 0; i < _array.Length - 1; i++)
            {
                yield return _array[i];

            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
