using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    public class Stack<T>
    {
        public List<T> items;

        public Stack()
        {
            items = new List<T>();
        }

        public void push(T item)
        {
            items.Add(item);
        }

        public T pop()
        {
            if (items.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Items list is empty");
            }

            T poppedItem = items[items.Count - 1];
            items.RemoveAt(items.Count - 1);
            return poppedItem;
        }

        public bool isEmpty()
        {
            return items.Count == 0;
        }

    }

    public class CustomObject
    {
        public int Value { get; set; }

        public CustomObject(int value)
        {
            Value = value;
        }
    }
}
