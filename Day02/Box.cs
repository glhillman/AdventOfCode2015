using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02
{
    public class Box
    {
        public Box(int length, int width, int height)
        {
            Length = length;
            Width = width;
            Height = height;

            _sortedDimensions = new int[] { Length, Width, Height };

            // sort the values
            Array.Sort(_sortedDimensions);

        }

        public int AreaPlusSlack()
        {
            return Area() + Slack();
        }

        public int Area()
        {
            return (2 * Length * Width) + (2 * Width * Height) + (2 * Height * Length);
        }

        public int Slack()
        {
            return _sortedDimensions[0] * _sortedDimensions[1];
        }

        public int TotalRibbon()
        {
            return Ribbon() + Bow();
        }
        
        public int Ribbon()
        {
            return 2 * _sortedDimensions[0] + 2 * _sortedDimensions[1];
        }

        public int Bow()
        {
            return Length * Width * Height;
        }

        public int Length { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        private int[] _sortedDimensions;
    }
}
