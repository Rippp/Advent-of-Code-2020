using System;
using System.IO;

namespace AoC_Day12b
{
    class Program
    {
        static void swap<T>(ref T a, ref T b)
        {
            T c = a;
            a = b;
            b = c; 
        }

        public static void process_lines(string[] lines)
        {
            int x = 0, y = 0;
            int way_x = 10, way_y = 1;
            int arg;

            for (int i = 0; i < lines.Length; i++)
            {
                arg = int.Parse(lines[i][1..]);
                switch (lines[i][0])
                {
                    case 'N':
                        way_y += arg;
                        break;
                    case 'S':
                        way_y -= arg;
                        break;
                    case 'E':
                        way_x += arg;
                        break;
                    case 'W':
                        way_x -= arg;
                        break;
                    case 'F':
                        x += way_x * arg;
                        y += way_y * arg;
                        break;
                    case 'L':
                        for(int j = 0; j < arg; j += 90)
                        {
                            swap<int>(ref way_x, ref way_y);
                            way_x = -way_x;
                        }
                        break;
                    case 'R':
                        for (int j = 0; j < arg; j += 90)
                        {
                            swap<int>(ref way_x, ref way_y);
                            way_y = -way_y;
                        }
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine(Math.Abs(x) + Math.Abs(y));
        }

        static void Main(string[] args)
        {
            string filename = "input.txt";
            string[] lines = File.ReadAllLines(filename);
            process_lines(lines);
        }
    }
}
