using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05
{
    public class Day05
    {
        private List<string> _strings;


        public Day05()
        {
            _strings = new List<string>();
            
            LoadData();
        }

        public void Part1()
        {
            int niceCount = 0;

            foreach (string s in _strings)
            {
                niceCount += IsNice1(s) ? 1 : 0;
            }

            Console.WriteLine("Part1: {0}", niceCount);
        }

        public void Part2()
        {
            int niceCount = 0;

            foreach (string s in _strings)
            {
                niceCount += IsNice2(s) ? 1 : 0;
            }

            Console.WriteLine("Part1: {0}", niceCount);
        }

        private bool IsNice1(string s)
        {
            bool isNice = true; // assume until proven otherwise

            // can't contain the following
            if (s.Contains("ab") || s.Contains("cd") || s.Contains("pq") || s.Contains("xy"))
            {
                isNice = false;
            }

            // at least three vowels
            if (isNice)
            {
                char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
                byte[] letters = new byte[26];
                for (int i = 0; i < s.Length; i++)
                {
                    letters[s[i] - 'a']++; 
                }

                int vowelCount = 0;
                for (int i = 0; i < vowels.Length; i++)
                {
                    vowelCount += letters[vowels[i] - 'a'];
                }

                isNice = vowelCount >= 3;
            }

            if (isNice)
            {
                isNice = false;
                for (int i = 0; i < s.Length-1; i++)
                {
                    if (s[i] == s[i+1])
                    {
                        isNice = true;
                        break;
                    }
                }
            }

            return isNice;
        }

        private bool IsNice2(string s)
        {
            bool isNice = false;

            // pair appearing twice
            for (int i = 0; i < s.Length-2; i++)
            {
                string pair = s.Substring(i, 2);
                int index = s.IndexOf(pair, i + 2);
                if (index > 0)
                {
                    isNice = true;
                    break;
                }
            }
            
            // letter repeating with one in between
            if (isNice)
            {
                isNice = false;

                for (int i = 0; i < s.Length-2; i++)
                {
                    if (s[i] == s[i+2] && s[i] != s[i+1])
                    {
                        isNice = true;
                        break;
                    }
                }
            }

            return isNice;
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
                    _strings.Add(line);
                }

                file.Close();
            }
        }

    }
}
