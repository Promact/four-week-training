namespace StackApp
{
    class Stack<T>
    {
        private List<T> list = new List<T>();

        public void Push(T item)
        {
            list.Add(item);
        }

        public T Pop()
        {
            if (list.Count == 0)
                throw new Exception("Stack is Empty");
            T item = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            return item;
        }
        public bool IsEmpty()
        {
            return list.Count == 0;
        }
    }


}
class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}