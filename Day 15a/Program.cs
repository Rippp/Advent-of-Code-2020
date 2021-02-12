using System;
using System.Collections.Generic;

namespace AoC_Day15a
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<long, long> dict = new Dictionary<long, long>();

            dict.Add(19, 1);
            dict.Add(0, 2);
            dict.Add(5, 3);
            dict.Add(1, 4);
            dict.Add(10, 5);

            long last_num = 13;
            for (long i = 6; i < 2020; i++)
            {
                if (dict.ContainsKey(last_num))
                {
                    long t = last_num;
                    last_num = i - dict[last_num];
                    dict[t] = i;
                }
                else
                {
                    dict.Add(last_num, i);
                    last_num = 0;
                }
            }

            Console.WriteLine(last_num);
        }
    }
}
