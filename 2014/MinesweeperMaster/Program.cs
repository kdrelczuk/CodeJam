using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperMaster
{
    class Program
    {
        class Board
        {
            enum BoardCell { Empty, Mine, Number, Zero };
            public int X, Y, M;
            BoardCell[,] cells;

            public void Print(TextWriter output, int no)
            {
                bool res = Init();
                output.WriteLine(String.Format("Case #{0}:", no));
                if (!eachNumberHasAccessToZeros())
                {
                    res = false;
                }
                bool ovverideCharNumber = false; ;
                if (X * Y - 1 == M)
                {
                    res = true;
                    ovverideCharNumber = true;
                }
                if (M == 0)
                {
                    res = true;
                    cells[0, 0] = BoardCell.Zero;
                }
                if (!res)
                {
                    output.WriteLine("Impossible");
                }
                //else
                {
                    bool startMarked = false;
                    for (int y = 0; y < Y; y++)
                    {
                        for (int x = 0; x < X; x++)
                        {

                            char c = '?';
                            switch (cells[x, y])
                            {
                                case BoardCell.Mine: c = '*'; break;
                                case BoardCell.Number:
                                    {
                                        if (ovverideCharNumber)
                                        {
                                            c = 'c';
                                        }
                                        else
                                        {
                                            c = 'N';

                                        } break;
                                    }
                                case BoardCell.Zero:
                                    {
                                        if (!startMarked)
                                        {
                                            c = 'c';
                                            startMarked = true;
                                        }
                                        else { c = '0'; }
                                        break;

                                    }
                                case BoardCell.Empty: c = '.'; break;
                            }
                            output.Write(c);
                        }
                        output.WriteLine();
                    }
                }
            }

            private bool eachNumberHasAccessToZeros()
            {
                for (int x = 0; x < X; x++)
                {
                    for (int y = 0; y < Y; y++)
                    {
                        if (cells[x, y] == BoardCell.Number)
                        {
                            if (!hasZeros(cells, x, y, X, Y))
                            {
                                return false;
                            }
                        }
                    }
                }
                return true;
            }

            private bool hasZeros(BoardCell[,] cells, int cx, int cy, int X, int Y)
            {
                if ((cx - 1 >= 0) && (cy - 1 >= 0))
                {
                    if (cells[cx - 1, cy - 1] == BoardCell.Zero)
                    {
                        return true;
                    }
                }
                if (cy - 1 >= 0)
                {
                    if (cells[cx, cy - 1] == BoardCell.Zero)
                    {
                        return true;
                    }
                }
                if ((cx + 1 < X) && (cy - 1 >= 0))
                {
                    if (cells[cx + 1, cy - 1] == BoardCell.Zero)
                    {
                        return true;
                    }
                }
                if (cx - 1 >= 0)
                {
                    if (cells[cx - 1, cy] == BoardCell.Zero)
                    {
                        return true;
                    }
                }
                if (cx + 1 < X)
                {
                    if (cells[cx + 1, cy] == BoardCell.Zero)
                    {
                        return true;
                    }
                }
                if ((cx - 1 >= 0) && (cy + 1 < Y))
                {
                    if (cells[cx - 1, cy + 1] == BoardCell.Zero)
                    {
                        return true;
                    }
                }
                if (cy + 1 < Y)
                {
                    if (cells[cx, cy + 1] == BoardCell.Zero)
                    {
                        return true;
                    }
                }
                if ((cx + 1 > X) && (cy + 1 > Y))
                {
                    if (cells[cx + 1, cy + 1] == BoardCell.Zero)
                    {
                        return true;
                    }
                }
                return false;
            }

            enum Dir { Righ, Down, Left, Up };
            private bool Init()
            {
                bool result = false;
                cells = new BoardCell[X, Y];
                Dir dir = Dir.Righ;
                int cx = 0, cy = 0;
                int ndx = 0;
                cells[cx, cy] = BoardCell.Mine;
                int mineLeft = M - 1;
                while (ndx != X * Y - 1)
                {
                    if (canGo(dir, cx, cy, X, Y))
                    {
                        if (go(dir, ref cx, ref cy, X, Y, ref mineLeft))
                        {
                            result = true;
                        }
                        ndx++;
                    }
                    else
                    {
                        dir = changeDir(dir);
                    }

                }
                return result;
            }

            private bool go(Dir dir, ref int cx, ref int cy, int X, int Y, ref int mineLeft)
            {
                switch (dir)
                {
                    case Dir.Righ: { cx++; break; }
                    case Dir.Down: { cy++; break; }
                    case Dir.Left: { cx--; break; }
                    case Dir.Up: { cy--; break; }
                }
                if (mineLeft > 0)
                {
                    cells[cx, cy] = BoardCell.Mine;
                    mineLeft--;
                }
                else
                {
                    if (isNumber(cells, cx, cy, X, Y))
                    {
                        cells[cx, cy] = BoardCell.Number;
                    }
                    else
                    {
                        cells[cx, cy] = BoardCell.Zero;
                        return true;
                    }
                }
                return false;
            }


            private Dir changeDir(Dir dir)
            {
                switch (dir)
                {
                    case Dir.Righ: return Dir.Down;
                    case Dir.Down: return Dir.Left;
                    case Dir.Left: return Dir.Up;
                    case Dir.Up: return Dir.Righ;
                }
                return Dir.Righ;
            }

            private bool canGo(Dir dir, int cx, int cy, int X, int Y)
            {
                switch (dir)
                {
                    case Dir.Righ:
                        {
                            if ((cx + 1 < X) && (cells[cx + 1, cy] == BoardCell.Empty))
                            {
                                return true;
                            }
                            else return false;
                        }
                    case Dir.Down:
                        {
                            if ((cy + 1 < Y) && (cells[cx, cy + 1] == BoardCell.Empty))
                            {
                                return true;
                            }
                            else return false;
                        }
                    case Dir.Left:
                        {
                            if ((cx - 1 >= 0) && (cells[cx - 1, cy] == BoardCell.Empty))
                            {
                                return true;
                            }
                            else return false;
                        }
                    case Dir.Up:
                        {
                            if (cells[cx, cy - 1] == BoardCell.Empty)
                            {
                                return true;
                            }
                            else return false;
                        }
                }
                return false;
            }

            private bool isNumber(BoardCell[,] cells, int cx, int cy, int X, int Y)
            {

                if ((cx - 1 >= 0) && (cy - 1 >= 0))
                {
                    if (cells[cx - 1, cy - 1] == BoardCell.Mine)
                    {
                        return true;
                    }
                }
                if (cy - 1 >= 0)
                {
                    if (cells[cx, cy - 1] == BoardCell.Mine)
                    {
                        return true;
                    }
                }
                if ((cx + 1 < X) && (cy - 1 >= 0))
                {
                    if (cells[cx + 1, cy - 1] == BoardCell.Mine)
                    {
                        return true;
                    }
                }
                if (cx - 1 >= 0)
                {
                    if (cells[cx - 1, cy] == BoardCell.Mine)
                    {
                        return true;
                    }
                }
                if (cx + 1 < X)
                {
                    if (cells[cx + 1, cy] == BoardCell.Mine)
                    {
                        return true;
                    }
                }
                if ((cx - 1 >= 0) && (cy + 1 < Y))
                {
                    if (cells[cx - 1, cy + 1] == BoardCell.Mine)
                    {
                        return true;
                    }
                }
                if (cy + 1 < Y)
                {
                    if (cells[cx, cy + 1] == BoardCell.Mine)
                    {
                        return true;
                    }
                }
                if ((cx + 1 > X) && (cy + 1 > Y))
                {
                    if (cells[cx + 1, cy + 1] == BoardCell.Mine)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("C-small-attempt3.in");
            int noOfCases = int.Parse(lines[0]);
            using (StreamWriter writer = File.CreateText("OutputOK3.txt"))
            {
                for (int i = 0; i < noOfCases; i++)
                {
                    var vals = lines[i + 1].Split(' ').Select(s => int.Parse(s)).ToArray();
                    Board b = new Board() { Y = vals[0], X = vals[1], M = vals[2] };
                    b.Print(writer, i + 1);
                    //b.Print(Console.Out, i + 1);
                }
            }
            //Console.ReadKey();
        }
    }
}
