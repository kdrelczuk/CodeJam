using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fractiles
{
    class Program
    {
        private static int[] MakeComplex(int[] itiles)
        {
            int[] ret = new int[(int)Math.Pow(itiles.Length, 2)];
            for (int i = 0; i < itiles.Length; i++)
            {
                if (itiles[i] == 0)
                {
                    for (int j = 0; j < itiles.Length; j++)
                    {
                        ret[i * (itiles.Length) + j] = itiles[j];
                    }
                }
                else
                {
                    for (int j = 0; j < itiles.Length; j++)
                    {
                        ret[i * (itiles.Length) + j] = 1;
                    }
                }
            }
            return itiles;
        }

        //private static int[] MakeComplex(int[] tiles, int level)
        //{
        //    if (level > 0)
        //        MakeComplex(tiles, level - 1);
        //    else return MakeComplex(tiles);
        //}

        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            var io = new Io(new string[] { @"D-large.in" });

            List<string> output = new List<string>();

            var T = io.Read<int>();
            T.Times((X) =>
            {
                var L = io.ReadArray<int>();
                int K = L[0], C = L[1], S = L[2];

                if (C * S < K)
                {
                    string s1 = String.Format("Case #{0}: IMPOSSIBLE", X + 1);
                    output.Add(s1);
                    Console.WriteLine(s1);
                    return;
                }

                var pos = new List<long>();
                int i = 0;
                while (i < K)
                {
                    int pi = i;
                    i = Math.Min(i + C - 1, K - 1);

                    long p = 0;
                    while (pi <= i) p = p * K + (pi++);

                    pos.Add(p + 1);
                    ++i;
                }

                string s2 = String.Format("Case #{0}: {1}", X + 1, string.Join(" ", pos));
                output.Add(s2);
                Console.WriteLine(s2);
            });


            /*
            int noOfTiles = 3;
            int start = 1, stop = (int)Math.Pow(2, noOfTiles);

            for (int i = start; i < stop - 1; i++)
            {
                string t = Convert.ToString(i, 2).PadLeft(noOfTiles, '0');
                int[] tar = t.ToCharArray().Select(x => x == '1' ? 1 : 0).ToArray();
                var xx = MakeComplex(tar, 2);
                Console.WriteLine(t);
            }*/
            File.WriteAllLines("outputL.out", output);
            Console.ReadKey();
        }
    }
}
