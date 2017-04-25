using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace QRound.Pancake
{
    class Program
    {
        public static KeyValuePair<List<int>, int> pancakes = new KeyValuePair<List<int>, int>();

        static List<int> Flip(List<int> pancake, int size)
        {
            int startValue = pancake.FindIndex(i => i == 0);
            if (startValue + size > pancake.Count()) throw new Exception();
            for (int i = 0; i < size; i++)
            {
                pancake[startValue + i] = (pancake[startValue + i] == 1 ? 0 : 1);
            }
            return pancake;
        }

        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("A-large.in");
            int noOfCases = int.Parse(lines[0]);
            List<string> output = new List<string>();

            for (int i = 1; i <= noOfCases; i++)
            {
                var tokens = lines[i].Split(' ');
                var pancake = new KeyValuePair<List<int>, int>(
                    tokens[0].ToCharArray().Select(x => x == '-' ? 0 : 1).ToList(),
                    Int32.Parse(tokens[1])
                    );
                int flips = 0;
                try
                {
                    if (pancake.Key.Sum() != pancake.Key.Count())
                    {
                        List<int> localPancake = pancake.Key;

                        while (localPancake.Count() != localPancake.Sum())
                        {
                            flips += 1;
                            //if (pancakes.Sum() == 0) { break; }
                            localPancake = Flip(localPancake, pancake.Value);
                        }
                    }
                    output.Add(String.Format("Case #{0}: {1}", i, flips));
                }
                catch
                {
                    output.Add(String.Format("Case #{0}: {1}", i, "IMPOSSIBLE" ));
                }
            }
            File.WriteAllLines("output_lg.out", output);
            Console.WriteLine("DONE");
        }
    }
}
