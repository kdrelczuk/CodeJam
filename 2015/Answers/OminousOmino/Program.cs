using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OminousOmino
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("D-small-attempt5.in");

            //string[] lines = File.ReadAllLines("A-large.in");

            //string[] lines = File.ReadAllLines("very-small.in");

            int noOfCases = int.Parse(lines[0]);
            List<string> output = new List<string>();

            string player1 = "RICHARD";
            string player2 = "GABRIEL";
            string winner = "?";
            for (int i = 1; i <= noOfCases; i++)
            {

                var tokens = lines[i].Split(' ').Select(s => int.Parse(s)).ToArray();
                int omni = tokens[0];
                int sizex = tokens[1];
                int sizey = tokens[2];
                int size = sizex * sizey;
                if (size <= omni)
                {
                    winner = player1;
                }
                else if (omni == 1)
                {
                    winner = player2;
                }
                else if ((size % 2 == 0) && (omni == 2))
                {
                    winner = player2;
                }
                else if (size % omni != 0)
                {
                    winner = player1;
                }
                else if ((sizey == 1 || sizex == 1) && omni >= 3)
                {
                    winner = player1;
                }
                else switch (omni)
                    {
                        case 3: winner = player2; break;
                        default:
                            {
                                if (size <= omni * 2) { winner = player1; }
                                else { winner = player2; }
                                break;
                            }
                    }

                string print = String.Format("Case #{0}: {1}", i, winner);
                output.Add(print);
                Console.WriteLine(print);
            }
            File.WriteAllLines("output.out", output);
            Console.WriteLine("Done.");
            Console.ReadKey();
        }
    }
}
