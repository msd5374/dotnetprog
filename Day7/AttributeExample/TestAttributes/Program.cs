using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAttributes
{
    class Program
    {
        static void Main()
        {
            Type t = typeof(Class1);
            object[] objArr = t.GetCustomAttributes(false);
            foreach (Attribute a in objArr)
            {
                Console.WriteLine(a.GetType().Name);
            }
            Console.ReadLine();
        }
    }
    [MyAttributes.Attribute1("aaa")]
    [Serializable]
    class Class1
    {

    }
}
