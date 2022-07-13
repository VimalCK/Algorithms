using System;
using System.Collections.Generic;
using Xunit;

namespace Algorithms.LeetCode.Easy
{
    /*
     * Implement a first in first out (FIFO) queue using only two stacks. The implemented queue should support all the functions of 
     * a normal queue (push, peek, pop, and empty).
     * 
     * Implement the MyQueue class:
     * 
     * void push(int x) Pushes element x to the back of the queue.
     * int pop() Removes the element from the front of the queue and returns it.
     * int peek() Returns the element at the front of the queue.
     * boolean empty() Returns true if the queue is empty, false otherwise.
     * 
     * Notes: You must use only standard operations of a stack, which means only push to top, peek/pop from top, size, 
     * and is empty operations are valid. Depending on your language, the stack may not be supported natively. 
     * You may simulate a stack using a list or deque (double-ended queue) as long as you use only a stack's standard operations.
     * 
     */
    public class QueueUsingStack : TheoryData<string[], object[], object?[]>
    {
        public QueueUsingStack()
        {
            Add(new[] { "push", "push", "peek", "pop", "empty" }, new object[] { 1, 2 }, new object?[] { null, null, 1, 1, false });

        }

        [Theory]
        [ClassData(typeof(QueueUsingStack))]
        public void TestQueue(string[] instructions, object[] values, object?[] expectedResult)
        {
            var index = 0;
            var queue = new MyQueue();
            var result = new object?[instructions.Length];

            foreach (var instruction in instructions)
            {
                switch (instruction)
                {
                    case "push":
                        queue.Push((int)values[index]);
                        result[index] = null;
                        break;
                    case "pop":
                        result[index] = queue.Pop();
                        break;
                    case "peek":
                        result[index] = queue.Peek();
                        break;
                    case "empty":
                        result[index] = queue.Empty();
                        break;
                    default:
                        break;
                }

                index++;
            }

            Assert.True(expectedResult.AreEqual(result));
        }
    }

    public class MyQueue
    {
        Stack<int> stack1 = new Stack<int>();
        Stack<int> stack2 = new Stack<int>();

        public MyQueue()
        {

        }

        public void Push(int x)
        {
            stack1.Push(x);
        }

        public int Pop()
        {
            if (stack2.Count == 0)
            {
                while (stack1.Count > 0)
                {
                    stack2.Push(stack1.Pop());
                }
            }

            return stack2.Pop();
        }

        public int Peek()
        {
            if (stack2.Count == 0)
            {
                while (stack1.Count > 0)
                {
                    stack2.Push(stack1.Pop());
                }
            }

            return stack2.Peek();
        }

        public bool Empty()
        {
            return stack1.Count == 0 && stack2.Count == 0;
        }
    }
}
