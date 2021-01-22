using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day20
{
    public class Day20
    {
        public void Part1()
        {
            int rslt = CalcHouseNumber1(33100000);

            Console.WriteLine("Part1: {0}", rslt);
        }

        public void Part2()
        {
            int rslt = CalcHouseNumber2(33100000);

            Console.WriteLine("Part2: {0}", rslt);
        }

        public int CalcHouseNumber1(int target)
        {
            int lastHouse = 0;

            int[] houses = new int[(target / 10) + 1];
            for (int elf = 1; elf < houses.Length; elf++)
            {
                for (int house = elf; house < houses.Length; house += elf)
                {
                    houses[house] += elf * 10;
                }
            }

            lastHouse = 1;
            while (houses[lastHouse] < target)
            {
                lastHouse++;
            }

            return lastHouse;
        }

        public int CalcHouseNumber2(int target)
        {
            int lastHouse = 0;

            int[] houses = new int[(target / 10) + 1];
            for (int elf = 1; elf < houses.Length; elf++)
            {
                for (int house = elf, maxHouse = 0; house < houses.Length && maxHouse < 50; house += elf, maxHouse++)
                {
                    houses[house] += elf * 11;
                }
            }

            lastHouse = 1;
            while (houses[lastHouse] < target)
            {
                lastHouse++;
            }

            return lastHouse;
        }
    }
}
