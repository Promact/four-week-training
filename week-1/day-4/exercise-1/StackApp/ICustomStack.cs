using static System.Formats.Asn1.AsnWriter;
using System.Collections.Generic;

namespace StackApp
{
    internal interface ICustomStack<T>
    {
        void Push(T item);
        T Pop();
        bool IsEmpty();
    }

    // Define a custom stack class that implements the interface ICustomStack
    internal class CustomStack<T> : ICustomStack<T>
    {
        // List to store stack items
        private readonly List<T> items = new List<T>();
        public void Push(T item)
        {
            items.Add(item);
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is Empty.");
            }
            int lastIndex = items.Count - 1;
            T item = items[lastIndex];
            items.RemoveAt(lastIndex);
            return item;
        }

        public bool IsEmpty()
        {
            return items.Count() == 0;
        }
    }
}
