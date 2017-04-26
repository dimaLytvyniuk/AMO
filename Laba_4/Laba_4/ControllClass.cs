using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Controls;
using System.Windows.Data;

namespace Laba_4
{
    class ControllClass
    {
        private void PrintGraph(Chart chart, double a, double b, double[] nodes, int n, double h)
        {
            int n1 = 121;

            double h1 = (b - a) / (n1 - 1);

            double[] y1 = new double[n1],
                        x1 = new double[n1],
                        y2 = new double[n1];

            for (int i = 0; i < n1; i++)
            {
                x1[i] = a + i * h1;
                y1[i] = Interpolation.CountInterpol(nodes, n, x1[i], h, a);
                y2[i] = Math.Pow(2, x1[i]) - 4 * x1[i];
            }

            chart.ChartAreas.Clear();
            chart.Series.Clear();
            chart.ChartAreas.Add(new ChartArea("Default"));

            chart.Series.Add(new Series("Sin_Inter"));
            chart.Series["Sin_Inter"].ChartArea = "Default";
            chart.Series["Sin_Inter"].ChartType = SeriesChartType.Line;
            chart.Series["Sin_Inter"].Points.DataBindXY(x1, y1);
            chart.Series["Sin_Inter"].Color = System.Drawing.Color.Green;
        }

        public double SerchRes(Chart chart, string a1, string b1, string e1)
        {
            double a = 0,
                b = 0,
                e = 0;

            try
            {
                a = Convert.ToDouble(a1);
                b = Convert.ToDouble(b1);
                e = Convert.ToDouble(e1);
            }
            catch (Exception err)
            {
                return Double.NaN;
            }

            if (a < b && e > 0 && e < 1)
            {
                int n = 31;

                double h = (b - a) / (n - 1),
                        result = 0;

                double[] nodes = new double[n],
                            x = new double[n];

                for (int i = 0; i < n; i++)
                {
                    x[i] = a + i * h;
                    nodes[i] = Math.Pow(2, x[i]) - 4 * x[i];
                }

                PrintGraph(chart, a, b, nodes, n, h);

                if (nodes[0] * nodes[n - 1] < 0)
                {
                    int k = 0;
                    double poh = 0,
                            c = 0,
                            akoef = a,
                            bkoef = b;

                    do
                    {
                        c = (bkoef + akoef) / 2;

                        if (Interpolation.CountInterpol(nodes, n, c, h, a) == 0)
                            break;

                        if (Interpolation.CountInterpol(nodes, n, c, h, a) * Interpolation.CountInterpol(nodes, n, akoef, h, a) < 0)
                            bkoef = c;
                        else
                            akoef = c;

                        poh = Math.Abs(bkoef - akoef) / Math.Pow(2, k);
                        k++;
                    }
                    while (Math.Abs(poh) > e);

                    return c;
                }
                else
                    return Double.NaN;
            }
            else
                return Double.NaN;
        }
    }
}