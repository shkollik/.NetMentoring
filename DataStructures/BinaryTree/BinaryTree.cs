using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class BinaryTree<T> where T : IComparable<T>
    {
        private BinaryTreeNode<T> _head;
        private int _count;

        #region ADD
        public void Add(T value)
        {
            // Case 1: The tree is empty - allocate the head
            if(_head == null)
            {
                _head = new BinaryTreeNode<T>(value);
            }
            // Case 2: The tree is not empty so find the right location to insert
            else
            {
                AddTo(_head, value);
            }

            _count++;
        }

        private void AddTo(BinaryTreeNode<T> node, T value)
        {
            //Case 1: value is less than the current node value
           if(value.CompareTo(node.Value) < 0)
            {
                // if there's no left child make this the new left
                if(node.Left == null)
                {
                    node.Left = new BinaryTreeNode<T>(value);
                }
                else
                {
                    // else add it to the left node
                    AddTo(node.Left, value);
                }
            }
            //Case 2; value is equal or greater than the current value
            else
            {
                // if there's no right child make this the new right
                if (node.Right == null)
                {
                    node.Right = new BinaryTreeNode<T>(value);
                }
                else
                {
                    // else add it to the right node
                    AddTo(node.Right, value);
                }

            }
#endregion
        }

        #region CONTAINS
        public bool Contains(T value)
        {
            BinaryTreeNode<T> parent;
            return FindWithParent(value, out parent) != null;
        }

        private BinaryTreeNode<T> FindWithParent(T value, out BinaryTreeNode<T> parent)
        {
            BinaryTreeNode<T> current = _head;
            parent = null;

            while(current != null)
            {
                int result = current.CompareTo(value);
                if(result > 0)
                {
                    // if the value is less than current, go left
                    parent = current;
                    current = current.Left;
                }
                else if(result < 0)
                {
                    // if value is more than current, go right
                    parent = current;
                    current = current.Right;
                }
                else
                {
                    // we have a match
                    break;
                }

            }

            return current;
        }
        #endregion

        #region REMOVE
        public bool Remove(T value)
        {
            BinaryTreeNode<T> current, parent;
            current = FindWithParent(value, out parent);

            if(current == null)
            {
                return false;
            }

            _count--;

            // Case 1: If current has no right child, then the current's left replaces current
            if(current.Right == null)
            {
                if(parent == null)
                {
                    _head = current.Left;
                }
                else
                {
                    int result = parent.CompareTo(current.Value);
                    if(result > 0)
                    {
                        // if parent value is greater than current value
                        // make the current left child a left child of parent
                        parent.Left = current.Left;
                    }
                    else if(result < 0)
                    {
                        // if parent value is greater than current value
                        // make the current left child a right child of parent
                        parent.Right = current.Left;
                    }
                }
            }
            // Case 2: If current's right child has no left child than current's right child replaces current
            else if(current.Right.Left == null)
            {
                if(parent == null)
                {
                    _head = current.Right;
                }
                else
                {
                    int result = parent.CompareTo(current.Value);
                    if(result > 0)
                    {
                        // if parent value is greater than current value
                        // make the current right child a left child of parent
                        parent.Left = current.Right;
                    }
                    else if(result < 0)
                    {
                        // if parent value is less than current value
                        // make the current right child a right child of parent
                        parent.Right = current.Right;
                    }
                }
            }
            // Case 3: if current's right child has a left child, replace current with current's right child left-most child
            else
            {
                //find the right's left-most child
                BinaryTreeNode<T> leftmost = current.Right.Left;
                BinaryTreeNode<T> leftmostParent = current.Right;

                while(leftmost.Left != null)
                {
                    leftmostParent = leftmost;
                    leftmost = leftmost.Left;
                }

                //the parent's left subtree becomes the leftmost's right subtree
                leftmostParent.Left = leftmost.Right;

                //assign leftmost's left and right to current;s left and right children
                leftmost.Left = current.Left;
                leftmost.Right = current.Right;

                if(parent == null)
                {
                    _head = leftmost;
                }
                else
                {
                    int result = parent.CompareTo(current.Value);
                    if(result > 0)
                    {
                        //if parent value is greater than current value
                        //male leftmost the parent's left child
                        parent.Left = leftmost;
                    }
                    else if(result < 0)
                    {
                        //if parent value is less than current value
                        //make leftmost the parent's right child
                        parent.Right = leftmost;
                    }
                }
            }

            return true;
        }
        #endregion

        class BinaryTreeNode<TNode> : IComparable<TNode> where TNode : IComparable<TNode>
        {
            public BinaryTreeNode(TNode value)
            {
                Value = value;
            }
            public TNode Value { get; private set; }
            public BinaryTreeNode<TNode> Left { get; set; }
            public BinaryTreeNode<TNode> Right { get; set; }


            public int CompareTo(TNode other)
            {
                return Value.CompareTo(other);
            }
        }
    }
}
