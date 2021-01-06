using System;
using System.IO;
using System.Collections;

namespace AoC_Day5b
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
            int[] ids = new int[lines.Length];
            
            for (int i = 0; i < lines.Length; i++)
            {
                ids[i] = getId(lines[i]);
            }

            Array.Sort(ids);

            for(int i = 1; i < lines.Length; i++)
            {
                if (ids[i] - ids[i-1] == 2)
                {
                    Console.WriteLine(ids[i] - 1);
                }
            }
        }
    }
}