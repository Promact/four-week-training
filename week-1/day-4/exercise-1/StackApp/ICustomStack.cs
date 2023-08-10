namespace StackApp
{
    public interface ICustomStack<T>
    {
        void Push(T item);
        T Pop();
        bool IsEmpty();
    }
}
