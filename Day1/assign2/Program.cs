using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Assign2
{
    class Program
    {
        static void Main(string[] args)
        {

            Manager m = new Manager("shubham", 10, 6000, 1);
            Console.WriteLine(m.DeptNo);
            Console.WriteLine(m.EmpName);
            Console.WriteLine(m.Basic);
            Console.WriteLine(m.EmpNo);
            m.create();

            GeneralManager g = new GeneralManager("mayuresh", 5, 7000, 2, "free trip to goa");
            Console.WriteLine(g.DeptNo);
            Console.WriteLine(g.EmpName);
            Console.WriteLine(g.Basic);
            Console.WriteLine(g.EmpNo);
            Console.WriteLine(g.Perks);
            // Console.WriteLine(g.netSal);
            g.create();

            System.Console.ReadLine();
        }
    }
}

public interface IDbFunctions
 {

   void create();  //public,virtual,abstract cant write on this method
}


public abstract class  Employee:IDbFunctions
{
    private int empNo;
    private string empName;
    private short deptNo;
    public decimal basic;
    public int ta; //travel allowance
    public int ra; //reduction
    public static int count = 0;



  public Employee(string name="abc",short dno=1,decimal basic=5000)
    
  {      
        
        empNo = ++count;
        EmpName = name;
        DeptNo = dno;
       Basic = basic;

    }
 public abstract decimal netSal(int ta = 1000, int ra = 2000);

    public  void create()
    {
        Console.WriteLine("created idbfunction");

    }

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

    public abstract decimal Basic  //as it is abstract propert so in body add at least one accessor
    {
        set;get;
    }



}
public class Manager : Employee,IDbFunctions
{

    private int projectId;


    public Manager(string name="abc", short dno=4, decimal basic=4050,int projid=1):base(name,dno,basic)
    {
        ProjectId = projid;
    }

    public int ProjectId
        {
        set
        {
            if (value > 0)
                value = projectId;
            else
                Console.WriteLine("invalid projectid");
        }
        get
        {
            return projectId;
        }

        }

    public override decimal Basic
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

    public new void create()
    {
        Console.WriteLine("created idbfunction");

    }

    public override decimal netSal(int ta = 1000, int ra = 2000)
    {
        Console.WriteLine("net salary: ");
        return Basic + ta - ra;
    }
}

public class Clerk : Employee,IDbFunctions
{
    private int overTimeHrs;

    public Clerk(string name="shubham", short dno=3, decimal basic=7000, int overtime=5) : base(name, dno, basic)
    {
        overTimeHrs = overtime;
    }
    public new void create()
    {
        Console.WriteLine("created idbfunction");
    }
    public int OverTimeHrs
    {
        set
        {
            if (value > 0)
                value = overTimeHrs;
            else
                Console.WriteLine("no amy overtime work done");
        }
        get
        {
            return overTimeHrs;
        }
    }
    public override decimal Basic
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

    

    public override decimal netSal(int ta = 1000, int ra = 2000)
    {
        Console.WriteLine("net salary: ");
        return Basic + ta - ra;
    }
}

public class GeneralManager:Manager,IDbFunctions
{
   private string perks;
    public GeneralManager(string name="shubham", short dno=1, decimal basic=4500, int projid=1,string perks1="freetrip"):base(name,dno,basic,projid)
    {
        Perks = perks1;
    }
    public string Perks
    {
        set;get;
    }
    public new void create()
    {
        Console.WriteLine("created manager idbfunction");
    }
}


