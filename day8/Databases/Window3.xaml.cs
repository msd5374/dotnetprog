using Databases.DataSet1TableAdapters;
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
using System.Windows.Shapes;

namespace Databases
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }  
        DataSet1 ds = new DataSet1();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ds = new DataSet1();
                DepartmentsTableAdapter dept = new DepartmentsTableAdapter();
                dept.Fill(ds.Departments);

                EmployeesTableAdapter emp = new EmployeesTableAdapter();
                emp.Fill(ds.Employees);

                dgEmp.ItemsSource = ds.Employees.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            EmployeesTableAdapter empad = new EmployeesTableAdapter();
            empad.Update(ds.Employees);
        }
    }
}
