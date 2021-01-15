using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day13
{
    public class GuestPair
    {
        public GuestPair(string guest1, string guest2, int happiness)
        {
            Guests = new List<string>();
            Guests.Add(guest1);
            Guests.Add(guest2);
            Happiness = happiness;
        }

        public List<string> Guests;
        public int Happiness { get; private set; }

        public override string ToString()
        {
            return string.Format("{0} to {1} : {2}", Guests[0], Guests[1], Happiness);
        }
    }

    public class Day13
    {
        List<GuestPair> _guestPairs;
        string[] _guests;
        int _maxHappiness = int.MinValue;

        public Day13()
        {
            LoadData();
            Perm(_guests, 0);
        }

        public void Part1()
        {
            Console.WriteLine("Part1: {0}", _maxHappiness);
        }

        public void Part2()
        {
            string[] _guests2 = new string[_guests.Length + 1];
            _guests.CopyTo(_guests2, 0);
            _guests2[_guests2.Length - 1] = "Lee";

            foreach (string guest in _guests)
            {
                _guestPairs.Add(new GuestPair(guest, "Lee", 0));
                _guestPairs.Add(new GuestPair("Lee", guest, 0));
            }

            _maxHappiness = int.MinValue;
            Perm(_guests2, 0);

            Console.WriteLine("Part2: {0}", _maxHappiness);
        }

        void Perm(string[] arr, int k)
        {
            if (k >= arr.Length)
                CalculateHappiness(arr);
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

        int calcs = 0;
        private void CalculateHappiness(string[] arr)
        {
            calcs++;

            int happiness = 0;
            GuestPair guestPair;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                guestPair = _guestPairs.FirstOrDefault(p => p.Guests[0] == arr[i] && p.Guests[1] == (arr[i + 1]));
                happiness += guestPair.Happiness;
                guestPair = _guestPairs.FirstOrDefault(p => p.Guests[0] == arr[i + 1] && p.Guests[1] == (arr[i]));
                happiness += guestPair.Happiness;
            }
            guestPair = _guestPairs.FirstOrDefault(p => p.Guests[0] == arr[0] && p.Guests[1] == (arr[arr.Length-1]));
            happiness += guestPair.Happiness;
            guestPair = _guestPairs.FirstOrDefault(p => p.Guests[0] == arr[arr.Length-1] && p.Guests[1] == (arr[0]));
            happiness += guestPair.Happiness;

            _maxHappiness = Math.Max(_maxHappiness, happiness);
            //Console.WriteLine(string.Join(", ", arr) + " - happiness: {0}", happiness);
        }

        private void LoadData()
        {
            string inputFile = AppDomain.CurrentDomain.BaseDirectory + @"..\..\input.txt";

            if (File.Exists(inputFile))
            {
                List<string> guestList = new List<string>();
                _guestPairs = new List<GuestPair>();
                string line;
                StreamReader file = new StreamReader(inputFile);
                while ((line = file.ReadLine()) != null)
                {
                    string[] split = line.Replace(".","").Split(' ');
                    int value = int.Parse(split[3]);
                    if (split[2] == "lose")
                    {
                        value = -value;
                    }
                    _guestPairs.Add(new GuestPair(split[0], split[10], value));
                    if (guestList.Contains(split[0]) == false)
                    {
                        guestList.Add(split[0]);
                    }
                    if (guestList.Contains(split[10]) == false)
                    {
                        guestList.Add(split[10]);
                    }
                }

                _guests = guestList.ToArray();

                file.Close();
            }
        }
    }
}
