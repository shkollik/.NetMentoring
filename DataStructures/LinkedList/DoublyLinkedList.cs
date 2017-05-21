using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        //Implement linked list with such function set: Length, Add, AddAt, Remove, RemoveAt, ElementAt.
        //Implement Ienumerable to make your list work with foeach
        private Node<T> head;
        private Node<T> tail;
        private int size;

        public void AddFirst(T element)
        {
            Node<T> helperNode = head;
            Node<T> newNode = new Node<T>(null, element, helperNode);
            head = newNode;
            if (helperNode == null)
            {
                tail = newNode;
            }
            else
            {
                helperNode.prev = newNode;
            }
            size++;
        }

        public void AddLast(T element)
        {
            Node<T> helperNode = tail;
            Node<T> newNode = new Node<T>(helperNode, element, null);
            tail = newNode;
            if (helperNode == null)
            {
                head = newNode;
            }
            else
            {
                helperNode.next = tail;
            }
            size++;
        }

        public void AddAt(int position, T element)
        {
            if (position == 0)
            {
                AddFirst(element);
            }
            else
            {
                Node<T> prevNode = GetNodeAt(position).prev;
                Node<T> newNode = new Node<T>(prevNode, element, prevNode.next);
                prevNode.next = newNode;
                size++;
            }
        }

        public void Add(T element)
        {
            AddLast(element);
        }

        private Node<T> GetNodeAt(int position)
        {
            if (position < 0 || position > size - 1)
            {
                throw new IndexOutOfRangeException();
            }

            Node<T> node = head;
            for (int i = 0; i < position; i++)
            {
                node = node.next;
            }
            return node;
        }

        public T ElementAt(int position)
        {
            return GetNodeAt(position).value;
        }


        public void RemoveFirst()
        {
            if (GetLength() > 1)
            {
                head = head.next;
                head.prev = null;
                size--;
            }
            else if (GetLength() == 1)
            {
                LeaveEmtyList();
                size--;
            }
        }

        private void LeaveEmtyList()
        {
            head = null;
            tail = null;
        }

        public void RemoveLast()
        {
            if (GetLength() > 1)
            {
                tail = tail.prev;
                tail.next = null;
                size--;
            }
            else if (GetLength() == 1)
            {
                LeaveEmtyList();
                size--;
            }
        }

        public void RemoveAt(int position)
        {
            if (position < 0 || position >= size)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                if (position == size - 1)
                {
                    RemoveLast();
                }
                else if (position == 0)
                {
                    RemoveFirst();
                }
                else if (position > 1)
                {
                    Node<T> nodeForDeletion = GetNodeAt(position);
                    Node<T> prevNode = nodeForDeletion.prev;
                    Node<T> nextNode = nodeForDeletion.next;
                    prevNode.next = nextNode;
                    nextNode.prev = prevNode;
                    size--;
                }
                else if (position == 1)
                {
                    LeaveEmtyList();
                    size--;
                }
            }

        }

        public int GetLength()
        {
            return size;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = head;
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

        private class Node<T>
        {
            internal T value;
            internal Node<T> prev;
            internal Node<T> next;

            public Node(Node<T> prev, T element, Node<T> next)
            {
                this.prev = prev;
                this.value = element;
                this.next = next;
            }
        }
    }
}
