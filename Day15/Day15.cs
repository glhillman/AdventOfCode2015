using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day15
{
    public class Day15
    {
        List<Ingredient> _ingredients = new List<Ingredient>();
        public Day15()
        {
            LoadData();
        }

        public void Part1()
        {
            int bestScore = CalcCookie(-1);

            Console.WriteLine("Part1: {0}", bestScore);
        }

        public void Part2()
        {
            int bestScore = CalcCookie(500);
            Console.WriteLine("Part2: {0}", bestScore);
        }

        private int CalcCookie(int calorieTarget)
        {
            int bestScore = int.MinValue;

            for (int i = 1; i <= 100; i++) // frosting
            {
                for (int j = 1; j <= 100; j++) // candy
                {
                    if (i + j >= 100)
                    {
                        break;
                    }
                    else
                    {
                        for (int k = 0; k <= 100; k++) // butterscotch
                        {
                            if (i + j + k >= 100)
                            {
                                break;
                            }
                            else
                            {
                                for (int l = 0; l <= 100; l++) // sugar
                                {
                                    int sum = i + j + k + l;
                                    if (sum == 100)
                                    {
                                        int[] ingredients = { i, j, k, l };
                                        int cookieScore = 0;
                                        int capacity = 0;
                                        int durability = 0;
                                        int flavor = 0;
                                        int texture = 0;
                                        int calories = 0;
                                        bool caloriesOk;

                                        for (int x = 0; x < ingredients.Length; x++)
                                        {
                                            capacity += _ingredients[x].Capacity * ingredients[x];
                                            durability += _ingredients[x].Durability * ingredients[x];
                                            flavor += _ingredients[x].Flavor * ingredients[x];
                                            texture += _ingredients[x].Texture * ingredients[x];
                                            calories += _ingredients[x].Calories * ingredients[x];
                                        }
                                        if (calorieTarget > 0)
                                        {
                                            caloriesOk = calorieTarget == calories;
                                        }
                                        else
                                        {
                                            caloriesOk = true;
                                        }
                                        if (caloriesOk && capacity > 0 && durability > 0 && flavor > 0 && texture > 0)
                                        {
                                            cookieScore = capacity * durability * flavor * texture;
                                            bestScore = Math.Max(cookieScore, bestScore);
                                        }
                                        break;
                                    }
                                    else if (sum > 100)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return bestScore;
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
                    line = line.Replace(' ', ':').Replace(',', ':');
                    string[] tokens = line.Split(':');
                    _ingredients.Add(new Ingredient(tokens[0], int.Parse(tokens[3]), int.Parse(tokens[6]), int.Parse(tokens[9]), int.Parse(tokens[12]), int.Parse(tokens[15])));
                }

                file.Close();
            }
        }

    }
}
