using System;
using System.Collections.Generic;
using System.Data;
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

namespace WpfApp2
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
       

        private void Btnfill_Click(object sender, RoutedEventArgs e)
        {

            localhost.WebService1 ob = new localhost.WebService1();
            DataSet ds1 = ob.GetDataSet();
            dgrid.ItemsSource = ds1.Tables["Emps"].DefaultView;
        }
    }
}
