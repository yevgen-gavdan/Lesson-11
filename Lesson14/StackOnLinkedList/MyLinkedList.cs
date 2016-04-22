using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOnLinkedList
{
    public abstract class Node
    {
        protected Node pNext = null;
        protected Node pPrevious = null;
        public Node NextNode
        {
            get { return pNext; }
            set { pNext = value; }
        }
        public Node PreviousNode
        {
            get { return pPrevious; }
            set { pPrevious = value; }
        }
    }
    public class Head : Node
    {

    }
    public class Tail : Node
    {

    }
    public class Body<T> : Node
    {
        private T m_Data = default(T);
        public T Data
        {
            get { return m_Data; }
            set { m_Data = value; }
        }
    }

    public class MyLinkedList<T> : IMyLinkedList<T> where T : class
    {
        private Node pHead = null;
        private Node pTail = null;
        private int m_NodesCounter = 0;

        public MyLinkedList()
        {
            pHead = new Head();
            pTail = new Tail();
            OnInitialize();
        }
        private void OnInitialize()
        {
            pHead.NextNode = pTail;
            pTail.PreviousNode = pHead;
        }
        private void IsPossitionOK(int index)
        {
            if (index < 0 || index >= m_NodesCounter)
            {
                throw new ArgumentOutOfRangeException("int index", "No such element available");
            }
        }
        private Node this[int index, bool unusedFlag]
        {
            get
            {
                Node tempNode = pHead;
                for (int i = 0; i < index; i++)
                {
                    tempNode = tempNode.NextNode;
                }
                return tempNode;
            }
            set
            {
                Node tempNode = pHead;
                for (int i = 0; i < index; i++)
                {
                    tempNode = tempNode.NextNode;
                }
                tempNode = value;
            }
        }
        private void InsertElementByPossition(T elementToAdd, int possition)
        {
            Node pNewElement = new Body<T>();
            (pNewElement as Body<T>).Data = elementToAdd;

            pNewElement.NextNode = this[possition, true].NextNode;
            pNewElement.PreviousNode = this[possition, true];
            this[possition, true].NextNode.PreviousNode = pNewElement;
            this[possition, true].NextNode = pNewElement;

            m_NodesCounter++;
        }
        private void RemoveElementByPossition(int possition)
        {
            possition++;
            (this[possition, true] as Body<T>).Data = null;

            this[possition, true].NextNode.PreviousNode = this[possition, true].PreviousNode;
            this[possition, true].PreviousNode = this[possition, true].NextNode;

            this[possition, true].NextNode = null;
            this[possition, true].PreviousNode = null;

            m_NodesCounter--;
        }

        //### IMyLinkedList implementation ###
        T IMyLinkedList<T>.this[int index]
        {
            get
            {
                IsPossitionOK(index);
                Node tempNode = pHead;
                for (int i = 0; i <= index; i++)
                {
                    tempNode = tempNode.NextNode;
                }
                return (tempNode as Body<T>).Data;
            }
            set
            {
                IsPossitionOK(index);
                Node tempNode = pHead;
                for (int i = 0; i <= index; i++)
                {
                    tempNode = tempNode.NextNode;
                }
                (tempNode as Body<T>).Data = value;
            }
        }
        int IMyLinkedList<T>.Counter
        {
            get { return m_NodesCounter; }
        }
        void IMyLinkedList<T>.AddFirst(T elementToAdd)
        {
            InsertElementByPossition(elementToAdd, 0);
        }
        void IMyLinkedList<T>.AddAfter(T elementToAdd, int possition)
        {
            IsPossitionOK(possition);
            InsertElementByPossition(elementToAdd, possition + 1);
        }
        void IMyLinkedList<T>.AddLast(T elementToAdd)
        {
            InsertElementByPossition(elementToAdd, m_NodesCounter);
        }
        void IMyLinkedList<T>.AddBefore(T elementToAdd, int possition)
        {
            IsPossitionOK(possition);
            InsertElementByPossition(elementToAdd, possition);
        }
        void IMyLinkedList<T>.Remove(int index)
        {
            IsPossitionOK(index);
            RemoveElementByPossition(index);
        }
        T IMyLinkedList<T>.RemoveLast()
        {
            T result = (this as IMyLinkedList<T>)[m_NodesCounter - 1];
            RemoveElementByPossition(m_NodesCounter - 1);
            return result;
        }
    }

    public interface IMyLinkedList<T>
    {
        int Counter { get; }
        T this[int index] { get; set; }
        void AddFirst(T elementToAdd);
        void AddLast(T elementToAdd);
        void AddAfter(T elementToAdd, int possition);
        void AddBefore(T elementToAdd, int possition);
        void Remove(int index);
        T RemoveLast();
    }
}
