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
            List<Employee> emps = new List<Employee>();

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=shubhamm;Integrated Security=true";
            try
            {


                cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Employees";  //uses prepare statement


                SqlDataReader dr = cmd.ExecuteReader();


                while (dr.Read())
                {
                    Employee ep = new Employee();

                    ep.EmpNo = (int)dr["EmpNo"];
                    ep.Name = dr["Name"].ToString();
                    ep.Basic = (decimal)dr["Basic"];
                    ep.DeptNo = (int)dr["DeptNo"];

                    emps.Add(ep);
                }
            }
           catch(Exception ex)
            {

            }
            return View(emps);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int id=0)
        {
           
                // TODO: Add insert logic here

                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=shubhamm;Integrated Security=true";
            Employee ep = new Employee();

            cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Employees where EmpNo=@EmpNo";  //uses prepare statement


                cmd.Parameters.AddWithValue("@EmpNO",id);
                SqlDataReader dr =cmd.ExecuteReader();


                if(dr.Read())
                {
                    ep.EmpNo = id;
                    ep.Name = dr["Name"].ToString();
                    ep.Basic = (decimal)dr["Basic"];
                    ep.DeptNo = (int)dr["DeptNo"];
                return View(ep);
                }
                else
            {
                return View();
            }
              
          


            
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
        [HttpGet]
        public ActionResult Delete(int ID=0)
        {

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=shubhamm;Integrated Security=true";
           Employee ep = new Employee();

            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Employees where EmpNo=@EmpNo";  //uses prepare statement


            cmd.Parameters.AddWithValue("@EmpNo", ID);
            SqlDataReader dr = cmd.ExecuteReader();


            if (dr.Read())
            {
                ep.EmpNo = ID;
                ep.Name = dr["Name"].ToString();
                ep.Basic = (decimal)dr["Basic"];
                ep.DeptNo = (int)dr["DeptNo"];

            }

            cn.Close();
            return View(ep);

        }

        // POST: Employees/Delete/5
        [HttpPost]
        public ActionResult Delete(Employee ep1, int Id)
        {
            // TODO: Add delete logic here
            SqlConnection cn3 = new SqlConnection();
            cn3.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=shubhamm;Integrated Security=true";
            try
            {
              
                cn3.Open();
                SqlCommand cmdDelete = new SqlCommand();
                cmdDelete.Connection = cn3;
                cmdDelete.CommandType = CommandType.Text;  //three types:store procedure,preapare statment and tabledirect
                cmdDelete.CommandText = "delete from Employees where EmpNo=@EmpNo";
                cmdDelete.Parameters.AddWithValue("@EmpNo",Id);

                cmdDelete.ExecuteNonQuery();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            finally
            {
                cn3.Close();
            }

        }
    }
}
