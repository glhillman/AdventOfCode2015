using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day21
{
    public enum ItemEnum 
    {
        Weapon,
        Armor,
        DamageRing,
        DefenseRing
    };

    public class Item
    {
        public Item (ItemEnum itemType, string name, int cost, int damage, int armor)
        {
            ItemType = itemType;
            Name = name;
            Cost = cost;
            Damage = damage;
            Armor = armor;
        }

        public ItemEnum ItemType { get; private set; }
        public string Name { get; private set; }
        public int Cost { get; private set; }
        public int Damage { get; private set; }
        public int Armor { get; private set; }

        public override string ToString()
        {
            return string.Format("Type: {0}, Name: {1}, Cost: {2}, Damage: {3}, Armor: {4}", ItemType, Name, Cost, Damage, Armor);
        }
    }
}
