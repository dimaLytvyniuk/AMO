using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_5
{
    class SystemGaus
    {
        public static double[] SearchRoot(int n, double[][] x)
        {
            double[] result = new double[n];
            double m = 0;
            int max = 0;

            for (int k = 0; k < n - 1; k++)
            {
                max = k;

                for (int i = k + 1; i < n; i++)
                    if (Math.Abs(x[max][k]) < Math.Abs(x[i][k]))
                        max = i;

                if (max != k)
                {
                    double[] prom = x[k];
                    x[k] = x[max];
                    x[max] = prom;
                }

                for (int j = k + 1; j < n; j++)
                {
                    m = x[j][k] / x[k][k];

                    for (int i = k; i <= n; i++)
                        x[j][i] = x[j][i] - m * x[k][i];
                }
            }

            result[n - 1] = x[n - 1][n] / x[n - 1][n - 1];

            for (int i = n - 2;i >=0; i--)
            {
                result[i] = x[i][n] / x[i][i];

                    for (int j = n - 1; j > i; j--)
                        result[i] -= x[i][j] * result[j] / x[i][i];
            }


            return result;
        }
    }
}
