namespace StackApp
{
    using System;
    using System.Collections.Generic;


    internal class CustomStack<T> : ICustomStack<int>
    {
        bool ICustomStack<int>.IsEmpty()
        {
           
            throw new NotImplementedException();
        }

        int ICustomStack<int>.Pop()
        {

            throw new NotImplementedException();
        }

        void ICustomStack<int>.Push(int item)
        {
           


           
            throw new NotImplementedException();
        }
    }




}