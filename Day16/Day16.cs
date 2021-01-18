using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day16
{
    public class Day16
    {
        private List<Aunt> _aunts = new List<Aunt>();
        Dictionary<string, int> _attributes = new Dictionary<string, int>();

        public Day16()
        {
            LoadData();

            _attributes["children"] = 3;
            _attributes["cats"] = 7;
            _attributes["samoyeds"] = 2;
            _attributes["pomeranians"] = 3;
            _attributes["akitas"] = 0;
            _attributes["vizslas"] = 0;
            _attributes["goldfish"] = 5;
            _attributes["trees"] = 3;
            _attributes["cars"] = 2;
            _attributes["perfumes"] = 1;
        }

        public void Part1()
        {

            List<Aunt> candidates = new List<Aunt>();

            foreach (Aunt aunt in _aunts)
            {
                bool validSoFar = true; // hope for the best
                foreach (string key in _attributes.Keys)
                {
                    if (aunt.Attributes.ContainsKey(key))
                    {
                        validSoFar = aunt.Attributes[key] == _attributes[key];
                    }
                    if (validSoFar == false)
                    {
                        break;
                    }
                }
                if (validSoFar)
                {
                    candidates.Add(aunt);
                }
            }


            Console.WriteLine("Part1: {0}", candidates[0].AuntNum);
        }

        public void Part2()
        {
            List<Aunt> candidates = new List<Aunt>();

            foreach (Aunt aunt in _aunts)
            {
                bool validSoFar = true; // hope for the best
                foreach (string key in _attributes.Keys)
                {
                    if (aunt.Attributes.ContainsKey(key))
                    {
                        if (key == "cats" || key == "trees")
                        {
                            validSoFar = aunt.Attributes[key] > _attributes[key];
                        }
                        else if (key == "pomeranians" || key == "goldfish")
                        {
                            validSoFar = aunt.Attributes[key] < _attributes[key];
                        }
                        else
                        {
                            validSoFar = aunt.Attributes[key] == _attributes[key];
                        }
                    }
                    if (validSoFar == false)
                    {
                        break;
                    }
                }
                if (validSoFar)
                {
                    candidates.Add(aunt);
                }
            }


            Console.WriteLine("Part2: {0}", candidates[0].AuntNum);
        }

        private void LoadData()
        {
            string inputFile = AppDomain.CurrentDomain.BaseDirectory + @"..\..\input.txt";

            if (File.Exists(inputFile))
            {
                string line;
                StreamReader file = new StreamReader(inputFile);
                string[] nameArray = { "children", "cats", "samoyeds", "pomeranians", "akitas", "vizslas", "goldfish", "trees", "cars", "perfumes" };
                List<string> names = new List<string>(nameArray);
                List<int> values = new List<int>(new int[10]);
                while ((line = file.ReadLine()) != null)
                {
                    line = line.Replace(' ', ':').Replace(',', ':');
                    string[] tokens = line.Split(':');
                    Aunt aunt = new Aunt(int.Parse(tokens[1]));
                    int token = 3;
                    while (token <= 13)
                    {
                        aunt.Attributes[tokens[token]] = int.Parse(tokens[token + 2]);
                        token += 4;
                    }
                    _aunts.Add(aunt);
                }

                file.Close();
            }
        }

    }
}
