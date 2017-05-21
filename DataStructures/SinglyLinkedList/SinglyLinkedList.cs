using System;
using System.Collections;
using System.Collections.Generic;


namespace DataStructures
{
    public class SinglyLinkedList<T> : IEnumerable<T>
    {
        private Node<T> Head { get; set; }
        private int Count { get; set; }

        public void AddFirst(T value)
        {
            Node<T> tempNode = new Node<T>(value, null);
            if(Head == null)
            {
                Head = tempNode;
            }else
            {
                Head = new Node<T>(value, Head);
            }

            Count++;
        }

        public void AddLast(T value)
        {
            Node<T> tempNode = new Node<T>(value, null);
            if (Head == null)
            {
                Head = tempNode;
            }else
            {
                GetTail().Next = tempNode;
            }

            Count++;
        }

        public void Add(T value)
        {
            AddLast(value);
        }

        public void AddAt(int position, T value) // position [0 ->]
        {
            if(position < 0)
            {
                throw new ArgumentException("The list is empty");
            }
            else if (position > Count)
            {
                throw new IndexOutOfRangeException("position must be less or equal to current size");
            }
            else if(position == 0)
            {
                AddFirst(value);
            }
            else
            {
                Node<T> node = new Node<T>(value, GetNodeAt(position -1));
                GetNodeAt(position - 1).Next = node;
                Count++;
            }
        }

        public int GetLength()
        {
            return Count;
        }

        public void RemoveAt(int position)
        {
            if (position < 0)
            {
                throw new ArgumentException("The list is empty");
            }
            else if(position >= Count)
            {
                throw new IndexOutOfRangeException("position must be less then current size");
            }
            else if(position == 0)
            {
                RemoveFirst();
            }
            else
            {
                GetNodeAt(position - 2).Next = GetNodeAt(position);
                Count--;
            }
        }

        public T ElementAt(int position)
        {
            return GetNodeAt(position).Value;
        }

        private Node<T> GetNodeAt(int position)
        {
            Node<T> node = Head;
            if(Count == 0)
            {
                throw new ArgumentException("The list is empty");
            }
            else if(Count > 1)
            {
                for (int i = 0; i < position; i++)
                {
                    node = node.Next;
                }
            }

            return node;
        }

        public void RemoveFirst()
        {
            if(Count > 1)
            {
                Head = Head.Next;
                Count--;
            }
            else if (Count == 1)
            {
                Head = null;
                Count--;
            }
            else
            {
                throw new ArgumentException("The list is empty");
            }
        }

        public void RemoveLast()
        {
            if (Count > 1)
            {
                GetNodeAt(Count - 2).Next = null;
                Count--;
            }
            else if (Count == 1)
            {
                Head = null;
                Count--;
            }
            else
            {
                throw new ArgumentException("The list is empty");
            }
        }

        private Node<T> GetTail()
        {
            if(Head == null)
            {
                throw new ArgumentException("The list is empty");
            }

            Node<T> node = Head;
            while (node.Next != null)
            {
                node = node.Next;
            }

            return node;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        class Node<T>
        {
            public Node<T> Next { get; set; }
            public T Value { get; set; }
            public Node(T value, Node<T> next)
            {
                this.Value = value;
                this.Next = next;
            }
        }
    }
}
