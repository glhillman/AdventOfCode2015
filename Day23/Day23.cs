using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day23
{
    public class Day23
    {
        List<string> _instructions = new List<string>();
        uint[] _ab = { 0, 0 };

        public Day23()
        {
            LoadData();
        }

        public void Part1()
        {
            Execute();

            Console.WriteLine("Part1: {0}", _ab[1]);
        }

        public void Part2()
        {
            _ab[0] = 1;
            _ab[1] = 0;

            Execute();

            Console.WriteLine("Part2: {0}", _ab[1]);
        }

        private void Execute()
        {
            int instructionPtr = 0;

            while (instructionPtr >= 0 && instructionPtr < _instructions.Count)
            {
                string[] tokens = _instructions[instructionPtr].Split(' ');
                switch (tokens[0])
                {
                    case "hlf":
                        _ab[tokens[1][0] - 'a'] /= 2;
                        instructionPtr++;
                        break;
                    case "tpl":
                        _ab[tokens[1][0] - 'a'] *= 3;
                        instructionPtr++;
                        break;
                    case "inc":
                        _ab[tokens[1][0] - 'a'] += 1;
                        instructionPtr++;
                        break;
                    case "jmp":
                        instructionPtr += int.Parse(tokens[1]);
                        break;
                    case "jie":
                        if (_ab[tokens[1][0] - 'a'] % 2 == 0)
                        {
                            instructionPtr += int.Parse(tokens[2]);
                        }
                        else
                        {
                            instructionPtr++;
                        }
                        break;
                    case "jio":
                        if (_ab[tokens[1][0] - 'a'] == 1)
                        {
                            instructionPtr += int.Parse(tokens[2]);
                        }
                        else
                        {
                            instructionPtr++;
                        }
                        break;
                }
            }
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
                    _instructions.Add(line);
                }

                file.Close();
            }
        }

    }
}
