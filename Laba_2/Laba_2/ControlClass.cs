using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Laba_2
{
    class ControlClass
    {
        public void OpenGenWindow()
        {
            Window_Gen win_1 = new Window_Gen();

            if (win_1.ShowDialog() == true)
            {
                win_1.WindowState = WindowState.Normal;

                if (win_1.DialogResult == true)
                {

                }
                else
                    Environment.Exit(0);
            }
            else
                Environment.Exit(0);
        }

        public void OpenHandWindow()
        {
            Window_Hand win_1 = new Window_Hand();

            if (win_1.ShowDialog() == true)
            {
                win_1.WindowState = WindowState.Normal;

                if (win_1.DialogResult == true)
                {

                }
                else
                    Environment.Exit(0);
            }
            else
                Environment.Exit(0);
        }
    }
}
