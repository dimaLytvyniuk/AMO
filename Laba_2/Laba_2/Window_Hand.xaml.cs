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
    /// Логика взаимодействия для Window_Hand.xaml
    /// </summary>
    public partial class Window_Hand : Window
    {
        HandControll handControll;

        public Window_Hand()
        {
            InitializeComponent();
            handControll = new HandControll(listbox_after,listbox_sorted);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void button_Text_Click(object sender, RoutedEventArgs e)
        {
            if (!handControll.AddElement(textBox_in.Text))
                MessageBox.Show("Некоректні вхідні дані", "Complete");
        }

        private void button_File_Click(object sender, RoutedEventArgs e)
        {
            handControll.ReadFromFile();
        }

        private void button__Click(object sender, RoutedEventArgs e)
        {
            handControll.Sort();
        }

        private void textBox_in_PreviewTextInput(object sender, TextCompositionEventArgs e)
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
