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

namespace Laba_2
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
            controlClass = new ControlClass();
        }

        private void button_Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void button_Gen_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            controlClass.OpenGenWindow();
            this.Visibility = Visibility.Visible;
        }

        private void button_Hand_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            controlClass.OpenHandWindow();
            this.Visibility = Visibility.Visible;
        }
    }
}
