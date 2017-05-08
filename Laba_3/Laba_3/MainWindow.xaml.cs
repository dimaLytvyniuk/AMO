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
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Laba_3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ControlClass controlClass;

        public MainWindow()
        {
           InitializeComponent();
            controlClass = new ControlClass(dataGrid_node,dataGrid_values,dataGrid_Poh); 
        }

        private void button_sin_Click(object sender, RoutedEventArgs e)
        {
            textBox_out.Text = controlClass.CallSin(chart, chartpoh, textBox_in.Text).ToString();
        }

        private void button_myfunc_Click(object sender, RoutedEventArgs e)
        {
            textBox_out.Text = controlClass.CallMyFunc(chart, chartpoh, textBox_in.Text).ToString();
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
