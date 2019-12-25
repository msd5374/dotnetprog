using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstprog
{

    class Program
    {
        static void Main(string[] args)
        {
            #region basic
            System.Console.WriteLine("----------first program-----------");
            //System.Console.ReadLine();

            //System.Console.WriteLine("addition of number");

            pro1 p = new pro1();

            System.Console.WriteLine(p.add(10, 20));
            Console.WriteLine(p.add(10));

            System.Console.WriteLine("naming parameter");

            //Console.WriteLine(p.add(b: 50));     //error
            Console.WriteLine(p.add(a: 50));
            Console.WriteLine(p.add(a: 40, b: 50));
            Console.WriteLine(p.display("hi"));

            Console.WriteLine(p.display(a: "abc", b: "abc1"));
            #endregion



            #region Property
            System.Console.WriteLine("starting property");
            /*
            Pro2 pobj = new Pro2();
            pobj.Property1 = 123;
            Console.WriteLine(pobj.Property1);

            pobj.Property2 = "hello this is done using property";
            Console.WriteLine(pobj.Property2);

            pobj.property3 = 212112;
            Console.WriteLine(pobj.property3);


            pobj.Property4 = 45;  //if 100 or greater then the o/p is invalid and print 0
            Console.WriteLine(pobj.Property4);

    */

            #endregion


            #region constructor_property
            Pro3 pp = new Pro3();

            Pro3 pp1 = new Pro3(22);

            Pro2 p5 = new Pro2(55);
            Console.WriteLine(p5.Property3);


            p5 = null;
            GC.Collect();   //explicit call the destructor it will only work when u make any value as null

            #endregion



            #region static_var_method
            pro4 p4 = new pro4();

            pro4.display();
          Console.WriteLine(pro4.i5 = 10);

            #endregion

            #region static_class
            //pro6 ppp = new pro6(); //error:cant initiate static class
            pro6.dis();
            #endregion

            System.Console.ReadLine();


        }
    }
}

    #region class_basic
    class pro1
    {
        public int add(int a,int b=0)
        {
            return a + b;
        }
        public string display(string a,string b="")
        {
            return a + b;

        }  
    }
    #endregion



    #region class_property
    class Pro2
    {

        //parametrized constructor using property
        public Pro2(int Property3)
        {
            this.Property3 = Property3;
        }




        private string property2;   //field    main usage is it reduces code load of getter and setter
        public string Property2  //property
        {
            set { property2 = value; }  //value=system keyword
            get { return property2; }
        }

        private int property1;
        public int Property1
        {
            set { property1 = value; }
            get { return property1; }

        }

        public int Property3   //automatic property as this is (int) type
            //to see implementation go developer cmd and add file and say 'ildasm'
        {
            set;
            get;
        }


  



        private int property4;
          public int Property4
        {
            set
            {
                if (value < 100)
                    property4 = value;
                else
                    Console.WriteLine("invalid");
            }
            get
            {
                return property4;
            }

        }

    

    }
    #endregion


    #region class_constructor
    class Pro3
    {
        public Pro3()
        {
            //Console.Write("heee");  //it will print and cursor will be here only not on next line {act as print in java}
          Console.WriteLine("default constructor");  //it will print and cursor goes in next line
        }

       private int i;
        public Pro3(int i)
        {
            this.i = i;
            Console.WriteLine(i);
        }


         ~Pro3()
            {
           Console.WriteLine("destructor");  //explicit destructor
          Console.ReadLine();

        }
 }
#endregion



#region class_static:-var_method
class pro4
    {
  //whenever we are decalring the static method and variable then at that time in main call using classname
              public static int i5;
    public int i;


        public static void display()
        {
            System.Console.WriteLine("hi this is static method");
        }

  static pro4()  //only static member should be in static constructor ,access modofier not allowed in static const
    {
        i5 = 0;
        Console.WriteLine("hey static hu mein");
    }
   public pro4()
    {
        Console.WriteLine("hey non static hu mein");
    }


}
#endregion


#region class_static
public static class pro6
{
    //in static class we cant use non static method and var,it should be static both
    //public void disp()
    //{
    //--------------error------------
    //}

    //public int i;  //----------error---------


    public static void dis()
    {
        Console.WriteLine("hi8");
    }
      

    //whenever we use static property at that time it should conatins static member also

    //private static string prop;
    //public static string Property9
    //    {
    //    set;
    //    get;
    //    }

}
#endregion


