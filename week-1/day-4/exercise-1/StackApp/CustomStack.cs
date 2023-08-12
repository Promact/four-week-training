using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackApp
{
    public class CustomStack<T> : ICustomStack<T>
    {
        private List<T> _items;
        public CustomStack()
        {
            _items = new List<T>();
        }
        public bool IsEmpty()
        {
            return _items.Count == 0;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty!!!");
            }

            int lastIndex = _items.Count - 1;
            T PoppedItem = _items[lastIndex];
            _items.RemoveAt(lastIndex);
            return PoppedItem;
        }

        public void Push(T item)
        {
            _items.Add(item);
        }
    }
}
