using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace thread1
{
    class Program
    {
        public delegate int mydel(int i);
        static void Main11(string[] args)
        {
            Thread t = new Thread(new ThreadStart(disp));
            //or
            Thread t1 = new Thread(disp);

            t.Start(); //work like delegate.BeginInvoke
            Thread.Sleep(1200);

            Thread t3 = new Thread(() => displVal(10));
            //here we use lambda function cause in thread we cant call function {use return func}
            t3.Start();
            //t3.Priority = ThreadPriority.Highest;
            t1.Start();  //it started once only not t.start() multiple times not restarted


            //when we have call return function at that time thread doesnt allow so use delegate
            //mydel md = displVal;
            //md.BeginInvoke(10, null, null);

            //another way to call param function
            Thread t5 = new Thread(new ParameterizedThreadStart(displVal1));
            t5.Start(new Temp { i = 110 });  //object initializer
                                             // t5.Join();

            Console.WriteLine("main thread");
            Console.ReadLine();
        }

        static void disp()
        {
            Thread.Sleep(1000);
            Console.WriteLine("hi i am in thread process");
        }
        static int displVal(int i)
        {
            Console.WriteLine("ival is:" + i);
            return i;
        }
        static void displVal1(object o)
        {
            Temp obj = (Temp)o;
            Console.WriteLine("ival is:" + obj.i);

        }

        public class Temp
        {
            public int i;
        }
    }
}

namespace thread2
{
    class ThreadDemo
    {
        static void Main2()
        {
            Thread t = new Thread(new ThreadStart(method1));
            Thread t1 = new Thread(method2);

            t.Start();
            t.Abort();  //thread started and aborted also
            t.Join();


            t1.Start();
            //t1.Suspend(); //it works if thread is not already suspended

        }


        static void method1()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine("m1" + i);
            }
        }
        static void method2()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine("m2" + i);
            }
        }
    }

}


namespace thread3
{
    class DemoThread
    {

        static void poolFun1(Object o)
        {
            for (int i = 0; i < 30; i++)
            {
                Console.WriteLine("first thread: " + o.ToString() + i);
                Thread.Sleep(500);
            }
        }
        static void poolFun2(Object o)
        {
            for (int i = 0; i < 30; i++)
            {

                Console.WriteLine("second thread" + i);
            }
        }


        static void Main()
        {
            int workerThread;
            int completionPort;
            //fast and dis:cant control
            ThreadPool.QueueUserWorkItem(new WaitCallback(poolFun1), "shubham");

            //ThreadPool.QueueUserWorkItem(new WaitCallback(poolFun2));
                 //types:delegate and thread
            //ThreadPool.GetMinThreads(out workerThread, out completionPort);
            //Console.WriteLine(workerThread);
            //Console.WriteLine(completionPort);

            //https://www.learncsharptutorial.com/threadpooling-csharp-example.php
            ThreadPool.GetMaxThreads(out workerThread, out  completionPort);
            Console.WriteLine("port"+completionPort);
            Console.WriteLine(workerThread);
            ThreadPool.GetAvailableThreads(out workerThread, out completionPort);
            Console.WriteLine(workerThread);

            Console.ReadLine();
        }
    }
}

namespace thread4
{
    class pro1
    {
        static object lockObject = new object();
        static int i = 0;
        static void Main22()
        {
            Thread tp = new Thread(funLock);
            tp.Start();
            Thread tp1 = new Thread(funLock1);
            tp1.Start();

            Thread tp2 = new Thread(FuncInterlocked);
            tp2.Start();
            Console.ReadLine();
        }

        static void funLock()
        {
            lock (lockObject)    //Monitor.Enter(lockObject)
                                 //ensures that one thread is executing a piece of code at one time
                                 // lock for the piece of code for only one thread
                                 //If another thread tries to enter a locked code, it will wait, block, until the object is released.

            {
                i++;
                Console.WriteLine("first unlocked" + i);
                i++;
                Console.WriteLine("first unlocked" + i);
                i++;
                Console.WriteLine("first unlocked" + i);
                i++;
                Console.WriteLine("first unlocked" + i);
                i++;
                Console.WriteLine("first unlocked" + i);
                i++;
                Console.WriteLine("first unlocked" + i); i++;
                Console.WriteLine("first unlocked" + i); i++;
                Console.WriteLine("first unlocked" + i); i++;
                Console.WriteLine("first unlocked" + i); i++;
                Console.WriteLine("first unlocked" + i); i++;
                Console.WriteLine("first unlocked" + i); i++;
                Console.WriteLine("first unlocked" + i);
            } //Monitor.Exit(lockObject)
        }

        static void funLock1()
        {
            Monitor.Enter(lockObject);
                {
                
                i++;

                Console.WriteLine("second locked"+i);i++;

                Console.WriteLine("second locked"+i);i++;

                Console.WriteLine("second locked"+i);i++;

                Console.WriteLine("second locked"+i);i++;

                Console.WriteLine("second locked"+i);i++;

                Console.WriteLine("second locked"+i);i++;

                Console.WriteLine("second locked"+i);i++;

                Console.WriteLine("second locked"+i);i++;

                Console.WriteLine("second locked"+i);

                Thread.Sleep(5000);

            }Monitor.Exit(lockObject);
        }


        static void FuncInterlocked()
        {

            //It safely changes the value of a shared variable from multiple threads. 
            //This is possible with the lock statement. 
            //But you can instead use the Interlocked type for simpler and faster code.
            Interlocked.Add(ref i, 10);
            Console.WriteLine("Third Interlocked " + i.ToString());
            Interlocked.Increment(ref i);
            Console.WriteLine("Third Interlocked " + i.ToString());
            Interlocked.Decrement(ref i);
            Console.WriteLine("Third Interlocked " + i.ToString());
            Interlocked.Exchange(ref i, 100);
            Console.WriteLine("Third Interlocked " + i.ToString());
        }
    }
}