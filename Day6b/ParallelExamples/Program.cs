using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelExamples1
{
    class Program
    {
        static void Main1()
        {
            //Task t1 = new Task(Display);
            //Task t2 = new Task(Show);
            //t1.Start();
            //t2.Start();

            //Parallel.Invoke(Display, Show, Print);


            Parallel.Invoke(
                () => Console.WriteLine("1"),
                () => Console.WriteLine("2"),
                () => Console.WriteLine("3"),
                () => Console.WriteLine("4"),
                () => Console.WriteLine("5"),
                () => Console.WriteLine("6"),
                () => Console.WriteLine("7"),
                () => Console.WriteLine("8"),
                () => Console.WriteLine("9"),
                () => Console.WriteLine("10"),
                () => Console.WriteLine("11"),
                () => Console.WriteLine("12")

                );
            Console.ReadLine();
        }

        static void Display()
        {
            Console.WriteLine("display");
        }
        static void Show()
        {
            Console.WriteLine("show");
        }
        static void Print()
        {
            Console.WriteLine("Print");
        }

    }
}

namespace ParallelExamples2
{
    class Program
    {
        static void Main1()
        {
            Parallel.For(1, 50, Display);
            Console.ReadLine();
        }

        static void Display(int subscript)
        {
            Console.WriteLine("display " + subscript);
        }

    }
}
namespace ParallelExamples3
{
    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }
        public string Gender { get; set; }
        public override string ToString()
        {
            string str = "";
            str += "EmpNo : " + EmpNo + "\n";
            str += "Name : " + Name + "\n";

            return str;
        }
    }
    class Program
    {
        static List<Employee> lstEmp = new List<Employee>();

        static void Main3()
        {
            AddRecs();
            Parallel.ForEach(lstEmp, Display);
            Console.ReadLine();
        }

        static void Display(Employee o)
        {
            Console.WriteLine(o.ToString());
        }
        public static void AddRecs()
        {
            lstEmp.Add(new Employee { EmpNo = 1, Name = "Vikram", Basic = 10000, DeptNo = 10, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 2, Name = "Vikas", Basic = 11000, DeptNo = 10, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 3, Name = "Abhijit", Basic = 12000, DeptNo = 20, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 4, Name = "Mona", Basic = 11000, DeptNo = 20, Gender = "F" });
            lstEmp.Add(new Employee { EmpNo = 5, Name = "Shweta", Basic = 12000, DeptNo = 20, Gender = "F" });
            lstEmp.Add(new Employee { EmpNo = 6, Name = "Sanjay", Basic = 11000, DeptNo = 30, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 7, Name = "Arpan", Basic = 10000, DeptNo = 30, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 8, Name = "Shraddha", Basic = 11000, DeptNo = 40, Gender = "F" });
            lstEmp.Add(new Employee { EmpNo = 9, Name = "Arpan", Basic = 10000, DeptNo = 30, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 10, Name = "Shraddha", Basic = 11000, DeptNo = 40, Gender = "F" });
            lstEmp.Add(new Employee { EmpNo = 11, Name = "Vikram", Basic = 10000, DeptNo = 10, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 12, Name = "Vikas", Basic = 11000, DeptNo = 10, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 13, Name = "Abhijit", Basic = 12000, DeptNo = 20, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 14, Name = "Mona", Basic = 11000, DeptNo = 20, Gender = "F" });
            lstEmp.Add(new Employee { EmpNo = 15, Name = "Shweta", Basic = 12000, DeptNo = 20, Gender = "F" });
            lstEmp.Add(new Employee { EmpNo = 16, Name = "Sanjay", Basic = 11000, DeptNo = 30, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 17, Name = "Arpan", Basic = 10000, DeptNo = 30, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 18, Name = "Shraddha", Basic = 11000, DeptNo = 40, Gender = "F" });
            lstEmp.Add(new Employee { EmpNo = 19, Name = "Arpan", Basic = 10000, DeptNo = 30, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 20, Name = "Shraddha", Basic = 11000, DeptNo = 40, Gender = "F" });
        }
    }
}
namespace ParallelExamples4
{
    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }
        public string Gender { get; set; }
        public override string ToString()
        {
            string str = "";
            str += "EmpNo : " + EmpNo + "\n";
            str += "Name : " + Name + "\n";

            return str;
        }
    }
    class Program
    {
        static List<Employee> lstEmp = new List<Employee>();

        static void Main()
        {
            AddRecs();

            //var emps = from emp in lstEmp.AsParallel() select emp;
            var emps = from emp in lstEmp.AsParallel().WithDegreeOfParallelism(4) select emp;

            foreach (var item in emps)
            {
                Console.WriteLine(item.EmpNo);
            }
            Console.ReadLine();
        }

        static void Display(Employee o)
        {
            Console.WriteLine(o.ToString());
        }
        public static void AddRecs()
        {
            lstEmp.Add(new Employee { EmpNo = 1, Name = "Vikram", Basic = 10000, DeptNo = 10, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 2, Name = "Vikas", Basic = 11000, DeptNo = 10, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 3, Name = "Abhijit", Basic = 12000, DeptNo = 20, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 4, Name = "Mona", Basic = 11000, DeptNo = 20, Gender = "F" });
            lstEmp.Add(new Employee { EmpNo = 5, Name = "Shweta", Basic = 12000, DeptNo = 20, Gender = "F" });
            lstEmp.Add(new Employee { EmpNo = 6, Name = "Sanjay", Basic = 11000, DeptNo = 30, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 7, Name = "Arpan", Basic = 10000, DeptNo = 30, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 8, Name = "Shraddha", Basic = 11000, DeptNo = 40, Gender = "F" });
        }
    }
}
