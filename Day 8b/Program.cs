using System;
using System.IO;

namespace AoC_Day8b
{
    class Program
    {
        static public (bool, int) check(string[] lines)
        {
            bool[] vis = new bool[lines.Length];
            int acc = 0;
            for (int i = 0; i < lines.Length;)
            {
                string[] words = lines[i].Split(' ');
                if (vis[i] == true)
                    return (false, 0);

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
            return (true, acc);
        }
        static void Main(string[] args)
        {
            string filename = "input.txt";
            string[] lines = File.ReadAllLines(filename);

            for(int i = 0; i < lines.Length; i++)
            {
                string[] words = lines[i].Split(' ');
                string oldLine = lines[i];
                if(words[0] == "nop" && words[1] != "+0")
                {
                    lines[i] = lines[i].Replace("nop", "jmp");
                }
                else if(words[0] == "jmp")
                {
                    lines[i] = lines[i].Replace("jmp", "nop");
                }

                var ret = check(lines);
                if (ret.Item1)
                {
                    Console.WriteLine(ret.Item2);
                    break;
                }
                else
                {
                    lines[i] = oldLine;
                }
            }

        }
    }
}
