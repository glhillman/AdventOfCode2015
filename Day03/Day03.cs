using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day03
{
    public class Day03
    {
        private string _moves;
        public Day03()
        {
            LoadData();
        }

        public void Part1()
        {
            int xx = 0;
            int yy = 0;

            HashSet<(int x, int y)> locations = new HashSet<(int x, int y)>();

            foreach (char c in _moves)
            {
                AdjustXY(c, ref xx, ref yy);
                locations.Add((xx, yy));
            }

            Console.WriteLine("Part1: {0}", locations.Count());
        }

        public void Part2()
        {
            int santaX = 0;
            int santaY = 0;
            int roboX = 0;
            int roboY = 0;
            bool santasTurn = true;

            HashSet<(int x, int y)> santaLocations = new HashSet<(int x, int y)>();
            HashSet<(int x, int y)> roboLocations = new HashSet<(int x, int y)>();

            foreach (char c in _moves)
            {
                if (santasTurn)
                {
                    AdjustXY(c, ref santaX, ref santaY);
                    santaLocations.Add((santaX, santaY));
                }
                else
                {
                    AdjustXY(c, ref roboX, ref roboY);
                    roboLocations.Add((roboX, roboY));
                }
                santasTurn = santasTurn ? false : true;
            }

            santaLocations.UnionWith(roboLocations);

            int visited = santaLocations.Count();

            Console.WriteLine("Part1: {0}", visited);
        }

        public void AdjustXY(char direction, ref int x, ref int y)
        {
            switch (direction)
            {
                case '<':
                    x--;
                    break;
                case '>':
                    x++;
                    break;
                case '^':
                    y--;
                    break;
                case 'v':
                    y++;
                    break;
            }
        }

        private void LoadData()
        {
            string inputFile = AppDomain.CurrentDomain.BaseDirectory + @"..\..\input.txt";

            if (File.Exists(inputFile))
            {
                StreamReader file = new StreamReader(inputFile);

                _moves = file.ReadLine();

                file.Close();
            }
        }

    }
}
