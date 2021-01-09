using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02
{
    public class Day02
    {
        private List<Box> _boxes;

        public Day02()
        {
            _boxes = new List<Box>();
            LoadData();
        }

        public void Part1AndPart2()
        {
            int paper = 0;
            int ribbon = 0;

            foreach (Box box in _boxes)
            {
                paper += box.AreaPlusSlack();
                ribbon += box.TotalRibbon();
            }

            Console.WriteLine("Part1: {0}", paper);
            Console.WriteLine("Part1: {0}", ribbon);
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
                    string[] sides = line.Split('x');
                    _boxes.Add(new Box(int.Parse(sides[0]), int.Parse(sides[1]), int.Parse(sides[2])));
                }

                file.Close();
            }
        }

    }
}
