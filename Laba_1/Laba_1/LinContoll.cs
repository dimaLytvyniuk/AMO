using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using Microsoft.Win32;

namespace Laba_1
{
    class LinContoll
    {
        private double y1 = 0;

        public double Y1
        {
            get
            {
                return y1;
            }
        }

        public bool CalcS(string a,string b,string c,string d)
        {
            double a1, b1, c1, d1;
            try
            {
                a1 = Convert.ToDouble(a);
                b1 = Convert.ToDouble(b);
                c1 = Convert.ToDouble(c);
                d1 = Convert.ToDouble(d);

                if (d1 != 0)
                {
                    y1 = Math.Pow(d1 * a1, b1) + Math.Pow(d1 * a1, (1 / d1));
                }
                else
                {
                    MessageBox.Show("Не коректні дані: d = 0", "Помилка");
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
            string output = "result_lin.txt";

            if (true == openFileDialog1.ShowDialog())
            {
                using (StreamReader reader = new StreamReader(openFileDialog1.FileName))
                {
                    string str = "";

                    bool format;

                    while ((str = reader.ReadLine()) != null)
                    {
                        string[] words = str.Split(' ');
                        
                        if (words.Length != 4)
                        {
                            MessageBox.Show("Не коректні дані у файлі", "Помилка");
                            return false;
                        }

                        format = CalcS(words[0], words[1], words[2], words[3]);

                        if (format)
                        {
                            str +="   Y1 =" + y1.ToString();
                            result.Add(str);
                        }
                        else
                        {
                            MessageBox.Show("Не коректні дані у файлі", "Виконано");
                            return false;
                        }
                    }
                }

                using (StreamWriter writer = new StreamWriter(output, false))
                {
                    for (int i = 0; i < result.Count;i++)
                    {
                        writer.WriteLine(result[i]);
                    }
                }

                MessageBox.Show("Результат записаний у файл " + output, "Помилка");
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
