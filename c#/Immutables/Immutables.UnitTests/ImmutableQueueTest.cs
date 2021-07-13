using NUnit.Framework;
using Immutables;
using System;

namespace Tests
{
    public class ImmutableQueueTest
    {
        private IQueue<int> CreateQueue(params int[] values)
        {
            IQueue<int> q = new Queue<int>();
            foreach (var value in values)
                q = q.Enqueue(value);

            return q;
        }


        //[Test]
        public void EmptyCheck_CreateQueueFilledAndEmpty_Boolean()
        {
            Assert.IsTrue(CreateQueue().IsEmpty);
            Assert.IsFalse(CreateQueue(1, 2, 3).IsEmpty);
            Assert.IsTrue(CreateQueue(1).Dequeue().IsEmpty);
            Assert.IsFalse(CreateQueue(1, 2, 3).Dequeue().IsEmpty);
            Assert.IsTrue(!CreateQueue(1, 2, 3).Dequeue().Dequeue().IsEmpty);
        }

        //[Test]
        public void IsValueCorrect_AfterDequeue_True()
        {
            var q = CreateQueue(1, 2, 3);
            Assert.IsTrue(1 == q.Peek());

            q = q.Dequeue();
            Assert.IsTrue(2 == q.Peek());

            q = q.Dequeue();
            Assert.IsTrue(3 == q.Peek());
        }

        //[Test]
        public void ThrowsException_EmptyQueueDequeue_Exception()
        {
            Assert.Throws<Exception>(() => CreateQueue().Dequeue());
            Assert.Throws<Exception>(() => CreateQueue().Peek());
        }

        //[Test]
        public void Immutabablity_EnqueueDequeue_True()
        {
            var q = CreateQueue(1);
            q.Enqueue(2); //should not change q
            Assert.IsTrue(1 == q.Peek());

            q.Dequeue(); //should not change q
            Assert.IsTrue(1 == q.Peek());

            var q2 = q.Enqueue(2);
            var q3 = q2.Dequeue(); // Equal to the original queue, q but not the same object
            Assert.IsTrue(q != q3);
        }

    }
}