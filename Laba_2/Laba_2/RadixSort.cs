using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_2
{
    class RadixSort
    {
        public static uint[] Sort(uint[] mass, int n, int maxRoz)
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

            return mass;
        }

        public static int CountRoz(uint value)
        {
            int roz = 1;

            while (value / 10 > 0)
            {
                value /= 10;
                roz++;
            }

            return roz;
        }
    }
}
