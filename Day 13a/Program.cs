using System;
using System.IO;

namespace AoC_Day13a
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "input.txt";
            string[] lines = File.ReadAllLines(filename);
            string[] nums = lines[1].Split(',');

            int tstmp = int.Parse(lines[0]);
            int t, id, min_id = 0, min_t = int.MaxValue;

            foreach(string num in nums)
            {
                if (num != "x")
                {
                    id = int.Parse(num);
                    t = id - (tstmp % id);

                    if (t == 0) { min_t = 0; break; }
                    if (t < min_t) { min_t = t; min_id = id;}
                }
            }

            Console.WriteLine(min_id * min_t);
        }
    }
}
