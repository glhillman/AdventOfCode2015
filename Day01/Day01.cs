using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01
{
    public class Day01
    {
        private string _data;

        public Day01()
        {
            LoadData();
        }

        public void Part1()
        {
            int openCount = _data.Count(c => c == '(');
            int closeCount = _data.Count(c => c == ')');

            long rslt = openCount - closeCount;

            Console.WriteLine("Part1: {0}", rslt);
        }

        public void Part2()
        {
            int rslt = 0;

            int floor = 1;
            for (int i = 0; i < _data.Length; i++)
            {
                if (_data[i] == '(')
                {
                    floor++;
                }
                else
                {
                    floor--;
                }
                if (floor == 0)
                {
                    rslt = i + 1;
                    break;
                }
            }

            Console.WriteLine("Part2: {0}", rslt);
        }

        private void LoadData()
        {
            string inputFile = AppDomain.CurrentDomain.BaseDirectory + @"..\..\input.txt";

            if (File.Exists(inputFile))
            {
                StreamReader file = new StreamReader(inputFile);
                _data = file.ReadLine();

                file.Close();
            }
        }

    }
}
