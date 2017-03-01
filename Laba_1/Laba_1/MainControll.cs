using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Laba_1
{
    class MainControll
    {
        public void OpenLinWindow()
        {
            Window_Lin win_1 = new Window_Lin();

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

        public void OpenRozWindow()
        {
            Window_Roz win_1 = new Window_Roz();

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

        public void OpenCircleWindow()
        {
            Window_Circle win_1 = new Window_Circle();

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
