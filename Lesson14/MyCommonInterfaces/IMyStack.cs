using System;

namespace MyCommonInterfaces
{
    public interface IMyStack<T>
        where T : class
    {
        T Pop();
        bool Push(T ValueToSave);
    }
}
