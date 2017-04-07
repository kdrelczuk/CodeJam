using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StamdingOvation7pts
{
    class Program
    {
        public static long IntPower(int x, short power)
        {
            if (power == 0) return 1;
            if (power == 1) return x;
            // ----------------------
            int n = 15;
            while ((power <<= 1) >= 0) n--;

            long tmp = x;
            while (--n > 0)
                tmp = tmp * tmp *
                     (((power <<= 1) < 0) ? x : 1);
            return tmp;
        }

        static void Main(string[] args)
        {
            //string[] lines = File.ReadAllLines("A-small-attempt1.in");

            string[] lines = File.ReadAllLines("A-large.in");
         
            //string[] lines = File.ReadAllLines("very-small.in");

            int noOfCases = int.Parse(lines[0]);
            List<string> output = new List<string>();

            for (int i = 1; i <= noOfCases; i++)
            {
                var persons = 0;
                var result = 0;
                var tokens = lines[i].Split(' ')[1].Select(s => int.Parse(new String(new char[] { s }))).ToArray();
                for (int pos = 0; pos < tokens.Count(); pos++)
                {
                    if (tokens[pos] == 0)
                    {
                        if (persons <= pos)
                        {
                            persons += 1;
                            result += 1;
                        }
                    }
                    else
                    {
                        persons += tokens[pos];
                    }
                }
                string print = String.Format("Case #{0}: {1}", i, result);
                output.Add(print);
                Console.WriteLine(print);
            }
            File.WriteAllLines("output.out", output);
            Console.WriteLine("Done.");
            Console.ReadKey();
        }
    }
}
