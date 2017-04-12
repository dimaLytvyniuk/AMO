using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestInterpol
{
    class Program
    {
        static void Main(string[] args)
        {
            double b = 3,
                a = 0;
            int n = 11;

            double h =(double)((b - a) / (n - 1));
            double[] nodes = new double[n];
            /*
            for (int i = 0; i < n; i++)
                nodes[i] = Math.Sin(a + h * i);
            */

            for (int i = 0; i < n; i++)
            {
                double x = a + h * i;
                nodes[i] = Math.Sin(Math.Pow(x,2)) * Math.Exp(-1 * Math.Pow(x / 2,2));
            }

            double x1 = 0.5;
            double val = Math.Sin(Math.Pow(x1, 2)) * Math.Exp(-1 * Math.Pow(x1 / 2, 2));


            Interpolation.CountInterpol(nodes, n, 0.5, h, a);
        }
    }
}
