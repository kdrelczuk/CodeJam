using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieClicker
{
    class Program
    {
        class Game
        {
            public decimal c // price of a farm
                , f // cokies per farm
                , x; //goal

            private decimal status;

            public decimal Go()
            {
                decimal time = 0;
                decimal income = 2;
                decimal status = 0;

                while (status < x)
                {
                    decimal time_c = (c / income);
                    decimal time_to_goal = (x / income);
                    if (time_c + (x / (income + f)) > time_to_goal)
                    {
                        return (time + time_to_goal);
                    }
                    time += time_c;
                    status += (time_c * income);
                    income += f;
                    status -= c;
                }
                return time;
            }
        }

        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("B-large.in");
            int noOfCases = int.Parse(lines[0]);
            List<string> output = new List<string>();
            for (int i = 1; i <= noOfCases; i++)
            {
                var tokens = lines[i].Split(' ');
                Game g = new Game() { c = decimal.Parse(tokens[0], CultureInfo.InvariantCulture), f = decimal.Parse(tokens[1], CultureInfo.InvariantCulture), x = decimal.Parse(tokens[2], CultureInfo.InvariantCulture) };
                output.Add(String.Format("Case #{0}: {1}",i,Math.Round(g.Go(),7).ToString(CultureInfo.InvariantCulture)));
            }
            File.WriteAllLines("OutputBig.txt", output);
        }
    }
}
