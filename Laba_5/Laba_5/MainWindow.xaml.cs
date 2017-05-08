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

namespace Laba_5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ControllClass controllClass;

        public MainWindow()
        {
            InitializeComponent();
            textBox_A.Text = "0.63 1.00 0.71 0.34\r\n1.17 0.18 -0.65 0.71\r\n2.71 -0.75 1.17 -2.35\r\n3.58 0.21 -3.45 -1.18";
            textBox_b.Text = "2.08\r\n0.17\r\n1.28\r\n0.05";
            controllClass = new ControllClass(); 
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string res = controllClass.CountRes(textBox_A.Text, textBox_b.Text,textBox_count.Text);

            if (res != null)
                textBox_x.Text = res;
            else
                MessageBox.Show("Некоректні вхідні дані!", "Помилка");
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

        private void textBox_count_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Char.IsDigit(e.Text, 0))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }
    }
}
