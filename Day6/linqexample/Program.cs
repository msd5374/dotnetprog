using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linqexample
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
            return EmpNo + " " + Name + " " + Basic + " " + DeptNo + " " + Gender;
        }

    }

    public class Department
    {
        public int DeptNo { get; set; }
        public string DeptName { get; set; }
        public override string ToString()
        {
            return DeptNo + " " + DeptName;
        }
    }
    class Program
    {

        static Employee GetEmployee1(Employee e3)
        {
            return e3;
        }
        static void Main1()
        {

            AddRec();


            //1.var emps = from single_object in collection select something
            //var emp = from emp1 in lstEmp select emp1; ------
            //**defered execution** it will not execute query it can be called in foreach only
            // particular col ----  //var emps = from emp in lstEmp select emp.Name;


            //2.using lambda expression
            var emp = lstEmp.Select(e1 => e1);

            //3.static method
            //var emp = lstEmp.Select(GetEmployee1);

            //4.anonomynous method
            //var emp = lstEmp.Select(delegate (Employee e) { return e; });


            //4.using anonymous type(class havent name) uses for more than one data type name,basic
            //var emp = lstEmp.Select(e => new { e.Name, e.Basic });
            //  var emp = from emp2 in lstEmp select new { emp2.Name, emp2.Basic };
            foreach (var item in emp)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            lstEmp.RemoveAt(2);



            foreach (var item in emp)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
        static void Main2()
        {
            AddRec();
            var emp = from emp1 in lstEmp where emp1.Name.StartsWith("b") select emp1;
            
            foreach(var item in emp)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadLine();
        }

        static void Main()
        {
            AddRec();
            //var emp3 = from emp in lstEmp
            //           where (emp.EmpNo < 5 || emp.Basic == 10000)
            //           orderby emp.Name
            //           select emp;

            //var emp3 = from emp in lstEmp
            //           orderby emp.Name ascending
            //           select emp;

            var em = lstEmp.OrderBy(e => e.Name);
            foreach (var item in em)
            {
                Console.WriteLine(item.Name);
            }

            //            var em =from em1 in lstEmp orderby  

            //foreach (var item in emp3)
            //    Console.WriteLine(item.Name + " : " + item.Basic + ":" + item.DeptNo);
            Console.ReadLine();
        }
        static List<Employee> lstEmp = new List<Employee>();
        static List<Department> lstDept = new List<Department>();
        public static void AddRec()
        {
            lstEmp.Add(new Employee { EmpNo = 1, Name = "a", DeptNo = 10, Gender = "Male", Basic = 42000 }); //object initializer
            lstEmp.Add(new Employee { EmpNo = 2, Name = "b", DeptNo = 20, Gender = "Female", Basic = 22000 }); //object initializer
            lstEmp.Add(new Employee { EmpNo = 3, Name = "c", DeptNo = 30, Gender = "Male", Basic = 52000 }); //object initializer

            lstDept.Add(new Department { DeptNo = 10, DeptName = "it" });
            lstDept.Add(new Department { DeptNo = 20, DeptName = "hr" });
            lstDept.Add(new Department { DeptNo = 30, DeptName = "mktg" });

        }
    }


}
