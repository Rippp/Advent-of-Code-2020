using System;
using System.IO;
using System.Linq;

namespace AoC_Day10b
{
    class Program
    {
        public static void count(int[] adap)
        {
            long[] dp = new long[adap.Length];
            dp[0] = 1;
            dp[1] = 1;
            dp[2] = 1;

            if (adap[2] - adap[0] <= 3) dp[2] += dp[0];

            for(int i = 3; i < dp.Length; i++)
            {
                dp[i] = dp[i - 1];

                if (adap[i] - adap[i - 2] <= 3)
                    dp[i] += dp[i - 2];
                if (adap[i] - adap[i - 3] <= 3)
                    dp[i] += dp[i - 3];
            }

            Console.WriteLine(dp[^1]);
        }
        static void Main(string[] args)
        {
            string filename = "input.txt";
            string[] input = File.ReadAllLines(filename);

            int[] adap = new int[input.Length + 2];
            for (int i = 0; i < input.Length; i++)
                adap[i] = int.Parse(input[i]);
            adap[adap.Length - 2] = 0;
            adap[adap.Length - 1] = adap.Max() + 3;
            Array.Sort(adap);

            count(adap);
        }
    }
}
