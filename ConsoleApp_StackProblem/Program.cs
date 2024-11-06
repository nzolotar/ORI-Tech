using System;
using System.Collections.Generic;

namespace ConsoleApp_StackProblem
{
    //create a class implemeting stack with Push, Pop and peek

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // Create a new stack
            CustomStack<int> stack = new CustomStack<int>();

            // Push some items
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            // Peek at top item
            Console.WriteLine(stack.Peek());  // Output: 3

            // Pop items
            int item = stack.Pop();  // item = 3
            Console.WriteLine(item);  // Output: 3

            // Check if stack is empty
            Console.WriteLine(stack.IsEmpty);  // Output: False

            // Get current count
            Console.WriteLine(stack.Count);  // Output: 2

            // Using TryPop and TryPeek
            if (stack.TryPeek(out int peekResult))
            {
                Console.WriteLine($"Top item is: {peekResult}");
            }
            if (stack.TryPop(out int popResult))
            {
                Console.WriteLine($"Popped item: {popResult}");
            }

            // Create a stack with max size
            CustomStack<string> boundedStack = new CustomStack<string>(maxSize: 3);
        }


        public class CustomStack<T>
        {
            private List<T> items;
            private int maxSize;

            public int Count => items.Count;
            public bool IsEmpty => Count == 0;

            // Constructor with optional max size
            public CustomStack(int maxSize = int.MaxValue)
            {
                if (maxSize <= 0)
                    throw new ArgumentException("Stack size must be positive", nameof(maxSize));

                this.maxSize = maxSize;
                items = new List<T>();
            }

            // Push: Adds an item to the top of the stack
            public void Push(T item)
            {
                if (Count >= maxSize)
                    throw new InvalidOperationException("Stack is full");

                items.Add(item);
            }

            // Pop: Removes and returns the top item from the stack
            public T Pop()
            {
                if (IsEmpty)
                    throw new InvalidOperationException("Stack is empty");

                int lastIndex = Count - 1;
                T item = items[lastIndex];
                items.RemoveAt(lastIndex);
                return item;
            }

            // Peek: Returns the top item without removing it
            public T Peek()
            {
                if (IsEmpty)
                    throw new InvalidOperationException("Stack is empty");

                return items[Count - 1];
            }

            // Clear: Removes all items from the stack
            public void Clear()
            {
                items.Clear();
            }

            // ToArray: Converts stack to array (top item will be at the end)
            public T[] ToArray()
            {
                return items.ToArray();
            }

            // TryPeek: Safely attempts to peek at the top item
            public bool TryPeek(out T result)
            {
                if (IsEmpty)
                {
                    result = default;
                    return false;
                }

                result = items[Count - 1];
                return true;
            }

            // TryPop: Safely attempts to pop the top item
            public bool TryPop(out T result)
            {
                if (IsEmpty)
                {
                    result = default;
                    return false;
                }

                result = Pop();
                return true;
            }
        }
    }
}
