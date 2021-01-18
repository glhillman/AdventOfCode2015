using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day16
{
    public class Aunt
    {
        public Aunt(int auntNum)
        {
            AuntNum = auntNum;
            Attributes = new Dictionary<string, int>();
        }

        public int AuntNum { get; private set; }
        public Dictionary<string, int> Attributes;
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(AuntNum.ToString() + " - ");
            foreach (string key in Attributes.Keys)
            {
                sb.Append(key + ":" + Attributes[key].ToString() + " ");
            }
            return sb.ToString();
        }
    }
}
