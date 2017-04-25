using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace QRound.BathroomStalls
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("C-small-2-attempt1.in");
            int noOfCases = int.Parse(lines[0]);
            List<string> output = new List<string>();

            for (int i = 1; i <= noOfCases; i++)
            {
                var tokens = lines[i].Split(' ');
                Tuple<int, int> nums = new Tuple<int, int>(Int32.Parse(tokens[0]), Int32.Parse(tokens[1]));

                int min = -1, max = -1;

                if (nums.Item1 == nums.Item2)
                {
                    min = 0;
                    max = 0;
                }
                else if (nums.Item2 == 1)
                {
                    if (nums.Item1 % 2 == 0)
                    {
                        min = (nums.Item1 / 2) - 1;
                    }
                    else
                    {
                        min = nums.Item1 / 2;
                    }
                    max = nums.Item1 / 2;
                }
                else if ((nums.Item2 * 2 > nums.Item1 * 1.25))
                {
                    min = 0;
                    max = 0;
                }
                else
                {
                    var splits = new List<int>(nums.Item2 * 2);
                    splits.Add(nums.Item1);
                    for (int ix = 0; ix < nums.Item2; ix++)
                    {
                        if (min <= 3 || max <= 3)
                        {
                         //   splits = splits.OrderByDescending(s => s).ToList();
                        }

                        var val1 = (splits[0] - 1) / 2;
                        var val2 = splits[0] - 1 - val1;
                        splits.RemoveAt(0);
                        min = val1 > val2 ? val2 : val1;
                        max = val1 > val2 ? val1 : val2;
                        splits.Add(max);
                        //if (min > 0)
                        //{
                        splits.Add(min);
                        //}
                        if (max == 0) { break; }
                    }
                    
                }

                var oline = String.Format("Case #{0}: {1} {2}", i, max, min);
                //Console.WriteLine(oline);
                output.Add(oline);
            }
            File.WriteAllLines("output_notsorted.out", output);
            Console.WriteLine("DONE");
        }
    }
}
