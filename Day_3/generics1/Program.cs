using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generics1
{
    class Program
    {
        static void Main(string[] args)
        {
            //IntegerStack obj1 = new IntegerStack(3);
            //obj1.Push(10);
            //obj1.Push(20);
            //obj1.Push(30);
            //Console.WriteLine(obj1.Pop());
            //Console.WriteLine(obj1.Pop());
            //Console.WriteLine(obj1.Pop());

            //StringStack obj2 = new StringStack(3);
            //obj2.Push("a");
            //obj2.Push("b");
            //obj2.Push("c");
            //Console.WriteLine(obj2.Pop());
            //Console.WriteLine(obj2.Pop());
            //Console.WriteLine(obj2.Pop());

            MyStack<int> obj1 = new MyStack<int>(3);
            obj1.Push(10);
            obj1.Push(20);
            obj1.Push(30);
            Console.WriteLine(obj1.Pop());
            Console.WriteLine(obj1.Pop());
            Console.WriteLine(obj1.Pop());

            MyStack<string> obj2 = new MyStack<string>(3);
            obj2.Push("a");
            obj2.Push("b");
            obj2.Push("c");
            Console.WriteLine(obj2.Pop());
            Console.WriteLine(obj2.Pop());
            Console.WriteLine(obj2.Pop());


            Console.ReadLine();
        }
    }
    class IntegerStack
    {
        int[] arr;
        public IntegerStack(int Size)
        {
            arr = new int[Size];
        }
        int Pos = -1;
        public void Push(int i)
        {
            if (Pos == (arr.Length - 1))
                throw new Exception("Stack full");
            arr[++Pos] = i;
        }
        public int Pop()
        {
            if (Pos == -1)
                throw new Exception("Stack Empty");
            return arr[Pos--];
        }
    }
    class StringStack
    {
        string[] arr;
        public StringStack(int Size)
        {
            arr = new string[Size];
        }
        int Pos = -1;
        public void Push(string i)
        {
            if (Pos == (arr.Length - 1))
                throw new Exception("Stack full");
            arr[++Pos] = i;
        }
        public string Pop()
        {
            if (Pos == -1)
                throw new Exception("Stack Empty");
            return arr[Pos--];
        }
    }
    class MyStack<T>
    //where T : struct - T must be a Value Type
    //where T : class - T must be a Reference Type
    //where T : className - T must be the className or a derived class
    //where T : InterfaceName - T must be a class that implements the interface
    //where T : new() //- T must have a no parameter constructor
    //where T : className, InterfaceName, new()

    {
        T[] arr;
        public MyStack(int Size)
        {
            //T obj = new T();
            arr = new T[Size];
        }
        int Pos = -1;
        public void Push(T i)
        {
            if (Pos == (arr.Length - 1))
                throw new Exception("Stack full");
            arr[++Pos] = i;
        }
        public T Pop()
        {
            if (Pos == -1)
                throw new Exception("Stack Empty");
            return arr[Pos--];
        }
    }

}
