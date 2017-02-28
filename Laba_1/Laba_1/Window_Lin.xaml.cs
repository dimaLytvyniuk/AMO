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

namespace Laba_1
{
    /// <summary>
    /// Логика взаимодействия для Window_Lin.xaml
    /// </summary>
    public partial class Window_Lin : Window
    {
        LinContoll linControll;

        public Window_Lin()
        {
            InitializeComponent();
            linControll = new LinContoll();
        }

        private void textBox_A_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Char.IsDigit(e.Text, 0) || (e.Text == ".") || (e.Text == "-"))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }



        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void button_CalcS_Click(object sender, RoutedEventArgs e)
        {
            bool res = linControll.CalcS(textBox_A.Text, textBox_B.Text, textBox_C.Text, textBox_D.Text);

            if (res)
                textBox_Y.Text = String.Format("{0,36:#0.00000000}", linControll.Y1);
        }

        private void button_CalcF_Click(object sender, RoutedEventArgs e)
        {
            linControll.CalcF();
        }
    }
}
