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

                SqlDataAdapter da = new SqlDataAdapter();  //provides the communication between the Dataset and the SQL database
                ds = new DataSet();

                da.SelectCommand = cmdEmps;
                da.Fill(ds,"Emps");

                cmdEmps.CommandText = "select * from Departments";
                da.Fill(ds, "Deps");

                //primary key constraint
                DataColumn[] arrCols = new DataColumn[1];
                arrCols[0] = ds.Tables["Emps"].Columns["EmpNo"];
                ds.Tables["Emps"].PrimaryKey = arrCols;

                //foreign key constraint
                ds.Relations.Add(ds.Tables["Deps"].Columns["DeptNo"], ds.Tables["Emps"].Columns["DeptNo"]);

                //column level constraints
                ds.Tables["Deps"].Columns["DeptName"].AllowDBNull = false;

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
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=shubhamm;Integrated Security=true";
            try
            {
                cn.Open();

                SqlCommand cmdUpdate = new SqlCommand();
                cmdUpdate.Connection = cn;
                cmdUpdate.CommandType = CommandType.Text;
                cmdUpdate.CommandText = "update Employees set DeptNo=@DeptNo,Basic=@Basic,Name=@Name where EmpNo=@EmpNo";
               
                cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Original });
                cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@DeptNo", SourceColumn = "DeptNo", SourceVersion = DataRowVersion.Current });
                cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@Basic", SourceColumn = "Basic", SourceVersion = DataRowVersion.Current });
                cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@Name", SourceColumn = "Name", SourceVersion = DataRowVersion.Current });



                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.CommandText = "insert into Employees values(@EmpNo, @DeptNo, @Basic, @Name)";

                cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Current });
                cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@DeptNo", SourceColumn = "DeptNo", SourceVersion = DataRowVersion.Current });
                cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@Basic", SourceColumn = "Basic", SourceVersion = DataRowVersion.Current });
                cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@Name", SourceColumn = "Name", SourceVersion = DataRowVersion.Original });



                SqlCommand cmdDelete = new SqlCommand();
                cmdDelete.Connection = cn;
                cmdDelete.CommandType = CommandType.Text;
                cmdDelete.CommandText = "delete from Employees where EmpNo=@EmpNo";  //use original whenever there is a where clause


                cmdDelete.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Current});
                //above will be used for the adding multiple rows


              // ds.Tables["Emps"].DefaultView.RowFilter = "EmpNO=" + txtEmpNo.Text;

                SqlDataAdapter da = new SqlDataAdapter();
                da.UpdateCommand = cmdUpdate;
                da.InsertCommand = cmdInsert;
                da.DeleteCommand = cmdDelete;

                da.Update(ds, "Emps");
               



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            cn.Close();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //DataView dv = new DataView(ds.Tables["Emps"]);
            //dv.RowFilter = "DeptNo=" + txtDeptNo.Text;
            //dgEmps.ItemsSource = dv;

            ds.Tables["Emps"].DefaultView.RowFilter = "DeptNo=" + txtDeptNo.Text;
            //ds.Tables["Emps"].DefaultView.Sort = "DeptNo";

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ds.Tables["Emps"].DefaultView.RowFilter = "";

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            ds.WriteXmlSchema("a.xsd");
            ds.WriteXml("a.xml", XmlWriteMode.DiffGram);

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            ds = new DataSet();
            ds.ReadXmlSchema("a.xsd");
            ds.ReadXml("a.xml", XmlReadMode.DiffGram);
            dgEmps.ItemsSource = ds.Tables["Emps"].DefaultView;
        }

        private void TxtDeptNo_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
