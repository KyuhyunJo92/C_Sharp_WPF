using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ein_undAusgebe
{
    class Node
    {
        private int _key;
        private string _value;
        public Node _left = null;
        public Node _right = null;

        public Node(int key, string value)
        {
            _key = key;
            _value = value;
        }

        public int GetKey()
        {
            return _key;
        }
        public string GetValue()
        {
            return _value;
        }
        public Node GetLeft()
        {
            return _left;
        }
        public Node GetRight()
        {
            return _right;
        }

    }

    class BinarySearchTree : IEnumerable<int>
    {
        Node rootNode;

        public BinarySearchTree(/*int rootValue*/)
        {
            //rootNode = new Node(rootValue);
        }

        
        private void AddNewNumber(int key, string value, Node node)
        {
            if (node == null) { node = new Node(key, value); }

            //there is already obj Node.
            else
            {
                if (key == node.GetKey()) { return; }
                //Num is bigger.
                else if (key > node.GetKey())
                {
                    if (node._right == null)
                    {
                        node._right = new Node(key, value);
                    }
                    else
                    {
                        AddNewNumber(key, value, node._right);
                    }
                }

                //Num is smaller.
                else if (key < node.GetKey())
                {
                    if (node._left == null)
                    {
                        node._left = new Node(key, value);
                    }
                    else
                    {
                        AddNewNumber(key, value, node._left);
                    }
                }
            }
        }
        public void AddNewNumber(int key, string value)
        {

            if (rootNode == null) { rootNode = new Node(key, value); }


            //there is already obj Node.
            else
            {

                if (key == rootNode.GetKey()) { return; }
                //Num is bigger.
                else if (key > rootNode.GetKey())
                {
                    if (rootNode._right == null)
                    {
                        rootNode._right = new Node(key, value);
                    }
                    else
                    {
                        AddNewNumber(key, value, rootNode._right);
                    }
                }

                //Num is smaller.
                else if (key < rootNode.GetKey())
                {
                    if (rootNode._left == null)
                    {
                        rootNode._left = new Node(key, value);
                    }
                    else
                    {
                        AddNewNumber(key, value, rootNode._left);
                    }
                }
            }
        }

        

        public Node SearchNodeFromKey(int targetKey)
        {
            Node resNode = null;
            if (rootNode == null) {throw new IndexOutOfRangeException(); /*return resNode;*/ }
            //compare with root.key
            //same? return
            else if (targetKey == rootNode.GetKey()) { return rootNode; }
            //bigger? right
            else if (targetKey > rootNode.GetKey())
            {
                if (rootNode.GetRight() == null) {throw new IndexOutOfRangeException(); /*return resNode;*/ }
                else { resNode = SearchNodeFromKey(targetKey, rootNode.GetRight()); return resNode; }
            }
            else if (targetKey < rootNode.GetKey())
            {
                if (rootNode.GetLeft() == null) {throw new IndexOutOfRangeException(); /*return resNode;*/ }
                else { resNode = SearchNodeFromKey(targetKey, rootNode.GetLeft()); return resNode; }
            }
            else { return resNode; }
            //smaller? left
            //compare

        }
        public Node SearchNodeFromKey(int targetKey, Node node)
        {
            Node resNode = null;
            if (targetKey == node.GetKey()) { return node; }
            //bigger? right
            else if (targetKey > node.GetKey())
            {
                if (node.GetRight() == null) {throw new IndexOutOfRangeException(); /*return resNode;*/ }
                else { resNode = SearchNodeFromKey(targetKey, node.GetRight()); return resNode; }
            }
            else if (targetKey < rootNode.GetKey())
            {
                if (node.GetLeft() == null) {throw new IndexOutOfRangeException(); /*return resNode;*/ }
                else { resNode = SearchNodeFromKey(targetKey, node.GetLeft()); return resNode; }
            }
            else { return resNode; }
            //smaller? left
            //compare

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        IEnumerator<int> IEnumerable<int>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
