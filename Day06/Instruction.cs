using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day06
{
    public enum InstEnum
    {
        On,
        Off,
        Toggle
    };

    public class Instruction
    {
        public Instruction(string strInst)
        {
            string range;
            if (strInst.StartsWith("turn on"))
            {
                Inst = InstEnum.On;
                range = strInst.Substring("turn on".Length);
            }
            else if (strInst.StartsWith("turn off"))
            {
                Inst = InstEnum.Off;
                range = strInst.Substring("turn off".Length);
            }
            else
            {
                Inst = InstEnum.Toggle;
                range = strInst.Substring("toggle".Length);
            }

            range = range.Replace(" through ", ":");
            string[] ranges = range.Split(':');
            string[] pair = ranges[0].Split(',');
            StartX = int.Parse(pair[0]);
            StartY = int.Parse(pair[1]);
            pair = ranges[1].Split(',');
            EndX = int.Parse(pair[0]);
            EndY = int.Parse(pair[1]);
        }

        public override string ToString()
        {
            return string.Format("{0} from {1},{2} through {3},{4}", Inst, StartX, StartY, EndX, EndY);
        }

        public InstEnum Inst; 
        public int StartX;
        public int StartY;
        public int EndX;
        public int EndY;


    }
}
