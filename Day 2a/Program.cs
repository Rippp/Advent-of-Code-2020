using System;
using System.IO;

namespace AoC_Day2a
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "input.txt";
            string[] tab = File.ReadAllLines(filename);

            int res = 0;
            for(int i = 0; i < tab.Length; i++)
            {
                string[] words = tab[i].Split('-', ' ', ':');
                int a = int.Parse(words[0]);
                int b = int.Parse(words[1]);

                int count = 0;
                for (int j = 0; j < words[4].Length; j++)
                {
                    if (words[4][j] == words[2][0])
                        count++;
                }
  
                if (count >= a && count <= b)
                    res++;
            }

            Console.WriteLine(res);
        }
    }
}
