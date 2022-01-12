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

        public int _bossHitCount;
        public int _bossDamage;
        public int _personHitCount;
        public int _personMana;
        public int _personArmor;

        public int _totalMana;

        public int _shieldTimer = 0;
        public int _poisonTimer = 0;
        public int _rechargeTimer = 0;

        public const int _missileID = 0;
        public const int _drainID = 1;
        public const int _shieldID = 2;
        public const int _poisonID = 3;
        public const int _rechargeID = 4;

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
            for (int i = 0; i < 15000; i++)
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

        public void InitState()
        {
            _bossHitCount = _bossHitCountInit;
            _bossDamage = _bossDamageInit;
            _personHitCount = _personHitCountInit;
            _personMana = _personManaInit;
            _totalMana = 0;
            for (int i = 0; i < 5; i++)
            {
                _spellTimers[i] = 0;
            }
        }

        public bool? PlayGame(bool hard) // returns true if person wins, false if boss wins
        {
            bool? personWon = null;
            bool personTurn = true;
            InitState();

            while (personWon == null && _bossHitCount > 0 && _personHitCount > 0)
            {
                // first apply any spells on timers
                if (_spellTimers[_shieldID] > 0)
                {
                    _spellTimers[_shieldID]--;
                }
                if (_spellTimers[_shieldID] == 0)
                {
                    _personArmor = 0;
                }
                if (_spellTimers[_poisonID] > 0)
                {
                    _bossHitCount -= 3;
                    _spellTimers[_poisonID]--;
                }
                if (_spellTimers[_rechargeID] > 0)
                {
                    _personMana += 101;
                    _spellTimers[_rechargeID]--;
                }
                if (_bossHitCount <= 0)
                {
                    personWon = true;
                    break;
                }

                if (personWon == null)
                {
                    // Now toggle between Person and Boss turns
                    // Person is more complex - create a spell & cast it
                    if (personTurn)
                    {
                        if (hard)
                        {
                            if (--_personHitCount <= 0)
                            {
                                personWon = false;
                                break;
                            }
                        }

                        int? spellIndex = GetRandomSpell();
                        if (spellIndex.HasValue)
                        {
                            switch (spellIndex) // will return 0..4 for a spell that we can afford & doesn't have an active timer
                            {
                                case _missileID:
                                    _bossHitCount -= 4;
                                    break;
                                case _drainID:
                                    _personHitCount += 2;
                                    _bossHitCount -= 2;
                                    break;
                                case _shieldID:
                                    _spellTimers[_shieldID] = 6;
                                    _personArmor = 7;
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
                            _personMana -= _spellCosts[spellIndex.Value];
                            _totalMana += _spellCosts[spellIndex.Value];
                            if (_bossHitCount <= 0)
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
                        _personHitCount -= Math.Max(_bossDamage - _personArmor, 1);
                        if (_personHitCount <= 0)
                        {
                            personWon = false;
                        }
                    }
                    personTurn = !personTurn;
                }

            }

            return personWon;
        }

        public int? GetRandomSpell()
        {
            int? spellIndex = null;

            if (_personMana >= _spellCosts[0])
            {
                do
                {
                    spellIndex = _rand.Next(5);
                } while (_spellCosts[spellIndex.Value] > _personMana || _spellTimers[spellIndex.Value] > 0);
            }

            return spellIndex;
        }
    }
}
