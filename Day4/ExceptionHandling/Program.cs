using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling1
{
    class Program
    {
        static void Main1(string[] args)
        {
            int i;
            try
            {
                Class1 o = new Class1();
                //o = null;
                i = int.Parse(Console.ReadLine());
                o.Data = 100 / i;
                Console.WriteLine("no exceptions");
            }
            catch
            {
                Console.WriteLine("exception handled");
            }


            Console.ReadLine();
        }
        static void Main2()
        {
            int i;
            try
            {
                Class1 o = new Class1();
                o = null;
                i = int.Parse(Console.ReadLine());
                o.Data = 100 / i;
                Console.WriteLine("no exceptions");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("format exception handled");
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("null ref exception handled");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("dbz exception handled");
            }


            Console.ReadLine();
        }

        //finally
        static void Main3()
        {
            int i;
            try
            {
                Class1 o = new Class1();
               // o = null;
                i = int.Parse(Console.ReadLine());
                o.Data = 100 / i;
                Console.WriteLine("no exceptions");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("format exception handled");
            }
            //catch (NullReferenceException ex)
            //{
            //    Console.WriteLine("null ref exception handled");
            //}
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("dbz exception handled");
            }
            finally
            {
                Console.WriteLine("finally code here(common code)");
                //Console.ReadLine();
            }
            Console.WriteLine("after finally");
            Console.ReadLine();
        }


        //catch exception with base class
        static void Main4()
        {
            int i;
            try
            {
                Class1 o = new Class1();
                o = null;
                i = int.Parse(Console.ReadLine());
                o.Data = 100 / i;
                Console.WriteLine("no exceptions");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("format exception handled");
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("null ref exception handled");
            }
            catch (ArithmeticException ex)
            {
                Console.WriteLine("dbz exception handled");
            }
            catch (Exception ex)
            {
                Console.WriteLine("all other exceptions caught here");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("finally code here(common code)");
                Console.ReadLine();
            }

            Console.ReadLine();
        }

        //nested try blocks, each having its own catch and finally
        static void Main5()
        {
            int i;
            Class1 o = new Class1();
            try
            {
                o = null;
                i = int.Parse(Console.ReadLine());
                o.Data = 100 / i;
                Console.WriteLine("no exceptions");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("format exception handled... \n pls enter only numbers");
                try
                {
                    i = int.Parse(Console.ReadLine());
                    o.Data = 100 / i;
                }
                catch
                {
                    Console.WriteLine("errors occurred");
                }
                finally { Console.WriteLine("inner finally"); }
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("null ref exception handled");
            }
            catch (ArithmeticException ex)
            {
                Console.WriteLine("dbz exception handled");
            }
            catch (Exception ex)
            {
                Console.WriteLine("all other exceptions caught here");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("finally code here(common code)");
                Console.ReadLine();
            }

            Console.ReadLine();
        }



    }

    class Class1
    {
        private int mData;
        public int Data
        {
            get
            {
                return mData;
            }
            set
            {
                mData = value;
            }
        }
    }

}


namespace ExceptionHandling2
{
    class Program
    {
        static void Main()
        {
            int i;
            try
            {
                Class1 o = new Class1();
                i = int.Parse(Console.ReadLine());
                o.Data = i;
                Console.WriteLine("no exceptions");
            }
            catch (InvalidDataException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            Console.ReadLine();
        }
    }
    class Class1
    {
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
                    //throw an exception here
                    //Exception ex = new Exception("Invalid Data");
                    //throw ex;

                    //throw new Exception("Invalid Data");
                    throw new InvalidDataException("Invalid Data");

                }
            }
        }

    }

   public class InvalidDataException : ApplicationException
    {
        public InvalidDataException(string message) : base(message)
        {
        }
    }
}