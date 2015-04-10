using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicTrick
{
    class Program
    {
        class TestCase
        {
            public int[][] firstCase = new int[4][];
            public int[][] secondCase = new int[4][];
            public int firstNumber, secondNumber;

            public string Test()
            {
                int[] x = firstCase[firstNumber - 1];
                int[] y = secondCase[secondNumber - 1];
                int? ans = null;
                foreach (int xi in x)
                {
                    foreach (int yi in y)
                    {
                        if (xi == yi)
                        {
                            if (ans.HasValue) { return "Bad magician!"; }
                            ans = xi;
                        }
                    }
                }
                if (!ans.HasValue) { return "Volunteer cheated!"; }
                return ans.Value.ToString(); ;
            }
        }

        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("A-small-attempt0.in");
            int noOfCases = int.Parse(lines[0]);
            List<string> output = new List<string>();
            for (int i = 0; i < noOfCases; i++)
            {
                TestCase c = new TestCase();
                c.firstNumber = int.Parse(lines[i * 10 + 1]);
                c.firstCase[0] = lines[i * 10 + 2].Split(' ').Select(p => int.Parse(p)).ToArray();
                c.firstCase[1] = lines[i * 10 + 3].Split(' ').Select(p => int.Parse(p)).ToArray();
                c.firstCase[2] = lines[i * 10 + 4].Split(' ').Select(p => int.Parse(p)).ToArray();
                c.firstCase[3] = lines[i * 10 + 5].Split(' ').Select(p => int.Parse(p)).ToArray();
                c.secondNumber = int.Parse(lines[(i * 10) + 6]);
                c.secondCase[0] = lines[i * 10 + 7].Split(' ').Select(p => int.Parse(p)).ToArray();
                c.secondCase[1] = lines[i * 10 + 8].Split(' ').Select(p => int.Parse(p)).ToArray();
                c.secondCase[2] = lines[i * 10 + 9].Split(' ').Select(p => int.Parse(p)).ToArray();
                c.secondCase[3] = lines[i * 10 + 10].Split(' ').Select(p => int.Parse(p)).ToArray();
                output.Add(String.Format("Case #{0}: {1}", i + 1, c.Test()));
            }
            File.WriteAllLines("SmallOutput.txt", output);
        }
    }
}
