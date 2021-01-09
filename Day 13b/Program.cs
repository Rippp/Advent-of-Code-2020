using System;
using System.IO;

namespace AoC_Day13b
{
    class Program
    {
        static void gcdExtended(long a, long b, ref long x, ref long y)
        {
            if(a == 0)
            {
                x = 0;
                y = 1;
                return;
            }

            long x1 = 0, y1 = 0;
            gcdExtended(b % a, a, ref x1, ref y1);

            x = y1 - (b / a) * x1;
            y = x1;
        }
        static void CRT(long[] nums, long[] rem)
        {
            long M = 1, x = 0, y = 0, sol = 0;
            foreach (long num in nums)
                M *= num;

            for(int i = 0; i < nums.Length; i++)
            {
                M /= nums[i];
                gcdExtended(nums[i], M, ref x, ref y);
                sol += rem[i] * M * y;
                M *= nums[i];
            }

            // we iterate through solutions to find
            // the smallest positive solution
            while (sol >= 0) sol -= M;
            while (sol <= 0) sol += M;

            Console.WriteLine(sol);
        }

        static void Main(string[] args)
        {
            string filename = "input.txt";
            string[] lines = File.ReadAllLines(filename);
            lines = lines[1].Split(',');
            int count = 0, curr_rem = 0;
            
            foreach(string line in lines)
            {
                if (line != "x")
                    count++;
            }

            // First we extract the numbers from input 
            // and calculate remainders for each number
            long[] nums = new long[count];
            long[] rem = new long[count];
            count = 0;
            foreach (string line in lines)
            {
                if (line != "x")
                {
                    nums[count] = long.Parse(line);
                    rem[count] = (curr_rem % nums[count]) == 0 ? 0 : nums[count] - (curr_rem % nums[count]);
                    count++;
                }
                curr_rem++;
            }

            // we apply the chinese remainder theorem
            CRT(nums, rem);
        }
    }
}
