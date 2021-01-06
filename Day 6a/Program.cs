using System;
using System.IO;
using System.Linq;

namespace AoC_Day6a
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "input.txt";
            string[] lines = File.ReadAllLines(filename);

            int[] answ = new int[26];
            int ret = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] != "")
                {
                    for (int j = 0; j < lines[i].Length; j++)
                        answ[lines[i][j] - (int)'a'] = 1;
                }
                if(lines[i] == "" || i == lines.Length - 1)
                {
                    ret += answ.Sum();
                    for (int j = 0; j < answ.Length; j++)
                        answ[j] = 0;
                }
            }

            Console.WriteLine(ret);
        }
    }
}
