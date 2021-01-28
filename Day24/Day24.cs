using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day24
{
    public class Day24
    {
        List<ulong> _input;
        List<List<ulong>> _combos3 = new List<List<ulong>>();
        List<List<ulong>> _combos4 = new List<List<ulong>>();
        static ulong _thirdValue;
        static ulong _fourthValue;
        public Day24()
        {
            LoadData();
            _thirdValue = _input.Aggregate((a,b) => a + b) / 3;
            _fourthValue = _input.Aggregate((a,b) =>a + b) / 4;

            GetAllCombos(_input, _combos3, _combos4);
            _combos3.Sort((a, b) => a.Count - b.Count);
            _combos4.Sort((a, b) => a.Count - b.Count);
        }

        public void Part1()
        {
            List<ulong> qa = new List<ulong>();
            foreach (List<ulong> group in _combos3)
            {
                ulong prod = group.Aggregate((a, b) => a * b);
                qa.Add(prod);
            }
            List<ulong> qaRslt = new List<ulong>();
            ulong minPackageCount = (ulong)_combos3[0].Count;
            qaRslt.Add(qa[0]);
            int i = 1;
            while ((ulong)_combos3[i].Count == minPackageCount)
            {
                qaRslt.Add(qa[i++]);
            }
            qaRslt.Sort();

            Console.WriteLine("Part1: {0}", qaRslt[0]); // minimum entaglement of set of minimum # packages
        }

        public void Part2()
        {
            List<ulong> qa = new List<ulong>();
            foreach (List<ulong> group in _combos4)
            {
                ulong prod = group.Aggregate((a, b) => a * b);
                qa.Add(prod);
            }
            List<ulong> qaRslt = new List<ulong>();
            ulong minPackageCount = (ulong)_combos4[0].Count;
            int i = 1;
            while ((ulong)_combos4[i].Count == minPackageCount)
            {
                qaRslt.Add(qa[i++]);
            }
            qaRslt.Sort();

            Console.WriteLine("Part1: {0}", qaRslt[0]); // minimum entaglement of set of minimum # packages
        }

        public static void GetAllCombos(List<ulong> list, List<List<ulong>> combo3, List<List<ulong>> combo4)
        {
            int comboCount = (int)Math.Pow(2, list.Count) - 1;
            for (int i = 1; i < comboCount + 1; i++)
            {
                List<ulong> temp = new List<ulong>();
                // make each combo here
                for (int j = 0; j < list.Count; j++)
                {
                    if ((i >> j) % 2 != 0)
                        temp.Add(list[j]);
                }
                ulong sum = temp.Aggregate((a, b) => a + b);
                if (sum == _thirdValue)
                {
                    combo3.Add(temp);
                }
                else if (sum == _fourthValue)
                {
                    combo4.Add(temp);
                }
            }
        }


        private void LoadData()
        {
            string inputFile = AppDomain.CurrentDomain.BaseDirectory + @"..\..\input.txt";

            if (File.Exists(inputFile))
            {
                _input = new List<ulong>();
                string line;
                StreamReader file = new StreamReader(inputFile);
                while ((line = file.ReadLine()) != null)
                {
                    _input.Add(ulong.Parse(line));
                }

                file.Close();
            }
        }

    }
}
