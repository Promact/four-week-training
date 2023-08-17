namespace StackApp
{
    internal class ICustomStack<T>
    {
        private  List<T> items = new List<T>();

        public void Push(T item)
        {
            items.Add(item);
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            int lastIndex = items.Count - 1;
            T poppedItem = items[lastIndex];
            items.RemoveAt(lastIndex);
            return poppedItem;
        }

        public bool IsEmpty()
        {
            return items.Count == 0;
        }
    }
}
