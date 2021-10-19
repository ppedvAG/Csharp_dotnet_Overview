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

namespace HalloWPF.Views
{
    /// <summary>
    /// Interaction logic for MitarbeiterView.xaml
    /// </summary>
    public partial class MitarbeiterView : UserControl
    {
        public MitarbeiterView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lbl1.Background = new SolidColorBrush(Colors.Chocolate);
        }
    }
}
