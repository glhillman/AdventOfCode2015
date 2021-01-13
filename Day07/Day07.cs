using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07
{
    public class Day07
    {
        Dictionary<string, Wire> _wires;
        List<Gate> _gates; // don't really need this list I think - they can float
        List<(string wireName, ushort value)> _constants;
        ushort _part1Result = 0;

        public Day07()
        {
        }

        public void Part1()
        {
            LoadData();

            foreach ((string wireName, ushort value) pair in _constants)
            {
                _wires[pair.wireName].SetInputValue(pair.value);
            }

            _part1Result = _wires["a"].InputValue;

            Console.WriteLine("Part1: {0}", _part1Result);
        }

        public void Part2()
        {
            LoadData();

            foreach ((string wireName, ushort value) pair in _constants)
            {
                if (pair.wireName == "b")
                {
                    _wires["b"].SetInputValue(_part1Result);
                }
                else
                {
                    _wires[pair.wireName].SetInputValue(pair.value);
                }
            }

            long rslt = _wires["a"].InputValue;

            Console.WriteLine("Part2: {0}", rslt);
        }

        private void LoadData()
        {
            _wires = new Dictionary<string, Wire>();
            _gates = new List<Gate>();
            _constants = new List<(string wire, ushort value)>();

            string inputFile = AppDomain.CurrentDomain.BaseDirectory + @"..\..\input.txt";

            if (File.Exists(inputFile))
            {
                string line;
                StreamReader file = new StreamReader(inputFile);
                string[] parts;
                string arg1;
                string arg2;
                string wireOut = string.Empty;
                Gate gate;

                while ((line = file.ReadLine()) != null)
                {
                    gate = null;

                    if (line.Contains(" AND "))
                    {
                        gate = new AND();
                        line = line.Replace(" AND ", ":");
                    }
                    else if (line.Contains(" OR "))
                    {
                        gate = new OR();
                        line = line.Replace(" OR ", ":");
                    }
                    else if (line.Contains(" RSHIFT "))
                    {
                        gate = new RSHIFT();
                        line = line.Replace(" RSHIFT ", ":");
                    }
                    else if (line.Contains(" LSHIFT "))
                    {
                        gate = new LSHIFT();
                        line = line.Replace(" LSHIFT ", ":");
                    }
                    if (gate != null)
                    {
                        line = line.Replace(" -> ", ":");
                        parts = line.Split(':');
                        arg1 = parts[0];
                        arg2 = parts[1];
                        ushort value = 0;
                        bool argIsValue = false;
                        if (gate.GetType() == typeof(AND) || gate.GetType() == typeof(OR))
                        {
                            argIsValue = ushort.TryParse(arg1, out value);
                        }
                        wireOut = parts[2];
                        if (_wires.ContainsKey(arg1) == false && argIsValue == false)
                        {
                            _wires[arg1] = new Wire(arg1);
                        }
                        if (gate.GetType() == typeof(AND) || gate.GetType() == typeof(OR))
                        {
                            if (_wires.ContainsKey(arg2) == false)
                            {
                                _wires[arg2] = new Wire(arg2);
                            }
                            _wires[arg2].AddOutput(gate);
                        }
                        else // rshift or lshift
                        {
                            int shiftValue = int.Parse(arg2);
                            (gate as SHIFT).SetShiftAmount(shiftValue);
                        }
                        if (argIsValue)
                        {
                            gate.SetInputValue(value);
                        }
                        else
                        {
                            _wires[arg1].AddOutput(gate);
                        }
                    }
                    else if (line.StartsWith("NOT "))
                    {
                        line = line.Replace("NOT ", "").Replace(" -> ", ":");
                        parts = line.Split(':');
                        gate = new NOT();
                        arg1 = parts[0];
                        wireOut = parts[1];
                        if (_wires.ContainsKey(arg1) == false)
                        {
                            _wires[arg1] = new Wire(arg1);
                        }
                        _wires[arg1].AddOutput(gate);
                    }
                    else if (line.Contains(" -> "))
                    {
                        // either a const to wire trigger or wire to wire
                        line = line.Replace(" -> ", ":");
                        parts = line.Split(':');
                        arg1 = parts[0];
                        wireOut = parts[1];
                        ushort constant;

                        if (ushort.TryParse(arg1, out constant))
                        {
                            // constant assigned to wire
                            _constants.Add((wireOut, constant));
                        }
                        else
                        {
                            gate = new PASSTHROUGH();
                            if (_wires.ContainsKey(arg1) == false)
                            {
                                _wires[arg1] = new Wire(arg1);
                            }
                            _wires[arg1].AddOutput(gate);
                        }

                    }
                    if (gate != null)
                    {
                        if (_wires.ContainsKey(wireOut) == false)
                        {
                            _wires[wireOut] = new Wire(wireOut);
                        }
                        gate.OutputWire = _wires[wireOut];
                        _gates.Add(gate);
                    }
                }

                file.Close();
            }
        }

    }
}
