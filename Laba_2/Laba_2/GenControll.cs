using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace Laba_2
{
    class GenControll
    {
        List<int> n;
        List<uint>   max;
        List<uint[]> massives;
        List<uint[]> outMassives;
        List<string> outputData,
                     inputData;
        TimeSpan[] statistic;
        public bool InputValues(List<string> n,List<string> max)
        {
            this.n = new List<int>();
            this.max = new List<uint>();

            for (int i = 0; i < 10;i++)
            {
                try
                {
                    this.n.Add(Convert.ToInt32(n[i]));
                    this.max.Add(Convert.ToUInt32(max[i]));
                }
                catch (Exception e)
                {
                    return false;
                }
            }

            return true;
        }

        public void Sort(ListBox inList,ListBox outList)
        {
            statistic = new TimeSpan[10];
            outMassives = new List<uint[]>();
            GenerateMassives();
            for (int i = 0; i < 10; i++)
            {
                Stopwatch multiWatch = new Stopwatch();
                multiWatch.Start();
                outMassives.Add(RadixSort.Sort(massives[i], n[i], RadixSort.CountRoz(max[i])));
                multiWatch.Stop();
                statistic[i] = multiWatch.Elapsed;
            }

            CreateDataBefore();
            CreateDataAfter();

            PrintData(inList, inputData);
            PrintData(outList, outputData);

            MessageBox.Show("Сортування виконано", "Complete");
        }

        private void GenerateMassives()
        {
            Random random = new Random();
            massives = new List<uint[]>();

            for (int i = 0; i < 10;i++)
            {
                uint[] mass = new uint[n[i]];
                
                for (int j = 0; j < n[i];j++)
                    mass[j] =(uint)random.Next((int)max[i]);

                massives.Add(mass);
            }
        }

        private void CreateDataAfter()
        {
            outputData = new List<string>();

            for (int i = 0; i < 10;i++)
                outputData.Add("Масив №: " + (i + 1) + "К-сть елементів=" + n[i] + " Час сортування: " + String.Format("{0:00}", statistic[i].Minutes) + " хвилин " + String.Format("{0:00}", statistic[i].Seconds) + " секунд " + String.Format("{0:00}", statistic[i].Milliseconds) + " мілісекунд" + "\n");

            for (int i = 0; i < 10; i++)
            {
                string str = "";
                outputData.Add("Масив №: " + (i + 1));
                for (int j = 0,row = 9; j < n[i]; j++)
                {
                    str += String.Format("{0,10}", outMassives[i][j]);
                    if (j == row)
                    {
                        outputData.Add(str);
                        row += 10;
                        str = "";
                    }
                }
                outputData.Add(str);
               }
        }

        private void CreateDataBefore()
        {
            inputData = new List<string>();

            for (int i = 0; i < 10;i++)
            {
                string str = "";
                inputData.Add("Масив №: " + (i + 1));
                for (int j = 0, row = 9; j < n[i]; j++)
                {
                    str += String.Format("{0,10}", massives[i][j]);
                    if (j == row)
                    {
                        inputData.Add(str);
                        row += 10;
                        str = "";
                    }
                }
                inputData.Add(str);
                inputData.Add("");
            }
        }

        private void PrintData(ListBox listBox,List<string> list)
        {
            for (int j = 0; j < list.Count; j++)
                listBox.Items.Add(list[j]);
        }
    }
}
