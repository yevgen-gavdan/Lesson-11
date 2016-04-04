using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOnLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            Buffer<TestObject> stack = new MyStack<TestObject>();
            for (int i = 0; i < 100; i++)
			{
                stack.Enqueue(new TestObject(i));
			}

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(stack.Peek(i).ID);
            }

            for (int i = 100; i > 0; i--)
            {
                Console.WriteLine(stack.Dequeue().ID);
            }
        }
    }
    class TestObject
    {
        public int ID = 0;
        public TestObject(int counter)
        {
            ID = counter;
        }
    }

    public abstract class Buffer<T> where T: class
    {
        //### FIELDS ###
        protected IMyLinkedList<T> m_List;
        protected int Top = 0;

        //### METHODS ###
        protected Buffer()
        {
            m_List = new MyLinkedList<T>();
        }
        public virtual T Peek(int index)
        {
            if (!IsEmpty())
            {
                return m_List[index];
            }
            return default(T);
        }
        abstract protected bool IsFull();
        abstract protected bool IsEmpty();
        abstract public bool Enqueue(T ValueToSave);
        abstract public T Dequeue();
    }

    public class MyStack<T> : Buffer<T> where T: class
    {
        public MyStack() : base() { }
        public override bool Enqueue(T ValueToSave)
        {
            if (!IsFull())
            {
                m_List.AddLast(ValueToSave); 
                Top++;
                return true;
            }
            return false;
        }
        public override T Dequeue()
        {
            if (!IsEmpty())
            {
                return m_List.RemoveLast();
            }
            return default(T);
        }
        protected override bool IsFull()
        {
            return false;
        }
        protected override bool IsEmpty()
        {
            return (Top == 0);
        }
    }


}
