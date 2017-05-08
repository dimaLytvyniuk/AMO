using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_5
{
    class ControllClass
    {
        public string CountRes(string xIn, string bIn, string nIn)
        {
            string res = null;
            int n;
            double[][] x;

            try
            {
                n = Convert.ToInt32(nIn);

                xIn = xIn.Replace("\r\n", "\n");

                string[] words = xIn.Split('\n');


                if (words.Length != n)
                    return res;

               x = new double[n][];

                for (int i = 0; i < n; i++)
                {
                    string[] nums = words[i].Split(' ');

                    if (nums.Length < n)
                        return res;

                    x[i] = new double[n + 1];
                    
                    for (int j = 0; j < n; j++)
                    {
                        x[i][j] = Convert.ToDouble(nums[j]);
                    }
                }

                bIn = bIn.Replace("\r\n", " ");

                words = bIn.Split(' ');

                if (words.Length != n)
                    return res;

                for (int i = 0; i < n; i++)
                    x[i][n] = Convert.ToDouble(words[i]);
            }
            catch (Exception e)
            {
                return res;
            }

            double[] result = SystemGaus.SearchRoot(n, x);

            for (int i = 0; i < n; i++)
            {
                res += "x" + (i + 1) + " = " + Math.Round(result[i], 5) + "\r\n";
            }

            return res;
        }
    }
}
