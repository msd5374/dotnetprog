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
                //add the parameters
                //SqlParameter p = new SqlParameter();
                //p.ParameterName = "@Name";
                ////p.Value = txtName.Text
                //p.SourceColumn = "Name";
                //p.SourceVersion = DataRowVersion.Current;
                //cmdUpdate.Parameters.Add(p);

                cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Original });
                cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@DeptNo", SourceColumn = "DeptNo", SourceVersion = DataRowVersion.Current });
                cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@Basic", SourceColumn = "Basic", SourceVersion = DataRowVersion.Current });

                cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@Name", SourceColumn = "Name", SourceVersion = DataRowVersion.Current });

                SqlDataAdapter da = new SqlDataAdapter();
                da.UpdateCommand = cmdUpdate;
                //da.InsertCommand = cmdInsert
                //da.DeleteCommand = cmdDelete

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
    }
}
