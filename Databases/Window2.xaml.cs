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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }
        DataSet ds;
        private void Button_Click(object sender, RoutedEventArgs e)
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

                dgEmps.ItemsSource = ds.Tables["Emps"].DefaultView;
                //dgEmps.ItemsSource = ds.Tables["Deps"].DefaultView;

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
            SqlConnection cn1 = new SqlConnection();
            cn1.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=shubhamm;Integrated Security=true";
            try
            {
                cn1.Open();
                SqlCommand fill1 = new SqlCommand();
                fill1.Connection = cn1;
                fill1.CommandType = CommandType.Text;
                fill1.CommandText = "select * from Employees";

                SqlDataAdapter da = new SqlDataAdapter();
                ds = new DataSet();

                da.SelectCommand = fill1;
                da.Fill(ds, "Emps"); //dataset ,any tablename    //fill and remove op

                fill1.CommandText = "select * from Departments";
                da.Fill(ds, "Deps");

                dgEmps.ItemsSource = ds.Tables["Emps"].DefaultView;  //dgemps is gridname




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn1.Close();
            }

        }
    }
}
