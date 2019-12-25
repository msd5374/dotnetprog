using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace implicitvariable
{
    class Program
    {
        static void Main1()
        {
            //implicitvariable
            
            var x = 10;  //it can take any type of variable
            var y = "abc";
            Console.WriteLine(x);
            //Console.WriteLine(y.GetType());
            Console.WriteLine(y);
            Console.ReadLine();
        }
    }
}




namespace AnonymousTypes
{
    public class MainClass
    {
        public static void Main11()
        {
            //Class1 obj = new Class1{i = 0,j = 0 } ;
            //var obj = new {i = 0,j = 0 } ;

            var myCar = new { Color = "Red", Model = "Ferrari", Version = "V1", CurrentSpeed = 75 };
            var myCar2 = new { Color = "Blue", Model = "Merc", Version = "V2", CurrentSpeed = 75 };

            Console.WriteLine("{0} {1} {2} {3}", myCar.Color, myCar.Model, myCar.Version, myCar.CurrentSpeed);
            Console.WriteLine("{0} {1} {2} {3}", myCar2.Color, myCar2.Model, myCar2.Version, myCar2.CurrentSpeed);
            Console.WriteLine();

            Console.WriteLine(myCar.GetType().ToString());
            Console.WriteLine(myCar2.GetType().ToString());
            Console.ReadLine();
        }
    }
}

namespace ExtensionMethods1
{

    //to create the extension method means 
    //1)your own at that time class should be static.
    //2)then next method should be static and in parameter prefix should be this before class(string)

    public static class C1
    {
        public static void MyMethod(this string s)
        {
            Console.WriteLine(s);
        }

        public static void disp(this int i)
        {
            Console.WriteLine(i);
        }
    }
    public class MainClass
    {
        public static void Main()
        {
            string s = "abcde";
            s.MyMethod();
            //or
            //C1.MyMethod(s);

            int i = 10;
            i.disp();
            Console.ReadLine();
        }
    }
}

namespace ExtMethods
{

    //- Extension methods must be declared inside a static class
    //- Mark a method as an extension method by using the --this-- keyword as a modifier 
    //           on the first parameter of the method
    //- Every extension method can be called either from the object 
    //   or statically via the defining static class
    static class ExtMethodClass
    {
        public static void Method1(this int i)
        {
            Console.WriteLine("ext method for int");
        }
        public static void Print(this string i)
        {
            Console.WriteLine(i);
        }
        public static void BaseClassExtMethod(this object i)
        {
            Console.WriteLine(i);
        }
    }

    class Program
    {
        static void Main1()
        {
            int i = 100;

            i.Method1();
            //i.Print();
            i.BaseClassExtMethod();
            ExtMethodClass.Method1(i);

            string s = "aa";
            s.Print();
            s.BaseClassExtMethod();
            ExtMethodClass.Print(s);

            ClsMaths objMaths = new ClsMaths();

            Console.WriteLine(objMaths.Subtract(10, 5));

            Console.ReadLine();
        }
    }

    public interface IMathOperations
    {
        int Add(int a, int b);
        int Multiply(int a, int b);
    }
    public class ClsMaths : IMathOperations
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }
    }
    public static class ExtensionMethodForInterface
    {
        public static int Subtract(this IMathOperations imop, int a, int b)
        {
            return a - b;
        }
    }
}

namespace TryPartialClasses
{
    //partial class is the one in which classname should be same
    //consider there are 5 developer in which willing to do so namespace and class should be same
    //so compiler should be merge all the classes
    public partial class Class1
    {
        public int i;
    }
    public partial class Class1
    {
        public int j;
    }
    public class Program
    {
        static void Main21()
        {
            Class1 o = new Class1();

        }

    }
}


namespace PartialMethods
{
    public class MainClass
    {
        public static void Main33()
        {
            Class1 o = new Class1();
            Console.WriteLine(o.Check());
            Console.ReadLine();
        }
    }

    //Partial methods can only be defined within a partial class.
    //Partial methods must return void.
    //Partial methods can be static or instance level.
    //Partial methods cannnot have out params
    //Partial methods are always implicitly private.
    public partial class Class1
    {
        private bool isValid = true;
        partial void Validate();
        public bool Check()
        {
            Validate();
            return isValid;
        }
    }

    public partial class Class1
    {
        partial void Validate()
        {
            //perform some validation code here
            isValid = false;
        }
    }

}