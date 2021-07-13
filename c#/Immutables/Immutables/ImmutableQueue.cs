using System;
using System.Collections.Generic;

namespace Immutables
{
    public sealed class ImmutableQueue<T> : IQueue<T>
    {
        private readonly IStack<T> backwards;
        private readonly IStack<T> forwards;

        public bool IsEmpty { get { return backwards.IsEmpty && forwards.IsEmpty; } }

        public ImmutableQueue()
        {
            backwards = new ImmutableStack<T>();
            forwards = new ImmutableStack<T>();
        }
        private ImmutableQueue(IStack<T> f, IStack<T> b)
        {
            forwards = f;
            backwards = b;
        }

        public T Peek()
        {
            return forwards.Peek();
        }

        public IQueue<T> Enqueue(T value)
        {
            if (forwards.IsEmpty)
                return new ImmutableQueue<T>(forwards.Push(value), backwards);
            return new ImmutableQueue<T>(forwards, backwards.Push(value));
        }

        public IQueue<T> Dequeue()
        {
            IStack<T> f = forwards.Pop();
            if (!f.IsEmpty)
                return new ImmutableQueue<T>(f, backwards);
            else if (IsEmpty)
                throw new Exception("Empty");
            else
                return new ImmutableQueue<T>(backwards.Reverse(), new ImmutableStack<T>());
        }

        public void PrintQueue()
        {
            try
            {
                if (!IsEmpty)
                    for (var queue = this; !this.forwards.IsEmpty; queue = (ImmutableQueue<T>)queue.Dequeue())
                    {
                        Console.WriteLine(queue.Peek());
                    }
                else
                    Console.WriteLine("Empty");
            }
            catch (Exception)
            {

            }

        }
    }
}
