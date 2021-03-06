﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_4
{
    class Interpolation
    {

        public static double CountInterpol(double[] nodes,int n,double x,double h,double a)
        {
            int size = n - 1;

            List<List<double>> koef = new List<List<double>>();

            koef.Add(nodes.ToList());

            for (int i = 0, k = 1; i < size; i++)
            {
                List<double> prom = new List<double>();
     
                for (int j = 0; j < size - i;j++)
                {
                    double x1 = a + j * h;
                    double x2 = a + (j + k) * h;
                    double value = (1 / (x2 - x1)) * (koef[i][j] * (x2 - x) - koef[i][j + 1] * (x1 - x));
                    prom.Add(value);
                }

                koef.Add(prom);
                k++;
            }

            return koef[size][0];
        }
    }
}
