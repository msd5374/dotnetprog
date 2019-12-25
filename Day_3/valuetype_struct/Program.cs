using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace valuetype_struct
{
    class Program
    {
        static void Main(string[] args)
        {
            //Demo d = new Demo();
            //d.x = 10;
            //d.y = 20;
            //Console.WriteLine(d.x);
            //Console.WriteLine(d.y);

            //Demo d1 = new Demo(200, 300);
            //Console.WriteLine(d1.x);
            //Console.WriteLine(d1.y);

            //Console.WriteLine(display());
            display(TimeOfDay.morning);
            TimeOfDay t = new TimeOfDay();
            Console.WriteLine((int)TimeOfDay.evening);
            Console.ReadLine();
        }


        public enum TimeOfDay
        {
            morning=40,
            afternoon,
            evening,
            night
        }

        static void display(TimeOfDay t)
        {
            if (t==TimeOfDay.morning)
                Console.WriteLine("good morning");
            else if(t==TimeOfDay.afternoon)
                Console.WriteLine("good afternoon");
            else if(t==TimeOfDay.evening)
                Console.WriteLine("good evening");
            else if(t==TimeOfDay.night)
                Console.WriteLine("good night");
        }


    }


    public struct Demo
    {
        //struct cant be parameterless
        //both the param is assigned on constructor of struct
        public int x, y;

        public Demo(int X, int Y)
        {
            this.x = X;
            this.y = Y;

        }


    }


 

   


}



