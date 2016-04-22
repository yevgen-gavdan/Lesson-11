using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOnDynamicArray
{
    public class DynamicStack<T> : Buffer<T> where T : class
    {
        public DynamicStack() : base() { }
        override public bool Push(T ValueToSave)
        {
            if (!IsFull())
            {
                BufferArray[Top] = ValueToSave;
                Top++;
                return true;
            }
            return false;
        }
        override public T Pop()
        {
            if (!IsEmpty())
            {
                T result = BufferArray[--Top];
                BufferArray.Remove(Top);
                return result;
            }
            return default(T);
        }
        protected override bool IsFull()
        {
            return (Top > (BufferArray.MaxSize - 1));
        }
        protected override bool IsEmpty()
        {
            return (Top == 0);
        }
    }
}
