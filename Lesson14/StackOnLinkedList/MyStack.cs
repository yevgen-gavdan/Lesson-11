using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOnLinkedList
{
    public class MyStack<T> : Buffer<T> where T : class
    {
        public MyStack() : base() { }
        public override bool Push(T ValueToSave)
        {
            if (!IsFull())
            {
                m_List.AddLast(ValueToSave);
                Top++;
                return true;
            }
            return false;
        }
        public override T Pop()
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
