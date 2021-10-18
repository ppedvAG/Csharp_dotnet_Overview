using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WCF__Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "78050000";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ServiceReference1.BLZServicePortTypeClient client = new ServiceReference1.BLZServicePortTypeClient("BLZServiceSOAP12port_http");
            ServiceReference1.detailsType bank =  client.getBank(textBox1.Text);

            label1.Text = $"{bank.bezeichnung} {bank.bic}";

        }
    }
}
