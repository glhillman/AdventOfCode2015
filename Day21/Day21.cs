using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day21
{
    public class Day21
    {
        List<Item> _weapons = new List<Item>();
        List<Item> _armor = new List<Item>();
        List<Item> _damageRings = new List<Item>();
        List<Item> _defenseRings = new List<Item>();

        public Day21()
        {
            _weapons.Add(new Item(ItemEnum.Weapon, "Dagger", 8, 4, 0));
            _weapons.Add(new Item(ItemEnum.Weapon, "Shortsword", 10, 5, 0));
            _weapons.Add(new Item(ItemEnum.Weapon, "Warhammer", 25, 6, 0));
            _weapons.Add(new Item(ItemEnum.Weapon, "Longsword", 40, 7, 0));
            _weapons.Add(new Item(ItemEnum.Weapon, "Greataxe", 74, 8, 0));

            _armor.Add(new Item(ItemEnum.Armor, "Leather", 13, 0, 1));
            _armor.Add(new Item(ItemEnum.Armor, "Chainmail", 31, 0, 2));
            _armor.Add(new Item(ItemEnum.Armor, "Splintmail", 53, 0, 3));
            _armor.Add(new Item(ItemEnum.Armor, "Bandedmail", 75, 0, 4));
            _armor.Add(new Item(ItemEnum.Armor, "Platemail", 102, 0, 5));

            _damageRings.Add(new Item(ItemEnum.DamageRing, "Damage1", 25, 1, 0));
            _damageRings.Add(new Item(ItemEnum.DamageRing, "Damage2", 50, 2, 0));
            _damageRings.Add(new Item(ItemEnum.DamageRing, "Damage3", 100, 3, 0));

            _defenseRings.Add(new Item(ItemEnum.DefenseRing, "Defense1", 20, 0, 1));
            _defenseRings.Add(new Item(ItemEnum.DefenseRing, "Defense2", 40, 0, 2));
            _defenseRings.Add(new Item(ItemEnum.DefenseRing, "Defense3", 80, 0, 3));
        }
        public void Part1And2()
        {
            int leastCost = int.MaxValue;
            int mostCost = int.MinValue;

            for (int weaponIndex = 0; weaponIndex < _weapons.Count; weaponIndex++)
            {
                for (int armorIndex = -1; armorIndex < _armor.Count; armorIndex++)
                {
                    for (int damageRingIndex = -1; damageRingIndex < _damageRings.Count; damageRingIndex++)
                    {
                        for (int defenseRingIndex = -1; defenseRingIndex < _defenseRings.Count; defenseRingIndex++)
                        {
                            Item weapon = _weapons[weaponIndex];
                            Item armor = armorIndex >= 0 ? _armor[armorIndex] : null;
                            Item damageRing = damageRingIndex >= 0 ? _damageRings[damageRingIndex] : null;
                            Item defenseRing = defenseRingIndex >= 0 ? _defenseRings[defenseRingIndex] : null;

                            Player lee = new Player("Lee", 100, weapon, armor, damageRing, defenseRing);
                            Player boss = new Player("Boss", 103, 9, 2);

                            while (lee.HitPoints > 0 && boss.HitPoints > 0)
                            {
                                boss.TakesHit(lee.Damage);
                                if (boss.HitPoints > 0)
                                {
                                    lee.TakesHit(boss.Damage);
                                }
                            }
                            if (lee.HitPoints > 0)
                            {
                                leastCost = Math.Min(lee.Cost, leastCost);
                            }
                            else
                            {
                                mostCost = Math.Max(lee.Cost, mostCost);
                            }

                        }
                    }
                }
            }

            Console.WriteLine("Part1: {0}", leastCost);
            Console.WriteLine("Part2: {0}", mostCost);
        }
    }
}
