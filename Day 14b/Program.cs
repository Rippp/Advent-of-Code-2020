using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC_Day14b
{
    class Program
    {
        public static long LongPow(long x, long pow)
        {
            long ret = 1;
            while (pow != 0)
            {
                if ((pow & 1) == 1)
                    ret *= x;
                x *= x;
                pow >>= 1;
            }
            return ret;
        }

        public static List<long> ParseMask(string mask)
        {
            List<long> pos = new List<long>();

            for (int i = mask.Length - 1; i >= 0; i--)
                if (mask[i] == 'X')
                    pos.Add(LongPow(2, mask.Length - 1 - i));

            return pos;
        }

        public static void AddValue(long[] vals, Dictionary<long, int> dict, List<long> pos, 
            string mem, string val, string mask, ref int count)
        {
            // The value we are setting 
            long long_val = long.Parse(val);
            // The binary string of memory adress
            mem = Convert.ToString(long.Parse(mem), 2);

            // First we apply the non 'X' bits of the mask
            // to the address
            long mem_pos = 0, mult = 1;
            for(int i = mask.Length - 1; i >= 0; i--)
            {
                if (mask[i] != 'X')
                {
                    if (mask[i] == '1')
                        mem_pos += mult;
                    else
                    {
                        int ind = mem.Length - mask.Length + i;
                        mem_pos += (ind >= 0 && mem[ind] == '1') ? mult : 0;
                    }
                }
                mult *= 2;
            }

            // Generate all possible combinations of the 'X' bits
            for(long i = 0; i <= LongPow(2, pos.Count) - 1; i++)
            {
                string bin = Convert.ToString(i, 2).PadLeft(pos.Count, '0');
                long temp_val = 0;
                for(int j = 0; j < bin.Length; j++)
                {
                    if (bin[j] == '1')
                        temp_val += pos[j];
                }

                // We use dictionary to renumerate the 
                // memory positions
                mem_pos += temp_val;
                if (!dict.ContainsKey(mem_pos))
                {
                    dict.Add(mem_pos, count++);
                }
                vals[dict[mem_pos]] = long_val;
                mem_pos -= temp_val;
            }

        }

        static void Main(string[] args)
        {
            string filename = "input.txt";
            string[] lines = File.ReadAllLines(filename);
            string curr_mask = "";

            long[] vals = new long[90000];
            var dict = new Dictionary<long, int>();
            int count = 0;

            // list of floating bits values
            List<long> pos = new List<long>();

            foreach(var line in lines)
            {
                string[] words = line.Split(new char[] { ' ', '=', '[', ']' },
                    StringSplitOptions.RemoveEmptyEntries);

                if (words[0] == "mask")
                {
                    pos = ParseMask(words[1]);
                    curr_mask = words[1];
                }
                else
                    AddValue(vals, dict, pos, words[1], words[2], curr_mask, ref count);
            }

            Console.WriteLine(vals.Sum());
        }
    }
}
