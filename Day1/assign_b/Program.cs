using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Assign1
{
    class Program
    {
        static void Main(string[] args)
        {

            Employee e = new Employee("shubham", 0, 7000);
            Console.WriteLine(" empname: " + e.EmpName + " deptno: " + e.DeptNo + " basic: " + e.Basic);

            Console.WriteLine();

            Employee e1 = new Employee("", 20, 8000);
            Console.WriteLine(" empname: " + e1.EmpName + " deptno: " + e1.DeptNo + " basic: " + e1.Basic);



            Console.WriteLine();

            Console.WriteLine(e.netSal(ta: 500));   //named parameters
            Console.WriteLine();

            Console.WriteLine("count:");

            Console.WriteLine(e1.EmpNo);

             System.Console.ReadLine();
        }
    }
}



class Employee
{
    private int empNo;
    private string empName;
    private short deptNo;
    private decimal basic;
    public int ta; //travel allowance
    public int ra; //reduction
    public static int count = 0;





    public Employee(string EmpName = "ab", short DeptNo = 4, decimal Basic = 6000)
    {

    
        count++;
        this.empNo = count;
        this.EmpName = EmpName;
        this.DeptNo = DeptNo;
        this.Basic = Basic;

    }


    #region netsal
    public decimal netSal(int ta = 1000, int ra = 2000)
    {
        Console.WriteLine("net salary: ");
        return Basic + ta - ra;
    }
    #endregion


    #region property


    public int EmpNo
    {
        get { return empNo; }
    }

   

    public string EmpName
    {
        set
        {
            if (value.Equals(""))
            {
                Console.WriteLine("empname not be null");
            }
            else
            {
                empName = value;
            }
        }
        get
        {
            return empName;
        }
    }

    public short DeptNo
    {
        set
        {
            if (value > 0)
            {
                deptNo = value;
            }
            else
            {
                Console.WriteLine("invalid deptno");
            }
        }
        get
        {
            return deptNo;
        }
    }

    public decimal Basic
    {
        set
        {
            if (value > 5000 && value < 12000)
            {
                basic = value;
            }
            else
            {
                Console.WriteLine("out off range");
            }
        }
        get
        {
            return basic;
        }
    }
    #endregion



}

