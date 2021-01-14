using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day09
{
    public class TownPair
    {
        public TownPair(string town1, string town2, int distance)
        {
            Towns = new List<string>();
            Towns.Add(town1);
            Towns.Add(town2);
            Distance = distance;
        }

        public List<string> Towns;
        public int Distance { get; private set; }

        public override string ToString()
        {
            return string.Format("{0} to {1} - {2}", Towns[0], Towns[1], Distance);
        }
    }

    class Day09
    {
        List<TownPair> _townsPairs;
        string[] _towns;
        int _shortestDistance = int.MaxValue;
        int _longestDistance = int.MinValue;

        public Day09()
        {
            LoadData();
            Perm(_towns, 0);
        }

        public void Part1()
        {
            Console.WriteLine("Part1: {0}", _shortestDistance);
        }

        public void Part2()
        {
            Console.WriteLine("Part2: {0}", _longestDistance);
        }

        void Perm(string[] arr, int k)
        {
            if (k >= arr.Length)
                CalculateDistance(arr);
            else
            {
                Perm(arr, k + 1);
                for (int i = k + 1; i < arr.Length; i++)
                {
                    Swap(ref arr[k], ref arr[i]);
                    Perm(arr, k + 1);
                    Swap(ref arr[k], ref arr[i]);
                }
            }
        }

        private void Swap(ref string item1, ref string item2)
        {
            string temp = item1;
            item1 = item2;
            item2 = temp;
        }

        private void CalculateDistance(string[] arr)
        {
            int distance = 0;

            for (int i = 0; i < arr.Length-1; i++)
            {
                TownPair townPair = _townsPairs.FirstOrDefault(p => p.Towns.Contains(arr[i]) && p.Towns.Contains(arr[i + 1]));
                distance += townPair.Distance;
            }

            _shortestDistance = Math.Min(_shortestDistance, distance);
            _longestDistance = Math.Max(_longestDistance, distance);

//            Console.WriteLine(string.Join(", ", arr) + " - distance: {0}", distance);
        }


        private void LoadData()
        {
            string inputFile = AppDomain.CurrentDomain.BaseDirectory + @"..\..\input.txt";

            if (File.Exists(inputFile))
            { 
                _townsPairs = new List<TownPair>();
                List<string> townList = new List<string>();
                string line;
                StreamReader file = new StreamReader(inputFile);
                while ((line = file.ReadLine()) != null)
                {
                    line = line.Replace(" to ", ":").Replace(" = ", ":");
                    string[] split = line.Split(':');
                    _townsPairs.Add(new TownPair(split[0], split[1], int.Parse(split[2])));
                    if (townList.Contains(split[0]) == false)
                    {
                        townList.Add(split[0]);
                    }
                    if (townList.Contains(split[1]) == false)
                    {
                        townList.Add(split[1]);
                    }
                }

                _towns = townList.ToArray();
                file.Close();
            }
        }
    }
}
