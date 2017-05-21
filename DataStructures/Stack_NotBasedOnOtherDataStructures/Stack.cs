using System;
using System.Collections;
using System.Collections.Generic;

namespace Stack_NotBasedOnOtherDataStructures
{
    class Stack<T> : IEnumerable<T>
    {
        private int _size;
        private Node<T> _head;
        public Stack()
        {

        }

        public void Push(T value)
        {
            if (_head == null)
            {
                _head = new Node<T>(value, null);
            }else
            {
                Node<T> tempNode = GetLastNode();
                tempNode.next = new Node<T>(value, null);
            }
            
            _size++;
        }

        public T Pop()
        {
            if(_size == 0)
            {
                throw new InvalidOperationException("stack is empty");
            }

            T value = GetLastNode().value;

            if (_size == 1)
            {
                _head = null;
            }
            else if (_size == 2)
            {
                _head.next = null;
            }
            else
            {
                Node<T> tempNode = _head;
                while (tempNode.next.next != null)
                {
                    tempNode = tempNode.next; // finding prelast item
                }
                tempNode.next = null;
            }
            _size--;

            return value;
        }

        public T Peek()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("stack is empty");
            }

            return GetLastNode().value;
        }

        private Node<T> GetLastNode()
        {
            Node<T> tempNode = _head;
            while (tempNode.next != null)
            {
                tempNode = tempNode.next;
            }

            return tempNode;
        }

        public int Count
        {
            get{ return _size; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            while(_size != 0)
            {
                yield return GetLastNode().value;
                Pop();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        class Node<T>
        {
            public T value;
            public Node<T> next;

            public Node(T value, Node<T> next)
            {
                this.value = value;
                this.next = next;
            }
        }
    }
}
