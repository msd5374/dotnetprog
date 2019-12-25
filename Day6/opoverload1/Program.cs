using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opoverload1
{
    class Program
    {
        static void Main(string[] args)
        {


            Demo d = new Demo();
            d.i = 100;
            d = d + 5;
            Console.WriteLine(d.i);

            Demo d2 = new Demo { i = 100 };
            Demo d3 = new Demo { i = 50 };
            d = d2 - d3;
            Console.WriteLine(d.i);

            Console.ReadLine();
        }
    }


    class Demo
    {
        public int i;
        

        public static Demo operator +(Demo d1,int i)
        {
            Demo tem = new Demo();
            tem.i = d1.i + i;
            return tem;
        }


        public static Demo operator -(Demo d1,Demo d2)
        {
            
            Demo temp = new Demo();
            temp.i = d1.i + d2.i;
            return temp;
            
        }


    }

    

}
