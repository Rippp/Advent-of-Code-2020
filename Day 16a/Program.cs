using System;
using System.IO;

namespace AoC_Day16a
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "input.txt";
            string[] lines = File.ReadAllLines(filename);

            // First we count the number of parameters 
            int i = 0;
            for (; i < lines.Length; i++)
                if (lines[i] == "")
                    break;

            // We reserve the memory
            int[ , ] pars = new int[i, 4];

            // We read the values of the parameters
            for(i = 0; i < lines.Length; i++)
            {
                if (lines[i] == "")
                    break;

                string[] words = lines[i].Split(new char[] { ' ', '-' }, 
                        StringSplitOptions.RemoveEmptyEntries);

                pars[i, 0] = int.Parse(words[^5]); // 1st min
                pars[i, 1] = int.Parse(words[^4]); // 1st max
                pars[i, 2] = int.Parse(words[^2]); // 2nd min
                pars[i, 3] = int.Parse(words[^1]); // 2nd max
            }

            i+=5; // Skip to "nearby tickets" 

            // Check the correctness of the nearby tickets
            int error_rate = 0;
            for(; i < lines.Length; i++)
            {
                string[] words = lines[i].Split(',');

                for(int j = 0; j < words.Length; j++)
                {
                    int num = int.Parse(words[j]);
                    bool valid = false; 
                    for(int k = 0; k < pars.GetLength(0); k++)
                    {
                        if ((num >= pars[k, 0] && num <= pars[k, 1]) ||
                            (num >= pars[k, 2] && num <= pars[k, 3]))
                        {
                            valid = true;
                            break;
                        }
                    }

                    if (!valid)
                    {
                        error_rate += num;
                        break;
                    }
                }
            }

            Console.WriteLine(error_rate);
        }
    }
}
