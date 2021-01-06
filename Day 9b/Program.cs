using System;
using System.IO;

namespace AoC_Day9b
{
    class Program
    {

        public static bool check(string[] lines, int ind)
        {
            int num = int.Parse(lines[ind]);
            for (int i = ind - 25; i < ind; i++)
            {
                for (int j = i + 1; j < ind; j++)
                    if (int.Parse(lines[i]) + int.Parse(lines[j]) == num)
                        return true;
            }
            return false;
        }

        public static int findSet(string[] lines, int num)
        {
            int i = 0, j = 0;
            int sum = int.Parse(lines[i]);

            while (sum != num && i <= j && j < lines.Length)
            {
                if(sum < num)
                {
                    j++;
                    sum += int.Parse(lines[j]);
                }
                else if(sum > num)
                {
                    sum -= int.Parse(lines[i]);
                    i++;
                }
            }

            int min = int.Parse(lines[i]);
            int max = min; 

            for(; i <= j; i++)
            {
                min = Math.Min(min, int.Parse(lines[i]));
                max = Math.Max(max, int.Parse(lines[i]));
            }

            return min + max; 
        }

        static void Main(string[] args)
        {
            string filename = "input.txt";
            string[] lines = File.ReadAllLines(filename);

            int num = 0;
            for (int i = 25; i < lines.Length; i++)
                if (!check(lines, i))
                {
                    num = int.Parse(lines[i]);
                    break;
                }

            Console.WriteLine(findSet(lines, num)); 
        }
    }
}
