using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            Class1 o = new Class1();
            o.i = 100;
            o = o + 5;

            Class1 o1 = new Class1 { i = 100};
            Class1 o2 = new Class1 { i = 50};
            o = o1 - o2;
            Console.WriteLine(o.i);
            Console.ReadLine();
        }
    }

    class Class1
    {
        public int i;
        public static Class1 operator -(Class1 o1, Class1 o2)
        {
            Class1 temp = new Class1();
            temp.i = o1.i + o2.i;
            return temp;
        }
        public static Class1 operator +(Class1 obj, int i)
        {
            Class1 temp = new Class1();
            temp.i = obj.i + i;
            return temp;
        }
    }
}
