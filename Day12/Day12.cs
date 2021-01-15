using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12
{
    class Day12
    {
        string _rawString;

        public Day12()
        {
            LoadData();
        }

        public void Part1()
        {
            string[] tokens = _rawString.Replace("{", ",").Replace("}", ",").Replace(":", ",").Replace("[", ",").Replace("]", ",").Split(',');

            int rslt = 0;

            foreach (string token in tokens)
            {
                int value;
                if (int.TryParse(token, out value))
                {
                    rslt += value;
                }
            }

            Console.WriteLine("Part1: {0}", rslt);
        }

        public void Part2()
        {
            string workString = _rawString;
            int i = 0;
            while (i < workString.Length)
            {
                int ix = workString.IndexOf(":\"red\"", i);
                if (ix > 0)
                {
                    // this red is in an object
                    // find the surrounding curly brackets
                    i = ix - 1;
                    int closeCount = 1;
                    while (workString[--i] != '{' || closeCount > 0)
                    {
                        if (workString[i] == '}')
                        {
                            closeCount++;
                        }
                        else if (workString[i] == '{')
                        {
                            closeCount--;
                            if (closeCount == 0)
                            {
                                i++;
                            }
                        }
                    }
                    int endIndex = ix + 3;
                    int openCount = 1;
                    while (workString[++endIndex] != '}' || openCount > 0)
                    {
                        if (workString[endIndex] == '{')
                        {
                            openCount++;
                        }
                        else if (workString[endIndex] == '}')
                        {
                            openCount--;
                            if (openCount == 0)
                            {
                                endIndex--;
                            }
                        }
                    }
                    workString = workString.Remove(i, (endIndex - i) + 1);
                }
                else
                {
                    // no more red objects!
                    break;
                }
                i++;
            }

            string[] tokens = workString.Replace("{", ",").Replace("}", ",").Replace(":", ",").Replace("[", ",").Replace("]", ",").Split(',');

            int rslt = 0;

            foreach (string token in tokens)
            {
                int value;
                if (int.TryParse(token, out value))
                {
                    rslt += value;
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
                _rawString = file.ReadLine();

                file.Close();
            }
        }

    }
}
