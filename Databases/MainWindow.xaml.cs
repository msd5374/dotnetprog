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
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=shubhamm;Integrated Security=true";
            //cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=shubhamm;User Id=sa;Password=sa";
            try
            {
                cn.Open();

                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = CommandType.Text;
      // cmdInsert.CommandText = "insert into Employees values(5,10 , 12345, 'Pooja')";
          cmdInsert.CommandText = "insert into Employees values(" + txtEmpNo.Text + "," + txtDeptNo.Text + "," + txtBasic.Text + ",'" + txtName.Text + "')";
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
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=shubhamm;Integrated Security=true";
            //cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=Vikram;User Id=sa;Password=sa";
            try
            {
                cn.Open();

                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.CommandText = "insert into Employees values(@EmpNo, @DeptNo, @Basic, @Name)";  //uses prepare statement
                //avoids sql injection
                cmdInsert.Parameters.AddWithValue("@EmpNo", txtEmpNo.Text);
                cmdInsert.Parameters.AddWithValue("@DeptNo", txtDeptNo.Text);
                cmdInsert.Parameters.AddWithValue("@Name", txtName.Text);
                cmdInsert.Parameters.AddWithValue("@Basic", txtBasic.Text);
               

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

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            SqlConnection cn1 = new SqlConnection();
            cn1.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=shubhamm;Integrated Security=true";

            try
            {
                cn1.Open();
                SqlCommand cmdDelete = new SqlCommand();
                cmdDelete.Connection = cn1;
                cmdDelete.CommandType = CommandType.Text;  //three types:store procedure,preapare statment and tabledirect
                cmdDelete.CommandText = "delete from Employees where empNo=@EmpNo";
                cmdDelete.Parameters.AddWithValue("@EmpNo", txtEmpNo.Text);

                cmdDelete.ExecuteNonQuery();
                MessageBox.Show("deleted successfully");
            }
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            finally
            {
                cn1.Close();
            }
        }
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            SqlConnection cn2 = new SqlConnection();
            cn2.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=shubhamm;Integrated Security=True";

            try
            {
                cn2.Open();
                SqlCommand cmdUpdate = new SqlCommand();
                cmdUpdate.Connection = cn2;
                cmdUpdate.CommandType = CommandType.Text;
                cmdUpdate.CommandText = "update Employees set Name=@Name where EmpNo=@EmpNo";

                cmdUpdate.Parameters.AddWithValue("@Name",txtName.Text);
                cmdUpdate.Parameters.AddWithValue("@EmpNo", txtEmpNo.Text);

                cmdUpdate.ExecuteNonQuery();
                MessageBox.Show("record updated");
            }
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            finally
            {
                cn2.Close();
            }
        }

        private void showdata(object sender, RoutedEventArgs e)
        {
            //SqlConnection cn3 = new SqlConnection();
            //cn3.ConnectionString= @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=shubhamm;Integrated Security=True";

            //try

            //{
            //    cn3.Open();
            //    SqlCommand cmdShowData = new SqlCommand();
            //    cmdShowData.Connection = cn3;
            //    cmdShowData.CommandType = CommandType.Text;
            //    cmdShowData.CommandText = "select * from Employees";
            //}
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=shubhamm;Integrated Security=true";
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
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=shubhamm;Integrated Security=true";
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
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=shubhamm;Integrated Security=true";
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
       



        private void TxtEmpNo_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {

        }

      
    }
}
