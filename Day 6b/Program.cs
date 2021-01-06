using System;
using System.IO;
using System.Linq;

namespace AoC_Day6b
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "input.txt";
            string[] lines = File.ReadAllLines(filename);

            int[] answ = new int[26];
            int ret = 0, gc = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] != "")
                {
                    for (int j = 0; j < lines[i].Length; j++)
                        answ[lines[i][j] - (int)'a'] += 1;
                    gc++;
                }
                if (lines[i] == "" || i == lines.Length - 1)
                {

                    for (int j = 0; j < answ.Length; j++)
                    {
                        if (answ[j] == gc) ret++;
                        answ[j] = 0;
                    }
                    gc = 0;
                }
            }

            Console.WriteLine(ret);
        }
    }
}
