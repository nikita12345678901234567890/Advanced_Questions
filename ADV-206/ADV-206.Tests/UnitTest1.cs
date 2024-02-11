using System;

namespace ADV_206.Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(new object[] { new int[] { 1, 2, 3, 4, 5, 6 } })]
        public void TestQueue(int[] array)
        {
            ContainerQueue<int> queue = new ContainerQueue<int>(new LinkedListContainer<int>(new LinkedList<int>(array)));
            Assert.Equal(array.Length, queue.Count);
            for (int i = 0; i < array.Length; i++)
            {
                Assert.Equal(array.Length - i, queue.Count);
                Assert.Equal(array[i], queue.Peek());
                Assert.Equal(array[i], queue.Dequeue());
            }

            //Assert.ThrowsAny<Exception>(() => queue.Dequeue);

            queue.Enqueue(1);
            queue.Enqueue(2);
            Assert.Equal(1, queue.Dequeue());
            Assert.Equal(2, queue.Dequeue());
            Assert.Equal(0, queue.Count);
        }


        [Theory]
        [InlineData(new object[] { new int[] { 6, 5, 4, 3, 2, 1 } })]
        public void TestStack(int[] array)
        {
            ContainerStack<int> stack = new(new LinkedListContainer<int>(new(array)));
            Assert.Equal(array.Length, stack.Count);
            for (int i = array.Length - 1; i > 0; i--)
            {
                Assert.Equal(array.Length - i, stack.Count);
                Assert.Equal(array[i], stack.Peek());
                Assert.Equal(array[i], stack.Pop());
            }

            //Assert.ThrowsAny<Exception>(() => stack.Pop);

            stack.Push(1);
            stack.Push(2);
            Assert.Equal(2, stack.Pop());
            Assert.Equal(1, stack.Pop());
            Assert.Equal(0, stack.Count);
        }
    }
}