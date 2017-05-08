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

namespace Laba_4
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
            controllClass = new ControllClass();
        }

        private void textBox_A_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Char.IsDigit(e.Text, 0) || (e.Text == ",") || (e.Text == "-"))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void textBox_E_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Char.IsDigit(e.Text, 0) || (e.Text == ","))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void button_result_Click(object sender, RoutedEventArgs e)
        {
            double result = controllClass.SerchRes(chartG, textBox_A.Text, textBox_B.Text, textBox_E.Text);

            if (!Double.IsNaN(result))
                textBox_X.Text = result.ToString();
            else
                MessageBox.Show("Некоректні вхідні дані", "Помилка");
        }
    }
}
