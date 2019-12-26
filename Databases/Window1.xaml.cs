using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Databases
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=shubhamm;Integrated Security=true";
            //cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=Vikram;User Id=sa;Password=sa";
            try
            {
                cn.Open();

                SqlCommand cmdEmps = new SqlCommand();
                cmdEmps.Connection = cn;
                cmdEmps.CommandType = CommandType.Text;
                cmdEmps.CommandText = "select * from Employees";

                SqlDataReader drEmps = cmdEmps.ExecuteReader();
                while(drEmps.Read())
                {
                    lstNames.Items.Add(drEmps["Name"]);
                    //lstNames.Items.Add(drEmps.GetString(1));
                }
                drEmps.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=shubhamm;Integrated Security=true";
            try
            {
                cn.Open();

                SqlCommand cmdEmps = new SqlCommand();
                cmdEmps.Connection = cn;
                cmdEmps.CommandType = CommandType.Text;
                cmdEmps.CommandText = "select * from Employees;select * from Departments";

                SqlDataReader drEmps = cmdEmps.ExecuteReader();
                while (drEmps.Read())
                {
                    lstNames.Items.Add(drEmps["Name"]);
                }

                lstNames.Items.Add("-----");

                drEmps.NextResult();
                while (drEmps.Read())
                {
                    lstNames.Items.Add(drEmps["DeptName"]);
                }


                drEmps.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
            }


        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=shubhamm;Integrated Security=true;MultipleActiveResultSets=true";
            try
            {
                cn.Open();

                SqlCommand cmdEmps = new SqlCommand();
                cmdEmps.Connection = cn;
                cmdEmps.CommandType = CommandType.Text;

                SqlCommand cmdDeps = new SqlCommand();
                cmdDeps.Connection = cn;
                cmdDeps.CommandType = CommandType.Text;
                cmdDeps.CommandText = "select * from Departments";
                SqlDataReader drDeps = cmdDeps.ExecuteReader();
                
                while (drDeps.Read())
                {
                    lstNames.Items.Add(drDeps["DeptName"]);
                    cmdEmps.CommandText = "select * from Employees where DeptNo=" + drDeps["DeptNo"];

                    SqlDataReader drEmps = cmdEmps.ExecuteReader();  
                    while (drEmps.Read())
                    {
                        lstNames.Items.Add("   "+ drEmps["Name"]);
                    }
                    drEmps.Close();
                }
                drDeps.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
            }


        }
    }
}
