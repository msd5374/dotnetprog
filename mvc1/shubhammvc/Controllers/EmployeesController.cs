using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using shubhammvc.Models;

namespace shubhammvc.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {
            return View();
        }

        // GET: Employees/Details/5
        public ActionResult Details(int id=0)
        {

            //Employee e = new Employee();
            // e.EmpNo = 1;
            // e.Name = "shubham";
            // e.Basic = 12021;
            // e.DeptNo = 10;
            //return View(e);
            return View();
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
        
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        public ActionResult Create(Employee e)
        {
            try
            {
                // TODO: Add insert logic here

                 SqlConnection cn = new SqlConnection();
           cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=shubhamm;Integrated Security=true";
           
           cn.Open();

           SqlCommand cmdInsert = new SqlCommand();
           cmdInsert.Connection = cn;
           cmdInsert.CommandType = CommandType.Text;
           cmdInsert.CommandText = "insert into Employees values(@EmpNo,@DeptNo, @Basic, @Name)";  //uses prepare statement


                cmdInsert.Parameters.AddWithValue("@EmpNO", e.EmpNo);
                cmdInsert.Parameters.AddWithValue("@DeptNo", e.DeptNo);
                cmdInsert.Parameters.AddWithValue("@Basic", e.Basic);
                cmdInsert.Parameters.AddWithValue("@Name", e.Name);


                cmdInsert.ExecuteNonQuery();

                cn.Close();

                 return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
          
            }
            

        // GET: Employees/Edit/5
        public ActionResult Edit(int id=0)
        {
            return View();
        }

        // POST: Employees/Edit/5
        [HttpPost]
        public ActionResult Edit(Employee e)
        {
            try
            {
                // TODO: Add update logic here
                SqlConnection cn2 = new SqlConnection();
                cn2.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=shubhamm;Integrated Security=true";

                cn2.Open();
                SqlCommand cmdUpdate = new SqlCommand();
                cmdUpdate.Connection = cn2;
                cmdUpdate.CommandType = CommandType.Text;
                cmdUpdate.CommandText = "update Employees set DeptNo=@DeptNo,Basic=@Basic,Name=@Name where EmpNo=@EmpNo";

                cmdUpdate.Parameters.AddWithValue("@DeptNo", e.DeptNo );
                cmdUpdate.Parameters.AddWithValue("@Basic", e.Basic );
                cmdUpdate.Parameters.AddWithValue("@Name", e.Name );
                cmdUpdate.Parameters.AddWithValue("@EmpNo", e.EmpNo);

                cmdUpdate.ExecuteNonQuery();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int id=0)
        {
            return View();
        }

        // POST: Employees/Delete/5
        [HttpPost]
        public ActionResult Delete(int Id,Employee e)
        {
            try
            {
                SqlConnection cn3 = new SqlConnection();
                cn3.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=shubhamm;Integrated Security=true";


                cn3.Open();
                SqlCommand cmdDelete = new SqlCommand();
                cmdDelete.Connection = cn3;
                cmdDelete.CommandType = CommandType.Text;  //three types:store procedure,preapare statment and tabledirect
                cmdDelete.CommandText = "delete from Employees where empNo=@EmpNo";
                cmdDelete.Parameters.AddWithValue("@EmpNo",Id);

                cmdDelete.ExecuteNonQuery();



                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
