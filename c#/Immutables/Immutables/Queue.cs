using System;
namespace Immutables
{
    public class Queue<T> : IQueue<T>
    {
        private IStack<T> front;
        private IStack<T> rear;

        public Queue()
        {
            front = new ImmutableStack<T>();
            rear = new ImmutableStack<T>();
        }

        private Queue(IStack<T> front, IStack<T> rear)
        {
            this.front = front;
            this.rear = rear;
        }

        public bool IsEmpty { get { return rear.IsEmpty && front.IsEmpty; } }

        public IQueue<T> Dequeue()
        {
            var f = front.Pop();
            if (!f.IsEmpty)
                return new Queue<T>(f, rear);
            else if (IsEmpty)
                throw new Exception("Empty");
            else
                return new Queue<T>(rear.Reverse(), new ImmutableStack<T>());
        }

        public IQueue<T> Enqueue(T value)
        {
            if (front.IsEmpty)
                return new Queue<T>(front.Push(value), rear);
            return new Queue<T>(front, rear.Push(value));
        }

        public T Peek()
        {
            return !IsEmpty ? front.Peek() : throw new Exception("Empty");
        }

        public void PrintQueue()
        {
            throw new NotImplementedException();
        }
    }
}
