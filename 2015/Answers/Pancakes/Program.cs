using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pancakes
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] lines = File.ReadAllLines("very-small.in");
            string[] lines = File.ReadAllLines("B-large.in");

            int noOfCases = int.Parse(lines[0]);
            List<string> output = new List<string>();

            for (int i = 1; i <= noOfCases; i++)
            {
                var result = 0;
                var diners = int.Parse(lines[i * 2 - 1]);
                var plates = lines[i * 2].Split(' ').Select(s => int.Parse(s)).ToList();

                List<int> strats = new List<int>();
                List<int> strats9 = new List<int>();

                if ((diners == 1) && (plates[0] <= 3))
                {
                    result = plates[0];
                }
                else
                {
                    PlayWithPancakes(plates, ref strats, 0, true);
                    PlayWithPancakes(plates, ref strats9, 0, false);

                    var min1 = strats.Min();
                    var min2 = strats9.Min();

                    result = (min1 < min2) ? min1 : min2;//strats.Min();
                }

                string print = String.Format("Case #{0}: {1}", i, result);
                output.Add(print);
                Console.WriteLine(print);
            }
            File.WriteAllLines("output.out", output);
            Console.WriteLine("Done.");
            Console.ReadKey();
        }

        private static void PlayWithPancakes(List<int> plates, ref List<int> strats, int level, bool nine)
        {
            plates = plates.OrderByDescending(i => i).ToList();
            int topPlate = plates.Take(1).ToArray()[0];
            if (topPlate > 3)
            {
                int newPlate = 0;
                if (nine)
                {
                    switch (topPlate)
                    {
                        case 9: newPlate = 3; break;
                        default: newPlate = topPlate / 2; break;
                    }
                }
                else newPlate = topPlate / 2;

                plates.RemoveAt(0);

                plates.Add(newPlate);

                plates.Add(topPlate - newPlate);

                strats.Add(topPlate + level);
                PlayWithPancakes(plates, ref strats, level + 1, nine);
            }
            else
            {
                strats.Add(topPlate + level);
            }

        }
    }
}
