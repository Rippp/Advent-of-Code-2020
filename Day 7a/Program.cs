using System;
using System.IO;

namespace AoC_Day7a
{
    class Program
    {
        public static bool check(string tone, string col, string wtone, string wcol, string[] lines)
        {
            if (tone == wtone && col == wcol)
                return true;

            int i;
            string[] words = new string [0];
            for (i = 0; i < lines.Length; i++)
            {
                words = lines[i].Split(' ');
                if (words[0] == tone && words[1] == col)
                    break;
            }

            if (words.Length == 7)
                return false;

            bool ret = false;
            for(i = 5; i < words.Length; i += 4)
            {
                ret = ret || check(words[i], words[i + 1], wtone, wcol, lines); 
            }

            return ret;
        }
        static void Main(string[] args)
        {
            string filename = "input.txt";
            string[] lines = File.ReadAllLines(filename);

            int ret = 0;
            for(int i = 0; i < lines.Length; i++)
            {
                string[] words = lines[i].Split(' ');
                if ( (words[0] != "shiny" || words[1] != "gold") &&
                     check(words[0], words[1], "shiny", "gold", lines) )
                    ret++;
            }

            Console.WriteLine(ret);
        }
    }
}
