using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2020ClassLibrary
{
    /**
     * Partial credit to Aaron Gage
     * https://stackoverflow.com/questions/66893/tree-data-structure-in-c-sharp
     */
    public class Tree<T>
    {
        private T data;
        private int count;

        private LinkedList<Tree<T>> children;

        public Tree(T Data)
        {
            data = Data;
            count = 1;
            children = new LinkedList<Tree<T>>();
        }

        public Tree(T Data, int Count): this(Data)
        {
            count = Count;
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

        public T Data
        {
            get
            {
                return data;
            }
        }

        public int CountChildren
        {
            get
            {
                return children.Count;
            }
        }

        public LinkedList<Tree<T>> Children
        {
            get
            {
                return children;
            }
        }

        public void AddChild(T Data)
        {
            foreach (var child in children)
            {
                if (child.data.Equals(Data))
                {
                    child.count++;
                    return;
                }
            }

            children.AddFirst(new Tree<T>(Data));
        }

        public void AddChild(Tree<T> Node)
        {
            children.AddFirst(Node);
        }

        public void AddChild(T Data, int Count)
        {
            foreach (var child in children)
            {
                if (child.data.Equals(Data))
                {
                    child.count += Count;
                    return;
                }
            }

            children.AddFirst(new Tree<T>(Data, Count));
        }

        public Tree<T> ChildAt(int index)
        {
            foreach (Tree<T> child in children)
            {
                if (index-- == 0)
                {
                    return child;
                }
            }

            return null;
        }

        public static void Traverse(Tree<T> Node, Action<T> visitor)
        {
            visitor(Node.data);

            foreach (Tree<T> child in Node.children)
            {
                Traverse(child, visitor);
            }
        }
    }
}
