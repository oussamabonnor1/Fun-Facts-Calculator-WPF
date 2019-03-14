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
        double firstNum = 0f;
        double secondNum = 0f;
        int operation = -1;
        string operationString;
        bool used;

        public Calculator()
        {
            InitializeComponent();
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            if (used)
            {
                used = false;
                firstNum = secondNum = 0;
                operation = -1;
                operationString = "";
                textBoxOperation.Text = "Operations will appear here...";
                textBoxSolution.Content = "Solution";
            }

            if (this.textBoxOperation.Text.Equals("Operations will appear here..."))
            {
                this.textBoxOperation.Text = "";
            }
            if (((Button)sender).Content.ToString() == "Del")
            {
                if(this.textBoxOperation.Text.Length > 0)
                this.textBoxOperation.Text = this.textBoxOperation.Text.Remove(this.textBoxOperation.Text.Length - 1);
            }
            else
            {
                this.textBoxOperation.Text += ((Button)sender).Content;
            }
        }

        private void ButtonOp(object sender, RoutedEventArgs e)
        {
            if (this.textBoxOperation.Text.Equals("Operations will appear here..."))
            {
                MessageBox.Show("You can't start with an operation!");
            }
            else
            {
                String tempOp = ((Button) sender).Content.ToString();
                if (tempOp == "=")
                {
                    CalculateSolution();
                }
                else if (tempOp == "C"){
                    used = false;
                    firstNum = secondNum = 0;
                    operation = -1;
                    operationString = "";
                    textBoxOperation.Text = "Operations will appear here...";
                    textBoxSolution.Content = "Solution";
                }
                else
                {
                    operationString = tempOp;

                    if (operationString == "+")
                    {
                        operation = 0;
                    }
                    else if (operationString == "-")
                    {
                        operation = 1;
                    }
                    else if (operationString == "x")
                    {
                        operation = 2;
                    }
                    else if (operationString == "/")
                    {
                        operation = 3;
                    }
                    else if (operationString == "%")
                    {
                        operation = 4;
                    }
                    else
                    {
                        MessageBox.Show("Coming soon...");
                    }
                    firstNum = double.Parse(this.textBoxOperation.Text);
                    this.textBoxOperation.Text += ((Button)sender).Content;
                }
            }
        }

        void CalculateSolution()
        {
            secondNum = double.Parse(this.textBoxOperation.Text.Split(operationString[0])[1]);
            if (secondNum == 0 && operation == 3)
            {
                MessageBox.Show("Error, devision by zero is not tolerated");
            }
            else
            {
                double result;
                switch (operation)
                {
                    case 0:
                        result = firstNum + secondNum;
                        break;
                    case 1:
                        result = firstNum - secondNum;
                        break;
                    case 2:
                        result = firstNum * secondNum;
                        break;
                    case 3:
                        result = firstNum / secondNum;
                        break;
                    case 4:
                        result = firstNum % secondNum;
                        break;
                    default: result = 0;
                        break;
                }
                string[] preAnswers =
                {
                    "I think it's ",
                    "You ll get ",
                    "Ehhh...",
                    "Well, it's ",
                    "Pfff, it's "
                };
                string[] postAnswers =
                {
                    " Right?",
                    " I'm sure",
                    " I think..",
                    " Or is it?",
                    ""
                };
                int randomIndex = new Random().Next(5);
                this.textBoxSolution.Content =  preAnswers[randomIndex]+ result+ postAnswers[randomIndex];
                used = true;
            }
        }
    }
}
