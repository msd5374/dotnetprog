using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace Databases
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=Vikram;Integrated Security=true";
            //cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=Vikram;User Id=sa;Password=sa";
            try
            {
                cn.Open();

                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = CommandType.Text;
                //cmdInsert.CommandText = "insert into Employees values(5, 'Pooja', 12345, 30)";
                cmdInsert.CommandText = "insert into Employees values(" + txtEmpNo.Text + ",'" + txtName.Text + "'," + txtBasic.Text + "," + txtDeptNo.Text + ")";
                MessageBox.Show(cmdInsert.CommandText);

                cmdInsert.ExecuteNonQuery();
                MessageBox.Show("ok");
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
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=Vikram;Integrated Security=true";
            //cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=Vikram;User Id=sa;Password=sa";
            try
            {
                cn.Open();

                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.CommandText = "insert into Employees values(@EmpNo, @Name, @Basic, @DeptNo)";

                cmdInsert.Parameters.AddWithValue("@EmpNo", txtEmpNo.Text);
                cmdInsert.Parameters.AddWithValue("@Name", txtName.Text);
                cmdInsert.Parameters.AddWithValue("@Basic", txtBasic.Text);
                cmdInsert.Parameters.AddWithValue("@DeptNo", txtDeptNo.Text);

                cmdInsert.ExecuteNonQuery();
                MessageBox.Show("ok");
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
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=Vikram;Integrated Security=true";
            try
            {
                cn.Open();

                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = CommandType.StoredProcedure;
                cmdInsert.CommandText = "InsertEmployee";

                cmdInsert.Parameters.AddWithValue("@EmpNo", txtEmpNo.Text);
                cmdInsert.Parameters.AddWithValue("@Name", txtName.Text);
                cmdInsert.Parameters.AddWithValue("@Basic", txtBasic.Text);
                cmdInsert.Parameters.AddWithValue("@DeptNo", txtDeptNo.Text);

                cmdInsert.ExecuteNonQuery();
                MessageBox.Show("ok");
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

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=Vikram;Integrated Security=true";
            SqlTransaction t;
            cn.Open();
            t = cn.BeginTransaction();
            try
            {

                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.Transaction = t;
                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.CommandText = "insert into Employees values(50, 'Pooja', 12345, 30)";

                SqlCommand cmdInsert2 = new SqlCommand();
                cmdInsert2.Connection = cn;
                cmdInsert2.Transaction = t;
                cmdInsert2.CommandType = CommandType.Text;
                cmdInsert2.CommandText = "insert into Employees values(100, 'new', 12345, 30)";


                cmdInsert.ExecuteNonQuery();
                cmdInsert2.ExecuteNonQuery();

                t.Commit();
                MessageBox.Show("commit");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                t.Rollback();
                MessageBox.Show("rollback");
            }
            finally
            {
                cn.Close();
            }

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=Vikram;Integrated Security=true";
            //cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=Vikram;User Id=sa;Password=sa";
            try
            {
                cn.Open();

                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.CommandText = "select count(*) from Employees";

                lblCount.Content = cmdInsert.ExecuteScalar();
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
