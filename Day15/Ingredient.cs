using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day15
{
    public class Ingredient
    {
        public Ingredient(string name, int capacity, int durability, int flavor, int texture, int calories)
        {
            Name = name;
            Capacity = capacity;
            Durability = durability;
            Flavor = flavor;
            Texture = texture;
            Calories = calories;
        }


        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public int Durability { get; private set; }
        public int Flavor { get; private set; }
        public int Texture { get; private set; }
        public int Calories { get; private set; }
    }
}
