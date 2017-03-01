using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;

namespace Laba_1
{
    class RozControll
    {
        private double y;

        public double Y
        {
            get
            {
                return y;
            }
        }

        public bool CalcS(string x,string r)
        {
            double x1, r1;

            try
            {
                x1 = Convert.ToDouble(x);
                r1 = Convert.ToDouble(r);

                double chis = 4 * r1 - r1 * x1,
                       znam = 4 * x1 - r1 * x1;

                if (znam != 0)
                {
                    y = chis/znam;
                }
                else
                {
                    MessageBox.Show("Не коректні дані: знамменик = 0", "Помилка");
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Не коректні дані", "Помилка");
                return false;
            }

            return true;
        }

        public bool CalcF()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text file (*.txt)|*.txt";
            openFileDialog1.FileName = "deafault.txt";
            List<string> result = new List<string>();
            string output = "result_roz.txt";

            if (true == openFileDialog1.ShowDialog())
            {
                using (StreamReader reader = new StreamReader(openFileDialog1.FileName))
                {
                    string str = "";

                    bool format;

                    while ((str = reader.ReadLine()) != null)
                    {
                        string[] words = str.Split(' ');

                        if (words.Length != 2)
                        {
                            MessageBox.Show("Не коректні дані у файлі", "Помилка");
                            return false;
                        }

                        format = CalcS(words[0], words[1]);

                        if (format)
                        {
                            str += "   y =" + y.ToString();
                            result.Add(str);
                        }
                        else
                        {
                            MessageBox.Show("Не коректні дані у файлі", "Помилка");
                            return false;
                        }
                    }
                }

                using (StreamWriter writer = new StreamWriter(output, false))
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        writer.WriteLine(result[i]);
                    }
                }

                //MessageBox.Show("Результат записаний у файл " + output, "Complete");
                Process.Start(output);
                return true;
            }
            else
            {
                MessageBox.Show("Не коректні дані у файлі", "Помилка");
                return false;
            }
        }
    }
}
