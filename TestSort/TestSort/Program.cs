using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TestSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 1000000;
            Random random = new Random();
            UInt32[] mass = new UInt32[n];
            UInt32[] mass2 = new UInt32[n];
            UInt32[] mass3 = new UInt32[0];
            mass.Concat(mass2);
            int maxRoz = 9,
                max = 200000;
            /*
            List<UInt32> list0 = new List<UInt32>();
            List<UInt32> list1 = new List<UInt32>();
            List<UInt32> list2 = new List<UInt32>();
            List<UInt32> list3 = new List<UInt32>();
            List<UInt32> list4 = new List<UInt32>();
            List<UInt32> list5 = new List<UInt32>();
            List<UInt32> list6 = new List<UInt32>();
            List<UInt32> list7 = new List<UInt32>();
            List<UInt32> list8 = new List<UInt32>();
            List<UInt32> list9 = new List<UInt32>();
            */
            for (int i = 0; i < n; i++)
                mass[i] = (UInt32)random.Next(max);
            /*
           for (int i = 0; i < maxRoz;i++)
           {
                list0 = new List<uint>();
                list1 = new List<uint>();
                list2 = new List<uint>();
                list3 = new List<uint>();
                list4 = new List<uint>();
                list5 = new List<uint>();
                list6 = new List<uint>();
                list7 = new List<uint>();
                list8 = new List<uint>();
                list9 = new List<uint>();

                for (int j = 0, radix = 0, div = 0; j < n;j++)
                {
                    radix = (int)Math.Pow(10, i + 1);
                    div =(int) Math.Pow(10, i);
                    switch ((mass[j] % radix) / div)
                    {
                        case 0:
                            list0.Add(mass[j]);
                            break;
                        case 1:
                            list1.Add(mass[j]);
                            break;
                        case 2:
                            list2.Add(mass[j]);
                            break;
                        case 3:
                            list3.Add(mass[j]);
                            break;
                        case 4:
                            list4.Add(mass[j]);
                            break;
                        case 5:
                            list5.Add(mass[j]);
                            break;
                        case 6:
                            list6.Add(mass[j]);
                            break;
                        case 7:
                            list7.Add(mass[j]);
                            break;
                        case 8:
                            list8.Add(mass[j]);
                            break;
                        case 9:
                            list9.Add(mass[j]);
                            break;
                        default:
                            break;
                    }
                }

                if (list0.Count == n)
                    break;
                else
                {
                    mass = new UInt32[0];
                    mass = mass.Concat(list0).ToArray();
                    mass = mass.Concat(list1).ToArray();
                    mass = mass.Concat(list2).ToArray();
                    mass = mass.Concat(list3).ToArray();
                    mass = mass.Concat(list4).ToArray();
                    mass = mass.Concat(list5).ToArray();
                    mass = mass.Concat(list6).ToArray();
                    mass = mass.Concat(list7).ToArray();
                    mass = mass.Concat(list8).ToArray();
                    mass = mass.Concat(list9).ToArray();
                }
           }
           */
            Stopwatch multiWatch = new Stopwatch();

            Sort sort = new Sort(mass);

            multiWatch.Start();
            uint[] mass1 = First(mass, n, maxRoz);
            multiWatch.Stop();
            TimeSpan ts = multiWatch.Elapsed;
            Console.WriteLine("{0}", String.Format("{0:00}", ts.Minutes) + " хвилин " + String.Format("{0:00}", ts.Seconds) + " секунд " + String.Format("{0:00}", ts.Milliseconds) + " мілісекунд");

            multiWatch = new Stopwatch();
            multiWatch.Start();
            sort.qsort(0, n - 1);
            multiWatch.Stop();
            ts = multiWatch.Elapsed;
            Console.WriteLine("{0}", String.Format("{0:00}", ts.Minutes) + " хвилин " + String.Format("{0:00}", ts.Seconds) + " секунд " + String.Format("{0:00}", ts.Milliseconds) + " мілісекунд");
            Console.ReadKey();
        }

        static uint[] First(uint[] mass,int n,int maxRoz)
        {
            List<UInt32> list0 = new List<UInt32>();
            List<UInt32> list1 = new List<UInt32>();
            List<UInt32> list2 = new List<UInt32>();
            List<UInt32> list3 = new List<UInt32>();
            List<UInt32> list4 = new List<UInt32>();
            List<UInt32> list5 = new List<UInt32>();
            List<UInt32> list6 = new List<UInt32>();
            List<UInt32> list7 = new List<UInt32>();
            List<UInt32> list8 = new List<UInt32>();
            List<UInt32> list9 = new List<UInt32>();

            for (int i = 0; i < maxRoz; i++)
            {
                list0 = new List<uint>();
                list1 = new List<uint>();
                list2 = new List<uint>();
                list3 = new List<uint>();
                list4 = new List<uint>();
                list5 = new List<uint>();
                list6 = new List<uint>();
                list7 = new List<uint>();
                list8 = new List<uint>();
                list9 = new List<uint>();

                for (int j = 0, radix = 0, div = 0; j < n; j++)
                {
                    radix = (int)Math.Pow(10, i + 1);
                    div = (int)Math.Pow(10, i);
                    switch ((mass[j] % radix) / div)
                    {
                        case 0:
                            list0.Add(mass[j]);
                            break;
                        case 1:
                            list1.Add(mass[j]);
                            break;
                        case 2:
                            list2.Add(mass[j]);
                            break;
                        case 3:
                            list3.Add(mass[j]);
                            break;
                        case 4:
                            list4.Add(mass[j]);
                            break;
                        case 5:
                            list5.Add(mass[j]);
                            break;
                        case 6:
                            list6.Add(mass[j]);
                            break;
                        case 7:
                            list7.Add(mass[j]);
                            break;
                        case 8:
                            list8.Add(mass[j]);
                            break;
                        case 9:
                            list9.Add(mass[j]);
                            break;
                        default:
                            break;
                    }
                }

                if (list0.Count == n)
                    break;
                else
                {
                    mass = new UInt32[0];
                    mass = mass.Concat(list0).ToArray();
                    mass = mass.Concat(list1).ToArray();
                    mass = mass.Concat(list2).ToArray();
                    mass = mass.Concat(list3).ToArray();
                    mass = mass.Concat(list4).ToArray();
                    mass = mass.Concat(list5).ToArray();
                    mass = mass.Concat(list6).ToArray();
                    mass = mass.Concat(list7).ToArray();
                    mass = mass.Concat(list8).ToArray();
                    mass = mass.Concat(list9).ToArray();
                }
            }

            return mass;
        }
        int y = 0;
    }

    public class Sort
    {
        public uint[] test;
        public Sort(uint[] mass)
        {
            this.test = mass;
        }

        public void qsort(int start, int finish)
        {
            if (finish - start > 20)
            {
                int wall = start,
                    opor = finish;
                uint prom;

                for (int i = start; i < finish; i++)
                {
                    if (test[i] <= test[opor])
                    {
                        prom = test[wall];
                        test[wall] = test[i];
                        test[i] = prom;
                        wall++;
                    }
                }

                prom = test[wall];
                test[wall] = test[opor];
                test[opor] = prom;

                if (wall != 0)
                    qsort(start, wall - 1);

                if (wall != finish)
                    qsort(wall + 1, finish);
            }
            else if (finish - start != 0)
            {
                for (int i = 0; i < (finish - start); i++)
                {
                    bool swap = false;

                    for (int j = start; j < finish - i; j++)
                    {
                        if (test[j] > test[j + 1])
                        {
                            uint prom = test[j];
                            test[j] = test[j + 1];
                            test[j + 1] = prom;
                            swap = true;
                        }
                    }

                    if (!swap)
                        break;
                }
            }
        }
    }
}

