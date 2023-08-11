namespace StackApp
{
    internal interface ICustomStack<T>
    {
        void Push(T item);
        T Pop();
        bool IsEmpty();
    }

    public class CustomStack<T> : ICustomStack<T>
    {
        private List<T> data;

        public CustomStack()
        {
            data = new List<T>();
        }

        public void Push(T item)
        {
            data.Add(item);
        }

        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("The Stack is empty.");

            int lastIndex = data.Count - 1;
            T item = data[lastIndex];
            data.RemoveAt(lastIndex);
            return item;
        }

        public bool IsEmpty()
        {
            return data.Count == 0;
        }

    }
}
