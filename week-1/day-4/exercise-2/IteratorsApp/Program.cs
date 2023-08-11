using System;
using System.Collections;

namespace IteratorsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FibonacciIterator fibonacciIter = new FibonacciIterator();
            IEnumerator enumerator = fibonacciIter.GetEnumerator();

            for (int i = 0; i < 10; i++)
            {
                enumerator.MoveNext();
                Console.WriteLine(enumerator.Current);
            }
        }
        // https://www.c-sharpcorner.com/UploadFile/5ef30d/understanding-yield-return-in-C-Sharp/
        // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/yield
        
    }
}
public class FibonacciIterator : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        return new FibonacciEnumerator();
    }
}

public class FibonacciEnumerator : IEnumerator
{
    private int prev = 0;
    private int curr = 1;
    private int count = 0;

    public object Current => curr;

    public bool MoveNext()
    {
        if (count == 0)
        {
            count++;
            return true;
        }
        else if (count == 1)
        {
            count++;
            return true;
        }
        else
        {
            count++;
            int nextValue = prev + curr;
            prev = curr;
            curr = nextValue;
            return true;
        }
    }

    public void Reset()
    {
        prev = 0;
        curr = 1;
        count = 0;
    }
}

