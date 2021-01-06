using System;
using System.IO;

namespace AoC_Day9a
{
    class Program
    {

        public static bool check(string[] lines, int ind)
        {
            int num = int.Parse(lines[ind]);
            for(int i = ind - 25; i < ind; i++)
            {
                for (int j = i + 1; j < ind; j++)
                    if (int.Parse(lines[i]) + int.Parse(lines[j]) == num)
                        return true;
            }
            return false;
        }
        static void Main(string[] args)
        {
            string filename = "input.txt";
            string[] lines = File.ReadAllLines(filename);

            for(int i = 25; i < lines.Length; i++)
                if(!check(lines, i))
                {
                    Console.WriteLine(lines[i]);
                    break;
                }
        }
    }
}
