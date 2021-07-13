using System;
using System.Collections.Generic;

namespace Immutables
{
    public interface IStack<T>
    {
        IStack<T> Push(T value);
        IStack<T> Pop();
        T Peek();
        bool IsEmpty { get; }
        void PrintStack();
        IStack<T> Reverse();
    }
}
