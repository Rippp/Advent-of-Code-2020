using System;
using System.IO;

namespace AoC_Day5a
{
    class Program
    {
        public static int getId(string line)
        {
            line = line.Replace('F', '0');
            line = line.Replace('B', '1');
            line = line.Replace('R', '1');
            line = line.Replace('L', '0');

            return Convert.ToInt32(line, 2);
        }
        static void Main(string[] args)
        {
            string filename = "input.txt";
            string[] lines = File.ReadAllLines(filename);

            int max = 0;
            for(int i = 0; i < lines.Length; i++)
            {
                max = Math.Max(max, getId(lines[i]));
            }

            Console.WriteLine(max);
        }
    }
}