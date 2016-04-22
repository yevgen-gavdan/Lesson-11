using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCommonInterfaces;

namespace StackOnDynamicArray
{
    public abstract class Buffer<T> : MyCommonInterfaces.IMyStack<T> where T : class
    { 
        protected DynamicArray<T> BufferArray;

        protected int Top=0;
        protected int Tail=0;
        protected int Counter=0;

        protected Buffer()
        {
            BufferArray = new DynamicArray<T>();
        }
                
        //TODO: not used
        protected virtual bool Peek(ref T result)
        {
            if (!IsEmpty())
            {
                result = BufferArray[Top-1];
                return true;
            }
            return false;
        }

        abstract protected bool IsFull();
        abstract protected bool IsEmpty();
        abstract public bool Push(T ValueToSave);
        abstract public T Pop();

    }
}

