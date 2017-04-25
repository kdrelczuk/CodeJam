using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace QRound.TideNumbers
{
    class Program
    {

        public static bool IfTidy(List<int> nums)
        {
            if (nums.Count == 1) return true;
            for (int i = 0; i < nums.Count - 1; i++)
            {
                if (nums[i] > nums[i + 1]) return false;
            }
            return true;
        }

        static List<int> FlipNumbers(List<int> nums, int gix)
        {
            int pval = nums[gix];
            if (pval == 9) return FlipNumbers(nums, gix - 1);
            nums[gix] = 9;
            if (pval != 0)
            {
                nums[gix - 1] = nums[gix - 1] - 1;
            }
            else
            {
                int ix = gix - 1;
                while (nums[ix] == 0)
                {
                    nums[ix] = 9;
                    ix--;
                }
                nums[ix] = nums[ix] - 1;
            }
            return nums;
        }

        public static List<int> FlipNumbers(List<int> nums)
        {
            return FlipNumbers(nums, nums.Count - 1);
        }

        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("B-large.in");
            int noOfCases = int.Parse(lines[0]);
            List<string> output = new List<string>();

            for (int i = 1; i <= noOfCases; i++)
            {
                List<int> numbers = lines[i].ToCharArray().Select(n => Int32.Parse(n.ToString())).ToList();

                while (!IfTidy((numbers)))
                {
                    numbers = FlipNumbers(numbers);
                }
                string o = new String(numbers.Select(n => n.ToString()[0]).ToArray());
                if (o[0] == '0') { o = o.Remove(0, 1); }
                Console.WriteLine(o);
                output.Add(String.Format("Case #{0}: {1}", i, o));
            }
            File.WriteAllLines("output_lg.out", output);
            Console.WriteLine("DONE");
        }
    }
}
