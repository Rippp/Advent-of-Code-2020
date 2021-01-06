using System;
using System.IO;

namespace AoC_Day2b
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "input.txt";
            string[] lines = File.ReadAllLines(filename);
            int res = 0;

            for(int i = 0; i < lines.Length; i++)
            {
                string[] words = lines[i].Split(' ', '-', ':');
                int a = int.Parse(words[0]) - 1;
                int b = int.Parse(words[1]) - 1;

                if ((words[4][a] == words[2][0] && words[4][b] != words[2][0]) ||
                    (words[4][b] == words[2][0] && words[4][a] != words[2][0]))
                    res++;
            }

            Console.WriteLine(res);
        }
    }
}
