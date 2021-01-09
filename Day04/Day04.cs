using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Day04
{
    public class Day04
    {

        public Day04()
        {
        }

        public void Part1()
        {
            var md5Hash = MD5.Create();

            int i = 0;
            do
            {
                i++;
                string source = "bgvyzdsv" + i.ToString();

                byte[] sourceBytes = Encoding.UTF8.GetBytes(source);
                byte[] hashBytes = md5Hash.ComputeHash(sourceBytes);
                string hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);

                if (hash.Substring(0, 5) == "00000")
                {
                    break;
                }
            } while (true);

            Console.WriteLine("Part1: {0}", i);
        }

        public void Part2()
        {
            var md5Hash = MD5.Create();

            int i = 254574; // can start from part1 solution
            do
            {
                i++;
                string source = "bgvyzdsv" + i.ToString();
                byte[] sourceBytes = Encoding.UTF8.GetBytes(source);
                byte[] hashBytes = md5Hash.ComputeHash(sourceBytes);
                string hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);

                if (hash.Substring(0, 6) == "000000")
                {
                    break;
                }
            } while (true);

            Console.WriteLine("Part2: {0}", i);
        }
    }
}
