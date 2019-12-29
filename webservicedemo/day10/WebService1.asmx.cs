using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace day10
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]  //imp added info to the xml
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        private DataSet ds;

        [WebMethod]
        public string HelloWorld1()
        {
            return "Hello World";
        }

        [WebMethod]
        public string HelloWorld()
        {
            System.Threading.Thread.Sleep(20000);
            return "Hello World async";
        }

        [WebMethod]
        public int add(int a,int b)
        {
            return a + b;
        }

        [WebMethod]
        public DataSet GetDataSet()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=shubhamm;Integrated Security=true";
            try
            {
                cn.Open();

                SqlCommand cmdEmps = new SqlCommand();
                cmdEmps.Connection = cn;
                cmdEmps.CommandType = CommandType.Text;
                cmdEmps.CommandText = "select * from Employees";

                SqlDataAdapter da = new SqlDataAdapter();
                ds = new DataSet();

                da.SelectCommand = cmdEmps;
                da.Fill(ds, "Emps");

                cmdEmps.CommandText = "select * from Departments";
                da.Fill(ds, "Deps");

        
                //dgEmps.ItemsSource = ds.Tables["Deps"].DefaultView;

            }
            catch
            {
               // MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return ds;
        }
        //[WebMethod]
        //public DataSet GetUpdate()
        //{

        //}
    }
}
