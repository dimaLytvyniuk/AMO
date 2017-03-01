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
    class CircleControll
    {
        private UInt32 f = 0;

        public UInt32 F
        {
            get
            {
                return f;
            }
        }

        public bool CalcS(string n, string p)
        {
            UInt32 n1, p1;

            f = 0;

            try
            {
                n1 = Convert.ToUInt32(n);
                p1 = Convert.ToUInt32(p);

                for (int a = 0; a <= n1;a++)
                {
                    for (int b = 0; b <= p1; b++)
                    {
                        f += (UInt32) (Math.Pow(a, b) + Math.Pow(b, a));
                    }
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
            string output = "result_circle.txt";

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
                            str += "   f =" + f.ToString();
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
