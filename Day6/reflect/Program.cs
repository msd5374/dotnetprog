using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reflect
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly asm = Assembly.LoadFrom(@"C:\Users\labuser\Documents\shubham_m\Day1\assign2\bin\Debug\assign2.exe");
            Console.WriteLine(asm.FullName);
            Console.WriteLine(asm.GetName().Name);

            Type[] arrTypes = asm.GetTypes();
                      foreach(Type t in arrTypes)
            {
                Console.WriteLine(""+t.Name);
                //MethodInfo[] arrMethods = t.GetMethods();

            }
            Console.WriteLine(asm);
            Console.ReadLine();
        }
    }
}
