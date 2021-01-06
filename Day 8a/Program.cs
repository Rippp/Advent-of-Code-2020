using System;
using System.IO;

namespace AoC_Day8a
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "input.txt";
            string[] lines = File.ReadAllLines(filename);
            bool[] vis = new bool[lines.Length];
            int acc = 0;

            for (int i = 0; i < lines.Length;)
            {
                string[] words = lines[i].Split(' ');        
                if (vis[i] == true)
                    break;

                vis[i] = true;
                switch (words[0])
                {
                    case "nop":
                        i++;
                        break;
                    case "jmp":
                        i += int.Parse(words[1]);
                        break;
                    case "acc":
                        acc += int.Parse(words[1]);
                        i++;
                        break;
                    case "default":
                        break;
                }
            }

            Console.WriteLine(acc);
        }
    }
}
