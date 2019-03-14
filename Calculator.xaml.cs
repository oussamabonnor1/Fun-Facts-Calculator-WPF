using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace DesktopApp
{
    /// <summary>
    /// Logique d'interaction pour Calculator.xaml
    /// </summary>
    public partial class Calculator : Window
    {
        
        public Calculator()
        {
            InitializeComponent();
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            if (this.textBoxOperation.Text.Equals("Operations will appear here..."))
            {
                this.textBoxOperation.Text = "";
            }
            this.textBoxOperation.Text += ((Button)sender).Content;   
        }

        private void ButtonOp(object sender, RoutedEventArgs e)
        {

        }
    }
}
