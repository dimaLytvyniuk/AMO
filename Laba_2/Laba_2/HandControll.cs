using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.IO;
using Microsoft.Win32;

namespace Laba_2
{
    class HandControll
    {
        List<uint> massives;
        uint[] outputMass;
        ListBox inList,
                outList;

        public HandControll(ListBox inList,ListBox outList)
        {
            this.inList = inList;
            this.outList = outList;
            massives = new List<uint>();
        }

        public bool AddElement(string value)
        {
            try
            {
                uint val = Convert.ToUInt32(value);
                massives.Add(val);
                UpdateInList();
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        private void UpdateInList()
        {
            inList.Items.Clear();
            string str = "";

            for (int j = 0, row = 9, size = massives.Count; j < size; j++)
            {
                str += String.Format("{0,10}", massives[j]);

                if (j == row)
                {
                    inList.Items.Add(str);
                    row += 10;
                    str = "";
                }
            }

            inList.Items.Add(str);
            inList.Items.Add("");
        }

        private void UpdateOutList()
        {
            outList.Items.Clear();

            string str = "";

            for (int j = 0, row = 9, size = outputMass.Length; j < size; j++)
            {
                str += String.Format("{0,10}", outputMass[j]);

                if (j == row)
                {
                    outList.Items.Add(str);
                    row += 10;
                    str = "";
                }
            }

            outList.Items.Add(str);
            outList.Items.Add("");
        }

        public void Sort()
        {
            if (massives.Count > 1)
            {
                outputMass = RadixSort.Sort(massives.ToArray(), massives.Count, 10);
                UpdateOutList();
                MessageBox.Show("Сортування виконано", "Complete");
            }
        }

        public void ReadFromFile()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text file (*.txt)|*.txt";
            openFileDialog1.FileName = "deafault.txt";

            if (true == openFileDialog1.ShowDialog())
            {
                using (StreamReader reader = new StreamReader(openFileDialog1.FileName))
                {
                    string str = "";

                    while ((str = reader.ReadLine()) != null)
                    {
                        string[] words = str.Split(' ');
                        
                        for (int i = 0, size = words.Length; i < size;i++)
                        {
                            try
                            {
                                massives.Add(Convert.ToUInt32(words[i]));
                            }
                            catch
                            {
                                
                            }
                        }
                    }
                }
            }

            UpdateInList();
        }
    }
}
