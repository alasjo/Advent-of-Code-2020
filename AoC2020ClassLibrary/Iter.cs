using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AoC2020ClassLibrary
{
    public class Iter<T>: IEnumerable<T>
    {
        private class Node
        {
            private Node next;
            private T data;

            public Node(T t)
            {
                next = null;
                data = t;
            }

            public Node Next
            {
                get
                {
                    return next;
                }
                set
                {
                    next = value;
                }
            }

            public T Data
            {
                get
                {
                    return data;
                }
                set
                {
                    data = value;
                }
            }
        }

        private Node head;
        private int size;

        public int Count
        {
            get
            {
                return size;
            }
        }

        public Iter()
        {
            head = null;
            size = 0;
        }

        public Iter(List<T> ts): base()
        {
            foreach (var t in ts)
            {
                Add(t);
            }
        }

        public T ItemAt(int index)
        {
            Node t = head;
            int i = size - index;
            while (i > index)
            {
                t = t.Next;
                i--;
            }
            return t.Data;
        }

        public T Head
        {
            get
            {
                return head.Data;
            }
            set
            {
                head.Data = value;
            }
        }

        public void Add(T t)
        {
            Node node = new Node(t);
            node.Next = head;
            head = node;
            size++;
        }

        public T Take()
        {
            T value = head.Data;
            head = head.Next;
            size--;
            return value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            Node current = head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node current = head;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
