using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegatedemo
{
    public delegate void MyDel();
    public delegate int mydelAdd(int a, int b);
    class Program
    {
        static void Main(string[] args)
        {
            MyDel m = new MyDel(display);
            //m();

            //method-2
            //MyDel m1 = display;
            //m1();

            //call multiple method throgh one obj
            //m += new MyDel(display);
            //or
            m += display;
            m();
            Console.WriteLine("removing delegate by '-' ");
            //m -= display;
            //m -= display;
            //m();  //nullrefrence exception cause we are removing both display and calling m so m becomes null

            Console.WriteLine();
            //another option of '+' use combine method
            MyDel mcom = (MyDel)Delegate.Combine(new MyDel(display), new MyDel(display));
            //above creates one                                                                                                                                                      
            mcom();

            //another option of '-' use remove for one and remove all for all
            MyDel mr = (MyDel)Delegate.Remove(mcom,new MyDel(display));
            Console.WriteLine("calling remove method");
            MyDel mr1 = (MyDel)Delegate.RemoveAll(mcom, new MyDel(display));


            //mr();
            //mr1();  //remove all so nullexception

            //for parameterized add new delegate
            mydelAdd madd = add;
            Console.WriteLine();
            Console.WriteLine("addition is:"+madd(10, 20));
            
            System.Console.ReadLine();
        }
        static void display()
        {
            Console.WriteLine("hey this is display method");
        }

        static int add(int a, int b)
        {
            return a + b;
        }
    }


}
