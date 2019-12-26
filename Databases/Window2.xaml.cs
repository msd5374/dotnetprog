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
    }
}
