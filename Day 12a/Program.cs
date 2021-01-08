using System;
using System.IO;

namespace AoC_Day12a
{
    class Program
    {
        public enum dir: int
        {
            N = 0,
            E = 1,
            S = 2,
            W = 3
        }

        public static void process_lines(string[] lines)
        {
            int[] dist = new int[4];
            dir F = dir.E;
            int arg;

            for (int i = 0; i < lines.Length; i++)
            {
                arg = int.Parse(lines[i][1..]);
                switch (lines[i][0])
                {
                    case 'N':
                        dist[(int)dir.N] += arg;
                        break;
                    case 'S':
                        dist[(int)dir.S] += arg;
                        break;
                    case 'E':
                        dist[(int)dir.E] += arg;
                        break;
                    case 'W':
                        dist[(int)dir.W] += arg;
                        break;
                    case 'F':
                        dist[(int)F] += arg;
                        break;
                    case 'L':
                        for (int j = 0; j < arg; j += 90)
                        {
                            F--;
                            if (F < 0) F = dir.W;
                        }
                        break;
                    case 'R':
                        for (int j = 0; j < arg; j += 90)
                        {
                            F++;
                            if (F > dir.W) F = dir.N;
                        }
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(Math.Abs(dist[(int)dir.N] - dist[(int)dir.S]) +
                              Math.Abs(dist[(int)dir.E] - dist[(int)dir.W]));
        }

        static void Main(string[] args)
        {
            string filename = "input.txt";
            string[] lines = File.ReadAllLines(filename);
            process_lines(lines);
        }
    }
}
