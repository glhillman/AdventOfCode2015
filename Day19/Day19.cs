using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day19
{
    class Day19
    {
        List<Tuple<string, string>> _transitions = new List<Tuple<string, string>>();
        string _medicine;
        public Day19()
        {
            LoadData();
        }

        public void Part1()
        {
            HashSet<string> variations = new HashSet<string>();
            List<int> offsets = new List<int>();
            foreach (Tuple<string, string> tuple in _transitions)
            {
                int index = _medicine.IndexOf(tuple.Item1);
                while (index >= 0)
                {
                    offsets.Add(index);
                    index = _medicine.IndexOf(tuple.Item1, index + 1);
                }
                foreach (int offset in offsets)
                {
                    string pre = _medicine.Substring(0, offset);
                    string post = _medicine.Substring(offset + tuple.Item1.Length);
                    variations.Add(pre + tuple.Item2 + post);
                }
                offsets.Clear();               
            }
            long rslt = variations.Count();

            Console.WriteLine("Part1: {0}", rslt);
        }

        public void Part2()
        {
            // attempt a backwards approach - try substituting right-hand values with left-hand values (tuple.Item2 replaced with tuple.Item1)
            int replacements = 0;
            string target = _medicine;
            while (target != "e")
            {
                foreach (Tuple<string, string> tuple in _transitions)
                {
                    int offset = target.IndexOf(tuple.Item2);
                    if (offset >= 0)
                    {
                        string pre = target.Substring(0, offset);
                        string post = target.Substring(offset + tuple.Item2.Length);
                        target = pre + tuple.Item1 + post;
                        replacements++;
                    }
                }
            }

            Console.WriteLine("Part2: {0}", replacements);
        }

        private void LoadData()
        {
            string inputFile = AppDomain.CurrentDomain.BaseDirectory + @"..\..\input.txt";

            if (File.Exists(inputFile))
            {
                string line;
                StreamReader file = new StreamReader(inputFile);
                line = file.ReadLine();
                while (line.Length > 0)
                {
                    line = line.Replace(" => ", ":");
                    string[] tokens = line.Split(':');
                    _transitions.Add(new Tuple<string, string>(tokens[0], tokens[1]));
                    line = file.ReadLine();
                }
                _medicine = file.ReadLine();

                file.Close();
            }
        }

    }
}
