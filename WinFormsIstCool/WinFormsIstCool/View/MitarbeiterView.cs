using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsIstCool.View
{
    public partial class MitarbeiterView : UserControl
    {
        public MitarbeiterView()
        {
            InitializeComponent();

            button4.MouseMove += Button4_MouseMove;
        }

        private void Button4_MouseMove(object? sender, MouseEventArgs e)
        {
            MessageBox.Show("Test");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
