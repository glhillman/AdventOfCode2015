using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day21
{
    public class Player
    {
        public Player(string name, int hitPoints, Item weapon, Item armor, Item damageRing, Item defenseRing)
        {
            Name = name;
            HitPoints = hitPoints;
            Weapon = weapon;
            ArmorItem = armor;
            DamageRing = damageRing;
            DefenseRing = defenseRing;
            _damage = -1;
            _armor = -1;
        }

        public Player(string name, int hitPoints, int damage, int armor)
        {
            Name = name;
            HitPoints = hitPoints;
            _damage = damage;
            _armor = armor;
        }

        public void TakesHit(int damage)
        {
            int actualDamage = damage - Armor;
            if (actualDamage < 1)
            {
                actualDamage = 1;
            }
            HitPoints -= actualDamage;
        }

        public int Damage
        {
            get
            {
                int damage;
                if (_damage >= 0)
                {
                    damage = _damage;
                }
                else
                {
                    damage = Weapon.Damage;
                    damage += DamageRing != null ? DamageRing.Damage : 0;
                }

                return damage;
            }
        }

        public int Armor
        {
            get
            {
                int armor;
                if (_armor >= 0)
                {
                    armor = _armor;
                }
                else
                {
                    armor = ArmorItem != null ? ArmorItem.Armor : 0;
                    armor += DefenseRing != null ? DefenseRing.Armor : 0;
                }

                return armor;
            }
        }

        public int Cost
        {
            get
            {
                int cost;
                if (_damage >= 0 || _armor >= 0)
                {
                    cost = 0; // boss
                }
                else
                {
                    cost = Weapon.Cost;
                    cost += ArmorItem != null ? ArmorItem.Cost : 0;
                    cost += DamageRing != null ? DamageRing.Cost : 0;
                    cost += DefenseRing != null ? DefenseRing.Cost : 0;
                }

                return cost;
            }
        }

        public string Name { get; private set; }
        public int HitPoints { get; set; }
        public Item Weapon { get; private set; }
        public Item ArmorItem { get; private set; }
        public Item DamageRing { get; private set; }
        public Item DefenseRing { get; private set; }
        public override string ToString()
        {
            return string.Format("Name: {0}, HitPoints: {1}, Damage: {2}, Armor: {3}", Name, HitPoints, Damage, Armor);
        }

        private int _damage;
        private int _armor;
    }
}
