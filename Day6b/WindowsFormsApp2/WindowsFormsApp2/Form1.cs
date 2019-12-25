using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = DoSomething();
            label1.Text = s;
        }
        private async void button2_Click(object sender, EventArgs e)
        {
            Task<string> t = DoSomething2();
            await t;
            label1.Text = t.Result;
        }
        private string DoSomething()
        {
            Thread.Sleep(10000);
            return "Done";
        }


        private async Task<string> DoSomething2()
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(10000);
                return "Done";
            });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Func<string> o = DoSomething;
            o.BeginInvoke(delegate (IAsyncResult ar)
            {
                string s = o.EndInvoke(ar);

                //label1.Text = s;
                label1.Invoke(new MyDel(delegate () { label1.Text = s; }));
            }, null);
        }
    }
    delegate void MyDel();

}
