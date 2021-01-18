using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day18
{
    class Day18
    {
        char[,] _grid1;
        public Day18()
        {
        }

        public void Part1()
        {
            LoadData(false);
            int size = _grid1.GetLength(0);
            char[,] grid2 = new char[size, size];
            bool mainIsOne = true;


            for (int i = 1; i <= 100; i++)
            {
                if (mainIsOne)
                {
                    Step(_grid1, grid2, false);
                }
                else
                {
                    Step(grid2, _grid1, false);
                }
                mainIsOne = !mainIsOne;
            }

            
            long rslt = CountLights(mainIsOne ? _grid1 : grid2);

            Console.WriteLine("Part1: {0}", rslt);
        }

        public void Part2()
        {
            _grid1 = null;
            LoadData(true);
            int size = _grid1.GetLength(0);
            char[,] grid2 = new char[size, size];
            bool mainIsOne = true;

            for (int i = 1; i <= 100; i++)
            {
                if (mainIsOne)
                {
                    Step(_grid1, grid2, true);
                }
                else
                {
                    Step(grid2, _grid1, true);
                }
                mainIsOne = !mainIsOne;
            }


            long rslt = CountLights(mainIsOne ? _grid1 : grid2);

            Console.WriteLine("Part2: {0}", rslt);
        }

        private void Step(char[,] src, char[,] dst, bool forceCornersOn)
        {
            int size = src.GetLength(0);

            int neighborCount = 0;

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    neighborCount = 0;

                    for (int yy = y-1; yy < y+2; yy++)
                    {
                        for (int xx = x-1; xx < x+2; xx++)
                        {
                            if (xx >= 0 && xx < size && yy >= 0 && yy < size)
                            {
                                if (!(xx == x && yy == y))
                                {
                                    neighborCount += src[xx, yy] == '#' ? 1 : 0;
                                }
                            }
                        }
                    }
                    if (src[x, y] == '#')
                    {
                        if (neighborCount == 2 || neighborCount == 3)
                        {
                            dst[x, y] = '#';
                        }
                        else
                        {
                            dst[x, y] = '.';
                        }
                    }
                    else // src is '.'
                    {
                        if (neighborCount == 3)
                        {
                            dst[x, y] = '#';
                        }
                        else
                        {
                            dst[x, y] = '.';
                        }
                    }
                }
            }

            if (forceCornersOn)
            {
                dst[0, 0] = '#';
                dst[0, size - 1] = '#';
                dst[size - 1, 0] = '#';
                dst[size - 1, size - 1] = '#';
            }
        }

        private int CountLights(char[,] grid)
        {
            int count = 0;
            int size = grid.GetLength(0);
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    count += grid[x, y] == '#' ? 1 : 0;
                }
            }

            return count;
        }

        private void DumpGrid(string label, char[,] grid)
        {
            Console.WriteLine(label);
            int size = grid.GetLength(0);

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    Console.Write(grid[x, y]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private void LoadData(bool forceCornersOn)
        {
            string inputFile = AppDomain.CurrentDomain.BaseDirectory + @"..\..\input.txt";

            if (File.Exists(inputFile))
            {
                string line;
                StreamReader file = new StreamReader(inputFile);
                int y = 0;
                int size = 0;
                while ((line = file.ReadLine()) != null)
                {
                    if (_grid1 == null)
                    {
                        size = line.Length;
                        _grid1 = new char[size, size];
                    }
                    for (int x = 0; x < line.Length; x++)
                    {
                        _grid1[x, y] = line[x];
                    }
                    y++;
                }

                if (forceCornersOn)
                {
                    _grid1[0, 0] = '#';
                    _grid1[0, size - 1] = '#';
                    _grid1[size - 1, 0] = '#';
                    _grid1[size - 1, size - 1] = '#';
                }

                file.Close();
            }
        }

    }
}
