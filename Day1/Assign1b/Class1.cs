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

            Employee e = new Employee(0, "msd", 0, 7000);
            Console.WriteLine("empno: " + e.EmpNo + "  empname: " + e.EmpName + " deptno: " + e.DeptNo + " basic: " + e.Basic);

            Console.WriteLine();

            Employee e1 = new Employee(0, "", 20, 7000);
            Console.WriteLine("empno: " + e1.EmpNo + "  empname: " + e1.EmpName + " deptno: " + e1.DeptNo + " basic: " + e1.Basic);



            Console.WriteLine();

            Console.WriteLine(e.netSal(ta: 500));   //named parameters
            Console.WriteLine();

            Console.WriteLine("count:");

            // Console.WriteLine(e.deptid);
            Console.WriteLine(e1.deptid);



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
    public int ta;
    public int ra;

   
    public static int count = 0;
    public int deptid;




    public Employee(int EmpNo = 0, string EmpName = "", short DeptNo = 0, decimal Basic = 0)
    {

        this.EmpNo = EmpNo;
        count++;
        this.deptid = count;
        this.EmpName = EmpName;
        this.DeptNo = DeptNo;
        this.Basic = Basic;
    }




    #region property

   
    public int Deptid
    {
        get { return deptid; }
    }

    public int EmpNo
    {
        set
        {
            if (value > 0)
            {
                empNo = value;
            }
            else
            {
                Console.WriteLine("invalid empno");
            }
        }
        get
        {
            return empNo;
        }
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

    #region netsal
    public decimal netSal(int ta = 1000, int ra = 2000)
    {
        Console.WriteLine("net salary: ");
        return Basic + ta - ra;
    }
    #endregion


}

