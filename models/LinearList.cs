using System;
using System.Collections.Generic;

namespace SetApp
{
    public class LinearList<T>
    {
        private class Node
        {
            public T Value { get; set; }
            public Node? Next { get; set; }

            public Node(T value)
            {
                Value = value;
                Next = null;
            }
        }

        private Node? _head;
        private Node? _current;
        private int _count;

        public LinearList()
        {
            _head = null;
            _current = null;
            _count = 0;
        }

        // Properties
        public T CurrentElement 
        { 
            get 
            {
                if (_current == null)
                    throw new InvalidOperationException("List is empty or current element is not set");
                return _current.Value;
            } 
        }

        public int Count => _count;

        public bool IsEmpty => _count == 0;

        // Methods
        public void Add(T element)
        {
            var newNode = new Node(element);

            if (_head == null)
            {
                _head = newNode;
                _current = _head;
            }
            else
            {
                var last = _head;
                while (last.Next != null)
                {
                    last = last.Next;
                }
                last.Next = newNode;
                
                // If current element is not set, set it
                if (_current == null)
                {
                    _current = newNode;
                }
            }

            _count++;
        }

        public void Remove(T element)
        {
            if (_head == null)
                return;

            // If removing the first element
            if (_head.Value != null && _head.Value.Equals(element))
            {
                // If current element is the head, move current to the next
                if (_current == _head)
                {
                    _current = _head.Next;
                }
                
                _head = _head.Next;
                _count--;
                return;
            }

            var currentNode = _head;
            while (currentNode.Next != null)
            {
                if (currentNode.Next.Value != null && currentNode.Next.Value.Equals(element))
                {
                    // If element to remove is current, move current to the next
                    if (_current == currentNode.Next)
                    {
                        _current = currentNode.Next.Next;
                    }
                    
                    currentNode.Next = currentNode.Next.Next;
                    _count--;
                    return;
                }
                currentNode = currentNode.Next;
            }
        }

        public bool MoveToNext()
        {
            if (_current == null || _current.Next == null)
                return false;

            _current = _current.Next;
            return true;
        }

        public void MoveToStart()
        {
            _current = _head;
        }

        public void Clear()
        {
            _head = null;
            _current = null;
            _count = 0;
        }

        public T[] ToArray()
        {
            T[] array = new T[_count];
            var node = _head;
            int index = 0;
            
            while (node != null)
            {
                array[index++] = node.Value;
                node = node.Next;
            }
            
            return array;
        }
    }
}
