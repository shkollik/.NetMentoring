using System;
using System.Collections;
using System.Collections.Generic;

namespace Stack_ArrayBased
{
    class Stack<T> : IEnumerable<T>
    {
        T[] array;
        private int Size { get; set; }
        public Stack() : this(0)
        {

        }
        public Stack(int size)
        {
            array = new T[size];
        }

        public void Push(T value)
        {
            if(Size == array.Length)
            {
                int newLength = Size == 0 ? 4 : Size * 2;
                T[] tempArray = new T[newLength];

                array.CopyTo(tempArray, 0);
                array = tempArray;
            }

            array[Size++] = value;
        }

        public T Pop()
        {
            if(Size == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }

            Size--;
            return array[Size];
        }

        public T Peek()
        {
            if(Size == 0)
            {
                throw new InvalidOperationException("stack is empty");
            }

            return array[Size - 1];
        }

        public int Count
        {
            get
            {
                return Size;
            }
        }

        public void Clear()
        {
            Size = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for(int i = Size - 1; i >= 0; i--)
            {
                yield return array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
