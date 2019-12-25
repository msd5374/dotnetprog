using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lambda1
{
    class Program
    {

        static int GetDouble(int i)
        {
            return i * 2;
        }
        static int Add(int i, int j)
        {
            return i + j;
        }

        static void Add1(int i,int j)
        {
            Console.WriteLine(i+j+"add:");
        }

        static bool IsEven(int i)
        {
            if (i % 2 == 0)
                return true;
            else
                return false;
        }
        //static bool Func1(Employee obj)
        //{
        //    if (obj.Basic > 1000)
        //        return true;
        //    else
        //        return false;
        //}


        static void Main()
        {
            //public delegate int MyDel(int i);
              //or
            Func<int,int> o=GetDouble;
          

            Func<int, int> o1 = delegate (int i) { return i * 2; };

            Func<int,int> o2 = i => i * 2;
            Console.WriteLine(o2(10));

            Func<int, int, int> ob = (i, j) => i + j;
            Console.WriteLine(ob(10,5));
            Func<int, bool> ob1 = (i) => i % 2==0;
            Console.WriteLine(ob1(6));

            Predicate<int> ob3 = i => i % 2 == 0;  
            //delegate methods must take one input parameter and return a boolean
            Console.WriteLine(ob3(16));

            //when there is no any return type i.e. void at that time use action
            Action<int, int> oac = Add1;
            oac(10, 20);
           
            Console.ReadLine();
        }
    }
}
