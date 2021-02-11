using System;
using System.IO;
using System.Linq;

namespace AoC_Day14a
{
    class Program
    {

        public static long ApplyMask(string mask, string num)
        {
            long res = 0, mult = 1;
            num = Convert.ToString(long.Parse(num), 2);

            for (int i = mask.Length - 1; i >= 0; i--)
            {
                switch(mask[i])
                {
                    case 'X':
                        int ind = num.Length - mask.Length + i;
                        res += (ind >= 0 && num[ind] == '1') ? mult : 0;
                        break;
                    case '0':
                        break;
                    case '1':
                        res += mult;
                        break;
                    default:
                        break;
                }
                mult *= 2;
            }

            return res;
        }
        static void Main(string[] args)
        {
            string filename = "input.txt";
            string[] lines = File.ReadAllLines(filename);
            string curr_mask = "";
            
            long[] vals = new long[66000];

            for(int i = 0; i < lines.Length; i++)
            {
                string[] words = lines[i].Split(new char[] { ' ', '[', ']', '=' }, 
                    StringSplitOptions.RemoveEmptyEntries);
            
                switch(words[0])
                {
                    case "mem":
                        vals[int.Parse(words[1])] = ApplyMask(curr_mask, words[2]);
                        break;
                    case "mask":
                        curr_mask = words[1];
                        break;
                    default:
                        break;
                }

                Console.WriteLine(vals.Sum());
            }

        }
    }
}
