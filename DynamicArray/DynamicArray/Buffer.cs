using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicArray
{
    public abstract class Buffer<T>
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
        abstract public bool Enqueue(T ValueToSave);
        abstract public bool Dequeue(ref T result);

    }

    public class DynamicStack<T> : Buffer<T>
    {
        public DynamicStack() : base() { }
        override public bool Enqueue(T ValueToSave)
        {
            if ( !IsFull() )
            {
                BufferArray[Top] = ValueToSave;
                Top++;
                return true;
            }
            return false;
        }
        override public bool Dequeue(ref T result)
        {
            if ( !IsEmpty() )
            {
                result = BufferArray[--Top];
                BufferArray.Remove(Top);
                return true;
            }
            return false;
        }
        protected override bool IsFull()
        {
            return (Top > (BufferArray.MaxSize-1));
        }
        protected override bool IsEmpty()
        {
            return (Top == 0);
        }

    }

    //class MyQueue : Buffer
    //{
    //    public MyQueue(int StackSize) : base(StackSize) { }

    //    protected override bool Enqueue(int ValueToSave)
    //    { 
    //        if( !IsFull() )
    //        {
    //            BufferArray[Top] = ValueToSave;
    //            ShiftPointer(ref Top);
    //            Counter++;
    //            return true;
    //        }
    //        return false;
    //    }
    //    protected override bool Dequeue(ref int result)
    //    {
    //        if( !IsEmpty() )
    //        {
    //            result = BufferArray[Tail];
    //            ShiftPointer(ref Tail);
    //            Counter--;
    //            return true;
    //        }
    //        return false;
    //    }
    //    protected override bool IsFull()
    //    {
    //        return (Counter == BufferArray.Length);
    //    }
    //    protected override bool IsEmpty()
    //    {
    //        return (Counter == 0);
    //    }
    //    protected void ShiftPointer(ref int Pointer)
    //    {
    //        if (Pointer == (BufferArray.Length - 1))
    //        {
    //            Pointer = 0;
    //        }
    //        else 
    //        {
    //            Pointer++;
    //        }
    //    }
    //}
}

