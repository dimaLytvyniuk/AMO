using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Controls;
using System.Windows.Data;

namespace Laba_3
{
    class ControlClass
    {
        const int n = 11;

        double[] nodes;
        double[] x,
                 y1,
                 y2,
                 xnodes,
                 pohnodes,
                 ypoh,
                 yrizn;
        int datasize = 0;
        string[] xstr;
        DataGrid dataNodes,
                 dataValues,
                 dataPoh;

        public ControlClass(DataGrid dataNodes, DataGrid dataValues,  DataGrid dataPoh)
        {
            this.dataNodes = dataNodes;
            this.dataValues = dataValues;
            this.dataPoh = dataPoh;
        }

        public double CallSin(Chart chart, string val)
        {
            double a = 0,
                   b = 9,
                   h = ((b - a) / (n - 1)),
                   h2 = h / 4,
                   hpoh = ((b - a) / n);
            double value = 0;
            bool str = true;
            
            try
            {
                value = Convert.ToDouble(val);
            }
            catch (Exception e)
            {
                str = false;
            }

            if (str && (value > b || value < a))
                MessageBox.Show("x знаходиться поз проміжком [0,9]");
            else 
            {
                double result = 0;

                nodes = new double[n];
                xnodes = new double[n];
                pohnodes = new double[n + 1];

                for (int i = 0; i < n; i++)
                {
                    xnodes[i] = a + h * i;
                    nodes[i] = Math.Sin(xnodes[i]);
                }

                //n + 1 многочлен 
                for (int i = 0; i < n + 1;i++)
                    pohnodes[i] = Math.Sin(a + hpoh * i);

                result = Interpolation.CountInterpol(nodes, n, value, h, a);

                datasize = (n - 1) * 4 + 1;

                x = new double[datasize];
                y1 = new double[datasize];
                y2 = new double[datasize];
                xstr = new string[datasize];
                ypoh = new double[datasize];
                yrizn = new double[datasize];

                for (int i = 0; i < datasize; i++)
                {
                    x[i] = a + h2 * i;
                    xstr[i] = x[i].ToString();
                    y1[i] = Interpolation.CountInterpol(nodes, n, x[i], h, a);
                    y2[i] = Math.Sin(x[i]);
                    ypoh[i] = Interpolation.CountInterpol(pohnodes, n + 1, x[i], hpoh, a);
                    yrizn[i] = Math.Abs(ypoh[i] - y1[i]);
                }

                PrintGraph(chart);
                MakeTables();
                return result;
            }

            return 0;
        }

        public double CallMyFunc(Chart chart, string val)
        {
            double a = 0,
                   b = 3,
                   h = ((b - a) / (n - 1)),
                   h2 = h / 8,
                   hpoh = ((b - a) / n);

            double value = 0;
            bool str = true;

            try {
                value = Convert.ToDouble(val);    
            }
            catch (Exception e)
            {
                str = false;
            }

            if (str && (value > b || value < a))
                MessageBox.Show("x знаходиться поз проміжком [0,3]");
            else
            {
                double result = 0;

                nodes = new double[n];
                xnodes = new double[n];
                pohnodes = new double[n + 1];

                for (int i = 0; i < n; i++)
                {
                    xnodes[i] = a + h * i;
                    nodes[i] = Math.Sin(Math.Pow(xnodes[i], 2)) * Math.Exp(-1 * Math.Pow(xnodes[i] / 2, 2));
                }

                //n + 1 многочлен 
                for (int i = 0; i < n + 1; i++)
                    pohnodes[i] = Math.Sin(Math.Pow(a + hpoh * i, 2)) * Math.Exp(-1 * Math.Pow((a + hpoh * i) / 2, 2));

                result = Interpolation.CountInterpol(nodes, n, value, h, a);

                datasize = (n - 1) * 8 + 1;

                x = new double[datasize];
                y1 = new double[datasize];
                y2 = new double[datasize];
                xstr = new string[datasize];
                ypoh = new double[datasize];
                yrizn = new double[datasize];

                for (int i = 0; i < datasize; i++)
                {
                    x[i] = a + h2 * i;
                    xstr[i] = x[i].ToString();
                    y1[i] = Interpolation.CountInterpol(nodes, n, x[i], h, a);
                    y2[i] = Math.Sin(Math.Pow(x[i], 2)) * Math.Exp(-1 * Math.Pow(x[i] / 2, 2));
                    ypoh[i] = Interpolation.CountInterpol(pohnodes, n + 1, x[i], hpoh, a);
                    yrizn[i] = Math.Abs(ypoh[i] - y1[i]);
                }

                PrintGraph(chart);
                MakeTables();
                return result;
            }

            return 0;
        }

        private void PrintGraph(Chart chart)
        {
            // Все графики находятся в пределах области построения ChartArea, создадим ее
            chart.ChartAreas.Clear();
            chart.Series.Clear(); 
            chart.ChartAreas.Add(new ChartArea("Default"));

            // Добавим линию, и назначим ее в ранее созданную область "Default"
            chart.Series.Add(new Series("Sin_Inter"));
            chart.Series["Sin_Inter"].ChartArea = "Default";
            chart.Series["Sin_Inter"].ChartType = SeriesChartType.Line;

            // добавим данные линии
            chart.Series["Sin_Inter"].Points.DataBindXY(xstr, y1);
            chart.Series["Sin_Inter"].Color = System.Drawing.Color.Black;
            chart.Series.Add(new Series("Sin_Real"));
            chart.Series["Sin_Real"].ChartArea = "Default";
            chart.Series["Sin_Real"].ChartType = SeriesChartType.Line;

            // добавим данные линии
            chart.Series["Sin_Real"].Points.DataBindXY(xstr, y2);
            chart.Series["Sin_Real"].Color = System.Drawing.Color.Red;
        }

        private void MakeTables()
        {
            dataNodes.Items.Clear();
            dataValues.Items.Clear();

            for (int i = 0; i < nodes.Length; i++)
            {
                var col = new DataGridTextColumn();
                col.Header = "x" + i;
                col.Binding = new Binding(string.Format("[{0}]", i));
                dataNodes.Columns.Add(col);
            }

            dataNodes.Items.Add(xnodes);
            dataNodes.Items.Add(nodes);

            for (int i = 0; i < x.Length; i++)
            {
                var col = new DataGridTextColumn();
                col.Header = "x" + i;
                col.Binding = new Binding(string.Format("[{0}]", i));
                dataValues.Columns.Add(col);
            }

            dataValues.Items.Add(x);
            dataValues.Items.Add(y1);
            dataValues.Items.Add(y2);

            for (int i = 0; i < x.Length; i++)
            {
                var col = new DataGridTextColumn();
                col.Header = "x" + i;
                col.Binding = new Binding(string.Format("[{0}]", i));
                dataPoh.Columns.Add(col);
            }

            dataPoh.Items.Add(y1);
            dataPoh.Items.Add(ypoh);
            dataPoh.Items.Add(yrizn);
        }

    }
}
