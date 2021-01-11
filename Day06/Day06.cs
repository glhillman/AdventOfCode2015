using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day06
{

    public class Day06
    {
        private List<Instruction> _instructions;

        public Day06()
        {
            _instructions = new List<Instruction>();
            LoadData();
        }

        public void Part1()
        {
            int[,] lights = new int[1000, 1000];

            foreach (Instruction inst in _instructions)
            {
                for (int y = inst.StartY; y <= inst.EndY; y++)
                {
                    for (int x = inst.StartX; x <= inst.EndX; x++)
                    {
                        switch (inst.Inst)
                        {
                            case InstEnum.On:
                                lights[x, y] = 1;
                                break;
                            case InstEnum.Off:
                                lights[x, y] = 0;
                                break;
                            case InstEnum.Toggle:
                                lights[x, y] = lights[x, y] == 1 ? 0 : 1;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            int count = 0;
            for (int y = 0; y < 1000; y++)
            {
                for (int x = 0; x < 1000; x++)
                {
                    count += lights[x, y];
                }
            }

            Console.WriteLine("Part1: {0}", count);
        }

        public void Part2()
        {
            int[,] lights = new int[1000, 1000];

            foreach (Instruction inst in _instructions)
            {
                for (int y = inst.StartY; y <= inst.EndY; y++)
                {
                    for (int x = inst.StartX; x <= inst.EndX; x++)
                    {
                        switch (inst.Inst)
                        {
                            case InstEnum.On:
                                lights[x, y]++;
                                break;
                            case InstEnum.Off:
                                if (lights[x, y] > 0)
                                {
                                    lights[x, y]--;
                                }
                                break;
                            case InstEnum.Toggle:
                                lights[x, y] += 2;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            long count = 0;
            for (int y = 0; y < 1000; y++)
            {
                for (int x = 0; x < 1000; x++)
                {
                    count += lights[x, y];
                }
            }

            Console.WriteLine("Part2: {0}", count);
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
                    _instructions.Add(new Instruction(line));
                }

                file.Close();
            }
        }

    }
}
