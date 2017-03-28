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

namespace Laba_2
{
    /// <summary>
    /// Логика взаимодействия для Window_Gen.xaml
    /// </summary>
    public partial class Window_Gen : Window
    {
        GenControll genControll;

        public Window_Gen()
        {
            InitializeComponent();
            genControll = new GenControll();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void button_sort_Click(object sender, RoutedEventArgs e)
        {
            List<string> n = new List<string>();
            List<string> max = new List<string>();
            n.Add(textBox_сount_1.Text);
            n.Add(textBox_сount_2.Text);
            n.Add(textBox_сount_3.Text);
            n.Add(textBox_сount_4.Text);
            n.Add(textBox_сount_5.Text);
            n.Add(textBox_сount_6.Text);
            n.Add(textBox_сount_7.Text);
            n.Add(textBox_сount_8.Text);
            n.Add(textBox_сount_9.Text);
            n.Add(textBox_сount_10.Text);

            max.Add(textBox_max_1.Text);
            max.Add(textBox_max_2.Text);
            max.Add(textBox_max_3.Text);
            max.Add(textBox_max_4.Text);
            max.Add(textBox_max_5.Text);
            max.Add(textBox_max_6.Text);
            max.Add(textBox_max_7.Text);
            max.Add(textBox_max_8.Text);
            max.Add(textBox_max_9.Text);
            max.Add(textBox_max_10.Text);

            if (genControll.InputValues(n, max))
            {
                listbox_after.Items.Clear();
                listbox_before.Items.Clear();
                genControll.Sort(listbox_before,listbox_after);
            }
            else
                MessageBox.Show("Некоректні вхідні дані", "Помилка");
        }

        private void textBox_сount_1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (Char.IsDigit(e.Text, 0) || (e.Text == ".") || (e.Text == "-"))
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }
    }
}
