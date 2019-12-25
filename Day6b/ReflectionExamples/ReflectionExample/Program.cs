using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionExample
{
    class Program
    {
        static void Main()
        {
            Assembly asm = Assembly.LoadFrom(@"C:\Vikram\Day1\BasicClassConcepts\bin\Debug\BasicClassConcepts.exe");
            Console.WriteLine(asm.FullName);
            //Console.WriteLine(asm.GetName().Name);

            Type[] arrTypes = asm.GetTypes();

            foreach (Type t in arrTypes)
            {
                Console.WriteLine("   " +t.Name);
                MethodInfo[] arrMethods = t.GetMethods();


            }

            Console.ReadLine();
        }
    }
}
