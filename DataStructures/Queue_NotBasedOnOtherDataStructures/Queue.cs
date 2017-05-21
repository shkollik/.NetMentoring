using System;
using System.Collections;
using System.Collections.Generic;


namespace Queue_NotBasedOnOtherDataStructures
{
    class Queue<T> : IEnumerable<T>
    {
        private Node<T> _head;
        private int _size;

        public void Enqueue(T value)
        {
            if(_head == null)
            {
                _head = new Node<T>(value, null);
            }
            else
            {
                Node<T> tempNode = GetLastNode();
                tempNode.next = new Node<T>(value, null);
            }
            
            _size++;
        }

        public T Dequeue()
        {
            if(_size == 0)
            {
                throw new InvalidOperationException("queue is empty");
            }
            T value = _head.value;
            _size--;

            _head = _head.next;
            return value;
        }

        public T Peek()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("queue is empty");
            }

            return _head.value;
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

        public int Count{
            get
                {
                    return _size;
                }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = _head;
            while (current != null)
            {
                yield return current.value;
                current = current.next;
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
