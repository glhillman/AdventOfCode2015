using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14
{
    public class Deer
    {
        public Deer(string name, int speed, int runTime, int restTime)
        {
            Name = name;
            Speed = speed;
            RunTime = runTime;
            RestTime = restTime;
        }

        public void Reset()
        {
            Distance = 0;
            RunLeft = RunTime;
            RestLeft = 0;
            Points = 0;
        }

        public int RunFor(int seconds)
        {
            
            int second = 0;

            Reset();

            while (second < seconds)
            {
                Step();
                second++;
            }

            return Distance;
        }

        public int Step()
        {
            if (RunLeft > 0)
            {
                Distance += Speed;
                if (--RunLeft == 0)
                {
                    RestLeft = RestTime;
                }
            }
            else if (RestLeft > 0)
            {
                if (--RestLeft == 0)
                {
                    RunLeft = RunTime;
                }
            }

            return Distance;
        }

        public void AddPoint()
        {
            Points++;
        }

        public string Name { get; private set; }
        private int Speed { get; set; }
        private int RunTime { get;  set; }
        private int RestTime { get; set; }
        private int RunLeft { get; set; }
        private int RestLeft { get; set; }
        public int Distance { get; set; }
        public int Points { get; set; }
    }
}
