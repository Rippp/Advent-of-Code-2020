using System;
using System.IO;

namespace AoC_Day3b
{
    class Program
    {
        static public int CountTrees(string[] lines, int right, int down)
        {
            int ret = 0;
            for (int i = 0, j = 0; i < lines.Length; i+=down, j+=right)
            {
                if (lines[i][j % lines[i].Length] == '#')
                    ret++;
            }
            return ret;
        }
        static void Main(string[] args)
        {
            string filename = "input.txt";
            string[] lines = File.ReadAllLines(filename);

            int ret = CountTrees(lines, 1, 1);
            ret *= CountTrees(lines, 3, 1);
            ret *= CountTrees(lines, 5, 1);
            ret *= CountTrees(lines, 7, 1);
            ret *= CountTrees(lines, 1, 2);

            Console.WriteLine(ret);
        }
    }
}
