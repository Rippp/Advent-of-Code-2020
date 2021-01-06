using System;
using System.IO;
using System.Collections;

namespace AoC_Day10a
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "input.txt";
            string[] input = File.ReadAllLines(filename);

            int[] adap = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
                adap[i] = int.Parse(input[i]);

            Array.Sort(adap);
            int diff1 = 0, diff3 = 1;
            
            if (adap[0] == 1) diff1++;
            else if (adap[0] == 3) diff3++;

            for (int i = 1; i < adap.Length; i++)
            {
                if (adap[i] - adap[i - 1] == 1)
                    diff1++;
                else if (adap[i] - adap[i - 1] == 3)
                    diff3++;
            }

            Console.WriteLine($"{diff1} {diff3} - {diff1 * diff3}");
        }
    }
}
