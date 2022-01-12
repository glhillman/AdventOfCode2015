using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day22
{
    internal class DayClass
    {
        // init values
        public int _bossHitCountInit = 55;
        public int _bossDamageInit = 8;
        public int _personHitCountInit = 50;
        public int _personManaInit = 500;

        public const int _missileID = 0;
        public const int _drainID = 1;
        public const int _shieldID = 2;
        public const int _poisonID = 3;
        public const int _rechargeID = 4;

        int _totalMana;

        public int[] _spellCosts = { 53, 73, 113, 173, 229 };
        public int[] _spellTimers = { 0, 0, 0, 0, 0 };

        public Random _rand = new Random(31415);

        public void Part1()
        {
            int minMana = int.MaxValue;
            for (int i = 0; i < 2000; i++)
            {
                if (PlayGame(false) == true)
                {
                    if (_totalMana < minMana)
                    {
                        //Console.WriteLine("Cost {0} on game {1}", _totalMana, i);
                        minMana = _totalMana;
                    }
                }
            }

            Console.WriteLine("Part1: {0}", minMana);
        }

        public void Part2()
        {
            int minMana = int.MaxValue;
            for (int i = 0; i < 25000; i++)
            {
                if (PlayGame(true) == true)
                {
                    if (_totalMana < minMana)
                    {
                        //Console.WriteLine("Cost {0} on game {1}", _totalMana, i);
                        minMana = _totalMana;
                    }
                }
            }

            Console.WriteLine("Part2: {0}", minMana);
        }

         public bool? PlayGame(bool hard) // returns true if person wins, false if boss wins
        {
            bool? personWon = null;
            bool personTurn = true;
            int bossHitCount = _bossHitCountInit;
            int bossDamage = _bossDamageInit;
            int personHitCount = _personHitCountInit;
            int personMana = _personManaInit;
            int personArmor = 0;

            _totalMana = 0;
            for (int i = 0; i < 5; i++)
            {
                _spellTimers[i] = 0;
            }

            while (personWon == null && bossHitCount > 0 && personHitCount > 0)
            {
                // first apply any spells on timers
                if (_spellTimers[_shieldID] > 0)
                {
                    _spellTimers[_shieldID]--;
                }
                if (_spellTimers[_shieldID] == 0)
                {
                    personArmor = 0;
                }
                if (_spellTimers[_poisonID] > 0)
                {
                    bossHitCount -= 3;
                    _spellTimers[_poisonID]--;
                }
                if (_spellTimers[_rechargeID] > 0)
                {
                    personMana += 101;
                    _spellTimers[_rechargeID]--;
                }
                if (bossHitCount <= 0)
                {
                    personWon = true;
                    break;
                }

                // Now toggle between Person and Boss turns
                // Person is more complex - create a spell & cast it
                if (personTurn)
                {
                    if (hard)
                    {
                        if (--personHitCount <= 0)
                        {
                            personWon = false;
                            break;
                        }
                    }

                    int? spellIndex = GetRandomSpell(personMana);
                    if (spellIndex.HasValue)
                    {
                        switch (spellIndex) // will return 0..4 for a spell that we can afford & doesn't have an active timer
                        {
                            case _missileID:
                                bossHitCount -= 4;
                                break;
                            case _drainID:
                                personHitCount += 2;
                                bossHitCount -= 2;
                                break;
                            case _shieldID:
                                _spellTimers[_shieldID] = 6;
                                personArmor = 7;
                                break;
                            case _poisonID:
                                _spellTimers[_poisonID] = 6;
                                break;
                            case _rechargeID:
                                _spellTimers[_rechargeID] = 5;
                                break;
                            default:
                                break;
                        }
                        personMana -= _spellCosts[spellIndex.Value];
                        _totalMana += _spellCosts[spellIndex.Value];
                        if (bossHitCount <= 0)
                        {
                            personWon = true;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    personHitCount -= Math.Max(bossDamage - personArmor, 1);
                    if (personHitCount <= 0)
                    {
                        personWon = false;
                    }
                }
                personTurn = !personTurn;
            }

            return personWon;
        }

        public int? GetRandomSpell(int personMana)
        {
            int? spellIndex = null;

            if (personMana >= _spellCosts[0])
            {
                do
                {
                    spellIndex = _rand.Next(5);
                } while (_spellCosts[spellIndex.Value] > personMana || _spellTimers[spellIndex.Value] > 0);
            }

            return spellIndex;
        }
    }
}
