using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    class Program_nullable
    {
        static void Main(string[] args)
        {
            int? i = 10;        //?->for showig as nullable
            //i = null;  //gets an error while assigning null without nullable
         int   j = 0;

            if (i != null)
                j = (int)i;
            else
                j = 0;

            //method-2
            if (i.HasValue)
                j = i.Value;
            else
                j = 0;
            //method-3
            j = i.GetValueOrDefault();

            j = i.GetValueOrDefault(0);

            //m4
            j = i ?? 10;


            Console.WriteLine(j);



            Console.ReadLine();
        }
    }
}




