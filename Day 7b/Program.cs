using System;
using System.IO;

namespace AoC_Day7b
{
    class Program
    {
        public static int count(string tone, string col, string[] lines)
        {
            int i;
            string[] words = new string[0];
            for (i = 0; i < lines.Length; i++)
            {
                words = lines[i].Split(' ');
                if (words[0] == tone && words[1] == col)
                    break;
            }

            if (words.Length == 7)
                return 1;

            int ret = 1;
            for(i = 5; i < words.Length; i += 4)
            {
                ret += int.Parse(words[i - 1]) * count(words[i], words[i + 1], lines);
            }
            return ret;
        }
        static void Main(string[] args)
        {
            string filename = "input.txt";
            string[] lines = File.ReadAllLines(filename);

            Console.WriteLine(count("shiny", "gold", lines) - 1);
        }
    }
}
