using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07
{
    public abstract class Gate
    {
        public Wire OutputWire {get; set;}
        public ushort OutputValue { get; protected set; }
        public abstract void SetInputValue(ushort value);
    }

    public class GateSingle : Gate
    {
        protected ushort InputValue;
        public override void SetInputValue(ushort value)
        {
            InputValue = value;
        }
    }

    public class GateDouble : Gate
    {
        protected ushort?[] Inputs = new ushort?[2];

        public override void SetInputValue(ushort value)
        {
            if (Inputs[0].HasValue)
            {
                Inputs[1] = value;
            }
            else
            {
                Inputs[0] = value;
            }
        }
    }

    public class AND : GateDouble
    {
        public override void SetInputValue(ushort value)
        {
            base.SetInputValue(value);
            if (Inputs[0].HasValue && Inputs[1].HasValue)
            {
                OutputValue = (ushort)(Inputs[0].Value & Inputs[1].Value);
                OutputWire.SetInputValue(OutputValue);
            }
        }

        public override string ToString()
        {
            string in1 = Inputs[0].HasValue ? Inputs[0].Value.ToString() : "null";
            string in2 = Inputs[1].HasValue ? Inputs[1].Value.ToString() : "null";
            return string.Format("AND In1: {0}, In2: {1}, Out: {2}", in1, in2, OutputValue);
        }
    }

    public class OR : GateDouble
    {
        public override void SetInputValue(ushort value)
        {
            base.SetInputValue(value);
            if (Inputs[0].HasValue && Inputs[1].HasValue)
            {
                OutputValue = (ushort)(Inputs[0].Value | Inputs[1].Value);
                OutputWire.SetInputValue(OutputValue);
            }
        }
        public override string ToString()
        {
            string in1 = Inputs[0].HasValue ? Inputs[0].Value.ToString() : "null";
            string in2 = Inputs[1].HasValue ? Inputs[1].Value.ToString() : "null";
            return string.Format("OR In1: {0}, In2: {1}, Out: {2}", in1, in2, OutputValue);
        }
    }

    public class NOT : GateSingle
    {
        public override void SetInputValue(ushort value)
        {
            base.SetInputValue(value);
            OutputValue = (ushort)~InputValue;
            OutputWire.SetInputValue(OutputValue);
        }

        public override string ToString()
        {
            return string.Format("NOT In: {0}, Out {1}", InputValue, OutputValue);
        }
    }

    public class SHIFT : GateSingle
    {
        public void SetShiftAmount(int shiftAmount)
        {
            ShiftAmount = shiftAmount;
        }

        protected int ShiftAmount { get; set; }
    }

    public class RSHIFT : SHIFT
    {
        public override void SetInputValue(ushort value)
        {
            base.SetInputValue(value);
            OutputValue = (ushort)(InputValue >> ShiftAmount);
            OutputWire.SetInputValue(OutputValue);
        }

        public override string ToString()
        {
            return string.Format("RSHIFT In: {0}, Out: {1}", InputValue, OutputValue);
        }
    }

    public class LSHIFT : SHIFT
    {
        public override void SetInputValue(ushort value)
        {
            base.SetInputValue(value);
            OutputValue = (ushort)(InputValue << ShiftAmount);
            OutputWire.SetInputValue(OutputValue);
        }

        public override string ToString()
        {
            return string.Format("LSHIFT In: {0}, Out: {1}", InputValue, OutputValue);
        }
    }

    public class PASSTHROUGH : GateSingle
    {
        public override void SetInputValue(ushort value)
        {
            base.SetInputValue(value);
            OutputValue = InputValue;
            OutputWire.SetInputValue(OutputValue);
        }

        public override string ToString()
        {
            return string.Format("PASSTHROUGH In: {0}, Out: {1}", InputValue, OutputValue);
        }
    }

}
