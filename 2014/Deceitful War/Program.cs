using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deceitful_War
{
    class Program
    {
        class Game
        {
            public decimal[] naomi, ken;

            List<decimal> kenNotUsed;
            List<decimal> naomiNotUsed;

            public string Go()
            {
                kenNotUsed = new List<decimal>(ken);
                naomiNotUsed = new List<decimal>(naomi);
                kenNotUsed.Sort();
                naomiNotUsed.Sort();

                int war = 0;
                int dwar = 0;
                int length = naomi.Length;

                for (int i = 0; i < length; i++)
                {
                    if (!forken(naomi[i])) { war++; }
                    if (fornaomi(ken[i])) { dwar++; }
                }
                return String.Format("{0} {1}", dwar, war);
            }

            private bool fornaomi(decimal w)
            {
                if (naomiNotUsed[naomiNotUsed.Count - 1] > w)
                {
                    for (int i = 0; i < naomiNotUsed.Count; i++)
                    {
                        if (naomiNotUsed[i] > w)
                        {
                            naomiNotUsed.RemoveAt(i);
                            return true;
                        }
                    }
                }
                naomiNotUsed.RemoveAt(0);
                return false;
            }

            private bool forken(decimal w)
            {
                for (int i = 0; i < kenNotUsed.Count; i++)
                {
                    if (kenNotUsed[i] > w)
                    {
                        kenNotUsed.RemoveAt(i);
                        return true;
                    }
                }
                kenNotUsed.RemoveAt(0);
                return false;
            }
        }

        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("D-large.in");
            int noOfCases = int.Parse(lines[0]);
            List<string> output = new List<string>();
            for (int i = 1; i <= noOfCases; i++)
            {
                var tokensNaomi = lines[i * 2 + i - 1].Split(' ').Select(p => decimal.Parse(p, CultureInfo.InvariantCulture));
                var tokensKen = lines[i * 2 + i].Split(' ').Select(p => decimal.Parse(p, CultureInfo.InvariantCulture));
                Game g = new Game() { ken = tokensKen.ToArray(), naomi = tokensNaomi.ToArray() };
                output.Add(String.Format("Case #{0}: {1}", i, g.Go()));
            }
            File.WriteAllLines("OutputBig.txt", output);
        }
    }
}
