using System;
using System.IO;

namespace AoC_Day3a
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "input.txt";
            string[] lines = File.ReadAllLines(filename);

            int ret = 0;
            for(int i = 0; i < lines.Length; i++)
            {
                if (lines[i][(i * 3) % lines[i].Length] == '#')
                    ret++;
            }

            Console.WriteLine(ret);
        }
    }
}
