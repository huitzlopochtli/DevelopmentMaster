using System;

namespace Immutables
{
    public sealed class ImmutableStack<T> : IStack<T>
    {
        private readonly T head;

        private readonly IStack<T> tail;

        public ImmutableStack()
        {
            this.head = default(T);
            this.tail = null;
        } 

        private ImmutableStack(T head, IStack<T> tail)
        {
            this.head = head;
            this.tail = tail;
        }
        public bool IsEmpty
        {
            get { return tail == null; }
        }
        public T Peek()
        {
            return !IsEmpty ? head : throw new Exception("Empty");
        }
        public IStack<T> Pop()
        {
            return !IsEmpty ? tail : throw new Exception("Empty");
        }
        public IStack<T> Push(T value)
        {
            return new ImmutableStack<T>(value, this);
        }
        public void PrintStack()
        {
            if (!IsEmpty)
                for (IStack<T> stack = this; !stack.IsEmpty; stack = stack.Pop())
                    Console.WriteLine(stack.Peek());
            else
                Console.WriteLine("Empty");
        }

        public IStack<T> Reverse()
        {
            IStack<T> r = new ImmutableStack<T>();
            for (IStack<T> f = this; !f.IsEmpty; f = f.Pop())
                r = r.Push(f.Peek());
            return r;
        }
    }
}

