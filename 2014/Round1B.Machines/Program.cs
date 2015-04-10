using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Round1B.Machines
{
    class Program
    {
        private static string Go(int a, int b, int k)
        {
            int res = 0;
            int max = (new int[3] { a, b, k }).Min();
            for (int ia = 0; ia < k; ia++)
            {
                for (int ib = 0; ib < k; ib++)
                {
                    var v = ia & ib;
                    if (v < k)
                    {
                        res++;
                    }
                }
            }
            return res.ToString();
        }

        static void Main(string[] args)
        {
            //string[] lines = File.ReadAllLines("B-large.in");
            string[] lines = File.ReadAllLines("B-small-attempt0.in");

            int noOfCases = int.Parse(lines[0]);
            List<string> output = new List<string>();
            int index = 1;
            for (int i = 0; i < noOfCases; i++)
            {
                int[] values = lines[i + 1].Split(' ').Select(s => int.Parse(s)).ToArray();
                output.Add(String.Format("Case #{0}: {1}", (i + 1).ToString(), Go(values[0], values[1], values[2])));
            }
            File.WriteAllLines("B-small-attempt0_new.out", output);
        }
    }
}
