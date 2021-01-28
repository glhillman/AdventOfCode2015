using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day25
{
    class Day25
    {
        int targetRow = 2978;
        int targetCol = 3083;

        public Day25()
        {
        }

        public void Part1()
        {
            long value = 20151125;
            int anchorRow = 2;
            int col = 1;
            int row = anchorRow;
            while (true)
            {
                value = (value * 252533) % 33554393;
                if (row == targetRow && col == targetCol)
                {
                    break;
                }
                if (row > 1)
                {
                    col++;
                    row--;
                }
                else
                { 
                    row = ++anchorRow;
                    col = 1;
                }
            }

            Console.WriteLine("Part1: {0}", value);
        }
    }
}
