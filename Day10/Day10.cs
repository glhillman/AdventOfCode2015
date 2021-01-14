using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10
{
    class Day10
    {

        public Day10()
        {
        }

        public void Part1()
        {
            string digits = "1113122113";

            for (int i = 0; i < 40; i++)
            {
                digits = LookAndSee(digits);
            }

            long rslt = digits.Length;

            Console.WriteLine("Part1: {0}", rslt);
        }

        public void Part2()
        {

            string digits = "1113122113";

            for (int i = 0; i < 50; i++)
            {
                digits = LookAndSee(digits);
            }

            long rslt = digits.Length;

            Console.WriteLine("Part2: {0}", rslt);
        }

        private string LookAndSee(string digits)
        {
            StringBuilder sb = new StringBuilder();

            int i = 0;
            while (i < digits.Length)
            {
                char currDigit = digits[i];
                int digitCount = 1;
                while (i + 1 < digits.Length && digits[i+1] == currDigit)
                {
                    i++;
                    digitCount++;
                }
                sb.Append(digitCount.ToString());
                sb.Append(currDigit);
                i++;
            }

            return sb.ToString();
        }
    }
}
