using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
namespace inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Derived d = new Derived();
        //op:- in base and in derived
               

            System.Console.ReadLine();
        }
    }

    public class Base
    {
        public Base()
        {
            Console.WriteLine("in base class");

        }

    }
    public class Derived : Base
    {

        public Derived()
        {
            Console.WriteLine("in derive class");

        }


    }

}
*/

/*
namespace inheritance2
{
    //access specifier

    class Program
    {
        static void Main(string[] args)
        {
            Derived d = new Derived();
            //as derive class access the base
            //here public,protected,internal,protected internal

            Derived1 d1 = new Derived1();

            //after creating assembly adding refrence to this

            //d.  can access public only
            //as protected not possible cause same and inherited
            //as internal not possible cause refred is in different assembly
            //internal protected not be done cause protected and internal not working


            Base b = new Base();
           //not private:only base Base we are using in class program and protected : program is not derived and not same class
            //internal,public,protected internal

            System.Console.ReadLine();
        }
    }



   public class Base
    {
        public int PUBLIC; //same + outside
        private int PRIVATE; //same class
        protected int PROTECTED; //same class + derived
        internal int INTERNAL;  //same class + same assembly 
        protected internal int PROTECTED_INTERNAL; //same + derievd + same assembly

    }


    public class Derived:Base
    {

    }
   public class Derived1 : accessspec.Class1
    {
       public void dis()
        {
           // this.
                //protected,public,protected internal
        }

    }



}
*/

/*
namespace inheritance3
{
//constructor
public class pro
{
    static void Main()
    {
        Derived d = new Derived(10,20);
        //op:derive parama,default param
        Console.ReadLine();
    }
}

public class Base
{

    public int i;
    public Base()
    {
        this.i = 10;
        Console.WriteLine("default base");
    }
    public Base(int i)
    {
        this.i = i;
        Console.WriteLine("param base");
    }
}
public class Derived : Base
{
    public int j;
    public Derived()
    {
        this.j = 20;
        Console.WriteLine("default derived");

    }
    public Derived(int i,int j)
    {
        this.j = j;
        Console.WriteLine("param derived");

    }
}



}*/


/*
namespace inherit4
{
class pro
{
    static void Main()
    {
        Derived d = new Derived();
        d.disp();  //hide class method through new
        d.disp("heee");  //overload

    //    d.disp3();  //virtual -> override  (virtual decided at run time)

        Base b = new Base();
        //b.disp();
        b.disp3();

        Base b1 = new Derived();
        b1.disp3();  //gets an op from derived
                     // b1.disp();


        //Derived d1 = (Derived)new Base();
        //d1.disp();

        Console.ReadLine();
    }
}


class Base
{
     public void disp()
    {
        Console.WriteLine("in baseclass");
    }

    public virtual void disp3()
    {
        Console.WriteLine("in base as virual method");
    }
}

class Derived:Base
{
    public new void disp()   
       //hide base class and it gets an warning so at that time to avoid this use 'new' keyword
    { 
        Console.WriteLine("in deriveclass");
    }
    public void disp(string s) 
        //overloading method
    {
        Console.WriteLine("display derive "+s);
    }


    public override void disp3() 
        //to override method then base method should be virtual
    {
        Console.WriteLine("in derive using overide and uses virtual");
    }

}

}
*/



namespace abstractdemo
{
    public class prog
    {
        static void Main()
        {

        }
    }


    public abstract class Base
    {

    }

    public class Derived : Base
    {

    }

}