using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14
{
    public class Day14
    {
        List<Deer> _deer = new List<Deer>();
        public Day14()
        {
            LoadData();
        }

        public void Part1()
        {
            int maxDistance = int.MinValue;

            foreach (Deer deer in _deer)
            {
                maxDistance = Math.Max(deer.RunFor(2503), maxDistance);
            }

            Console.WriteLine("Part1: {0}", maxDistance);
        }

        public void Part2()
        {
            for (int i = 0; i < _deer.Count; i++)
            {
                _deer[i].Reset();
            }

            for (int i = 0; i < 2503; i++)
            {
                int leadDist = int.MinValue;
                for (int j = 0; j < _deer.Count; j++)
                {
                    int dist = _deer[j].Step();
                    if (dist > leadDist)
                    {
                        leadDist = dist;
                    }
                }
                foreach (Deer deer in _deer)
                {
                    if (deer.Distance == leadDist)
                    {
                        deer.AddPoint();
                    }
                }
            }

            int maxPoints = _deer.Max(d => d.Points);

            Console.WriteLine("Part2: {0}", maxPoints);
        }

        private void LoadData()
        {
            string inputFile = AppDomain.CurrentDomain.BaseDirectory + @"..\..\input.txt";

            if (File.Exists(inputFile))
            {
                string line;
                StreamReader file = new StreamReader(inputFile);
                while ((line = file.ReadLine()) != null)
                {
                    string[] tokens = line.Split(' ');
                    _deer.Add(new Deer(tokens[0], int.Parse(tokens[3]), int.Parse(tokens[6]), int.Parse(tokens[13])));
                }

                file.Close();
            }
        }

    }
}
