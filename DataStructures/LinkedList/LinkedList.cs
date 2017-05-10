using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    class LinkedList<T> : IEnumerable<T>
    {
        //Implement linked list with such function set: Length, Add, AddAt, Remove, RemoveAt, ElementAt.
        //Implement Ienumerable to make your list work with foeach
        private Node<T> first;
        private Node<T> last;
        private int size;

        public void AddToTheBeginning(T element)
        {
            Node<T> helperNode = first;
            Node<T> newNode = new Node<T>(null, element, helperNode);
            first = newNode;
            if (helperNode == null)
            {
                last = newNode;
            }
            else
            {
                helperNode.prev = newNode;
            }
            size++;
        }

        public void AddToTheEnd(T element)
        {
            Node<T> helperNode = last;
            Node<T> newNode = new Node<T>(helperNode, element, null);
            last = newNode;
            if (helperNode == null)
            {
                first = newNode;
            }
            else
            {
                helperNode.next = last;
            }
            size++;
        }

        public void AddAt(int position, T element)
        {
            if (position == 0)
            {
                AddToTheBeginning(element);
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
            AddToTheEnd(element);
        }

        private Node<T> GetNodeAt(int position)
        {
            if (position < 0 || position > size - 1)
            {
                throw new IndexOutOfRangeException();
            }

            Node<T> node = first;
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


        public void RemoveFromTheBeginning()
        {
            if (GetLength() > 1)
            {
                first = first.next;
                first.prev = null;
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
            first = null;
            last = null;
        }

        public void RemoveFromTheEnd()
        {
            if (GetLength() > 1)
            {
                last = last.prev;
                last.next = null;
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
                    RemoveFromTheEnd();
                }
                else if (position == 0)
                {
                    RemoveFromTheBeginning();
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
            Node<T> current = first;
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
