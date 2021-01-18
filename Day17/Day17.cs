using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day17
{
    public class Day17
    {
        private List<int> _containers = new List<int>();
        private List<List<int>> _combos;

        public Day17()
        {
            LoadData();
            _combos = GetAllCombos(_containers);
        }

        public void Part1()
        {
            long rslt = 0;

            foreach (List<int> combo in _combos)
            {
                rslt += combo.Sum() == 150 ? 1 : 0;
            }

            Console.WriteLine("Part1: {0}", rslt);
        }

        public void Part2()
        {
            int[] containerCount = new int[_containers.Count];

            for (int i = 0; i < _combos.Count; i++)
            {
                int sum = _combos[i].Sum();
                if (sum == 150)
                {
                    containerCount[_combos[i].Count]++;
                }
            }
            // first value in containerCount that is non-zero is the minimum set of containers
            for (int i = 0; i < containerCount.Length; i++)
            {
                if (containerCount[i] > 0)
                {
                    Console.WriteLine("Part2: {0}", containerCount[i]);
                    break;
                }
            }
        }

        // recursive
        //public static List<List<T>> GetAllCombos<T>(List<T> list)
        //{
        //    List<List<T>> result = new List<List<T>>();
        //    // head
        //    result.Add(new List<T>());
        //    result.Last().Add(list[0]);
        //    if (list.Count == 1)
        //        return result;
        //    // tail
        //    List<List<T>> tailCombos = GetAllCombos(list.Skip(1).ToList());
        //    tailCombos.ForEach(combo =>
        //    {
        //        result.Add(new List<T>(combo));
        //        combo.Add(list[0]);
        //        result.Add(new List<T>(combo));
        //    });
        //    return result;
        //}

        // Iterative, using 'i' as bitmask to choose each combo members
        public static List<List<T>> GetAllCombos<T>(List<T> list)
        {
            int comboCount = (int)Math.Pow(2, list.Count) - 1;
            List<List<T>> result = new List<List<T>>();
            for (int i = 1; i < comboCount + 1; i++)
            {
                // make each combo here
                result.Add(new List<T>());
                for (int j = 0; j < list.Count; j++)
                {
                    if ((i >> j) % 2 != 0)
                        result.Last().Add(list[j]);
                }
            }
            return result;
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
                    _containers.Add(int.Parse(line));
                }

                file.Close();
            }
        }

    }
}
