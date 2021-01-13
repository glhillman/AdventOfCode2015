using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08
{
    public class Day08
    {
        List<string> _strings;

        public Day08()
        {
            LoadData();
        }

        public void Part1()
        {
            int fullLength = 0;
            int actualLength = 0;

            foreach (string s in _strings)
            {
                fullLength += s.Length;
                actualLength += ActualLength(s);
            }

            int rslt = fullLength - actualLength;

            Console.WriteLine("Part1: {0}", rslt);
        }

        public void Part2()
        {
            int fullLength = 0;
            int expandedLength = 0;

            foreach (string s in _strings)
            {
                fullLength += s.Length;
                expandedLength += ExpandedLength(s);
            }

            int rslt = expandedLength - fullLength;

            Console.WriteLine("Part2: {0}", rslt);
        }

        private int ActualLength(string s)
        {
            int length = 0;
            int i = 1; // skip leading quote
            int sLength = s.Length;

            while (i < sLength)
            {
                if (s[i] == '\\')
                {
                    if (i < sLength - 3 && s[i + 1] == 'x')
                    {
                        length++;
                        i += 4;
                    }
                    else if (i < sLength - 1 && (s[i + 1] == '\\' || s[i + 1] == '"'))
                    {
                        length++;
                        i += 2;
                    }
                }
                else
                {
                    length++;
                    i++;
                }
            }

            length--; // for trailing quote

            return length;
        }
        private int ExpandedLength(string s)
        {
            int length = 3; // quote + \" for opening quote
            int i = 1; // skip leading quote
            int sLength = s.Length;

            while (i < sLength)
            {
                switch (s[i])
                {
                    case '\\':
                        length += 2;
                        break;
                    case '"':
                        length += 2;
                        break;
                    default:
                        length += 1;
                        break;
                }
                i++;
            }

            length++; // for trailing quote

            return length;
        }


        private void LoadData()
        {
            string inputFile = AppDomain.CurrentDomain.BaseDirectory + @"..\..\input.txt";

            if (File.Exists(inputFile))
            {
                _strings = new List<string>();
                string line;
                StreamReader file = new StreamReader(inputFile);
                while ((line = file.ReadLine()) != null)
                {
                    _strings.Add(line);
                }

                file.Close();
            }
        }

    }
}
