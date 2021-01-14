using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11
{
    class Day11
    {
        char[] _alphaDigits = { 'v', 'z', 'b', 'x', 'k', 'g', 'h', 'b' };

        public Day11()
        {
        }

        public void Part1()
        {
            bool valid = false;

            int len = _alphaDigits.Length;
            while (!valid)
            {
                Increment(_alphaDigits, len);
                valid = CheckValid(_alphaDigits, len);
            }

            string rslt = string.Join("", _alphaDigits);

            Console.WriteLine("Part1: {0}", rslt);
        }

        public void Part2()
        {
            bool valid = false;

            int len = _alphaDigits.Length;
            while (!valid)
            {
                Increment(_alphaDigits, len);
                valid = CheckValid(_alphaDigits, len);
            }

            string rslt = string.Join("", _alphaDigits);

            Console.WriteLine("Part2: {0}", rslt);
        }

        private void Increment(char[] alphaDigits, int len)
        {
            bool finished = false;
            int index = len - 1;

            while (!finished)
            {
                if (alphaDigits[index] < 'z')
                {
                    char c = ++alphaDigits[index];
                    if (c == 'i' || c == 'o' || c == 'l')
                    {
                        c++;
                    }
                    alphaDigits[index] = c;
                    
                    finished = true;
                }
                else
                {
                    alphaDigits[index] = 'a';
                    index--;
                }
            }
        }

        private bool CheckValid(char[] alphaDigits, int len)
        {
            bool okSoFar = false;

            // first check for a 3-sequence run
            for (int i = 0; i < len - 2; i++)
            {
                if (alphaDigits[i] == alphaDigits[i + 1] - 1 && alphaDigits[i] == alphaDigits[i + 2] - 2)
                {
                    okSoFar = true;
                    break;
                }
            }
            if (okSoFar)
            {
                // check for two pairs
                okSoFar = false;
                int index1 = 0;
                int index2 = 0;

                while (index1 < len - 2)
                {
                    if (alphaDigits[index1] == alphaDigits[index1+1])
                    {
                        index2 = index1 + 2;
                        break;
                    }
                    index1++;
                }
                if (index2 > 1)
                {
                    while (index2 < len-1)
                    {
                        if (alphaDigits[index2] == alphaDigits[index2 + 1])
                        {
                            okSoFar = true;
                            break;
                        }
                        index2++;
                    }
                }
            }

            return okSoFar;
        }
    }
}
