using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexers
{
    class Program
    {
        static void Main()
        {
            Class1 o = new Class1();
            o[0] = 100;
            //o[190840520001] = 100;
            Console.WriteLine(o[0]);
            Console.ReadLine();
        }
    }
    class Class1
    {
        private int[] arr = new int[5];
        public int this[int subscript]
        {
            get { return arr[subscript]; }
            set
            {
                arr[subscript] = value;
            }
        }


  
    }
}
