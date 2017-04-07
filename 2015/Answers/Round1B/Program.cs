using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Round1B.CounterCulture
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("A-small-attempt4.in");

            //string[] lines = File.ReadAllLines("A-large.in");

            //string[] lines = File.ReadAllLines("very-small.in");

            int noOfCases = int.Parse(lines[0]);
            List<string> output = new List<string>();

            for (int i = 1; i <= noOfCases; i++)
            {
                var token = int.Parse(lines[i]);
                var rounds = GetRpunds(token);
                string print = String.Format("Case #{0}: {1}", i, rounds);
                output.Add(print);
                Console.WriteLine(print);
            }
            File.WriteAllLines("output4.out", output);
            Console.WriteLine("Done.");
            Console.ReadKey();
        }

        private static long GetRpunds(long num)
        {
            long result = 0;
            while (num != 0)
            {
                if (num <= 20)
                {
                    result += num;
                    return result;
                }
                long x = DownToOne(ref num);
                result += x;
                long y = FlipOrLower(ref num);
                result += y;
            }
            return -1;
        }

        private static long FlipOrLower(ref long num)
        {
            var arr = num.ToString().ToCharArray();
            if (arr[0] != '1')
            {
                num = long.Parse(new String(arr.Reverse().ToArray()));
                return 1;
            }
            else
            {
                long scale = IntPower(10, (short)(arr.Length - 1));
                long res = num - scale + 1;
                num = scale - 1;
                return res;
            }

        }

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

        private static long DownToOne(ref long num)
        {
            var arr = num.ToString().ToCharArray();
            int lastVal = int.Parse(new String(new Char[] { arr[arr.Length - 1] }));
            if (lastVal == 0)
            {
                num -= 9;
                return 9;
            }
            else
            {
                num -= (lastVal - 1);
                return lastVal - 1;
            }
        }

    }
}
