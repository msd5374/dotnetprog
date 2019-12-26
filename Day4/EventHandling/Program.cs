using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandling
{
    class Program
    {
        static void Main()
        {
            Class1 obj = new Class1();
            obj.InvalidData += obj_InvalidData;
            obj.Data = 1000;

            Console.ReadLine();
        }
        static void obj_InvalidData()
        {
            Console.WriteLine("event handled");
        }
    }


    //step 1 : create a delegate class having the same signature as the event handler
    public delegate void InvalidDataEventHandler();
    class Class1
    {
        //step 2 : declare an event (delegate object) of the delegate type
        public event InvalidDataEventHandler InvalidData;

        private int mData;
        public int Data
        {
            get
            {
                return mData;
            }
            set
            {
                if (value < 100)
                    mData = value;
                else
                {
                    InvalidData();
                }
            }
        }

    }

}
