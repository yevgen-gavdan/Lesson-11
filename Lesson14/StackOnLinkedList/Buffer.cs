using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCommonInterfaces;

namespace StackOnLinkedList
{
    public abstract class Buffer<T> : MyCommonInterfaces.IMyStack<T> where T : class
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
        abstract public bool Push(T ValueToSave);
        abstract public T Pop();
    }
}
