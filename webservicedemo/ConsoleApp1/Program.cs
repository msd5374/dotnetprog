using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main1(string[] args)
        {

            localhost.WebService1 ob = new localhost.WebService1();
            Console.WriteLine(ob.HelloWorld());
           ob.HelloWorldAsync();
         Console.WriteLine(ob.add(5,2));
            Console.WriteLine("hello");
            Console.ReadLine();
        }



        static void Main(string[] args)
        {
            //select otion for generation asynchronously in add reference option 
            localhost.WebService1 ob = new localhost.WebService1();
            Console.WriteLine("before"+DateTime.Now.ToLongTimeString());
            ob.HelloWorldCompleted += Ob_HelloWorldCompleted;

            ob.HelloWorldAsync();

            Console.WriteLine("after" + DateTime.Now.ToLongTimeString());
            
        
            Console.ReadLine();
        }

        private static void Ob_HelloWorldCompleted(object sender, localhost.HelloWorldCompletedEventArgs e)
        {
            Console.WriteLine("return value:"+DateTime.Now.ToLongTimeString());
            Console.WriteLine(e.Result);

            //throw new NotImplementedException();
        }
    }
}
