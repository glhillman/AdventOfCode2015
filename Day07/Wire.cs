using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07
{
    public enum InputEnum
    {
        Value,
        Wire,
        Gate
    };

    public class Wire
    {
        public Wire(string name)
        {
            Name = name;
            Outputs = new List<Gate>();
        }

        public string Name { get; private set; }

        public void SetInputValue(UInt16 value)
        {
            InputValue = value;
            foreach (Gate gate in Outputs)
            {
                gate.SetInputValue(value);
            }
        }

        public void AddOutput(Gate gate)
        {
            Outputs.Add(gate);
        }

        public UInt16 InputValue { get; set; }
        public List<Gate> Outputs { get; set; }

        public override string ToString()
        {
            return string.Format("Wire {0}, In: {1}, Num Out: {2}", Name, InputValue, Outputs.Count);
        }
    }
}
