using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shareass1
{
    class Program
    {
        static void Main(string[] args)
        {
            sharedassem.Class1 o = new sharedassem.Class1();
            Console.WriteLine(o.hi());
            Console.ReadLine();
        }
    }
}
