using System;
using System.IO;

namespace AoC_Day1b
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "input.txt";
            string[] tab = File.ReadAllLines(filename);

            for (int i = 0; i < tab.Length; i++)
                for (int j = i + 1; j < tab.Length; j++)
                    for (int k = j + 1; k < tab.Length; k++)
                        if (int.Parse(tab[i]) + int.Parse(tab[j]) + int.Parse(tab[k]) == 2020)
                            Console.WriteLine(int.Parse(tab[i]) * int.Parse(tab[j]) * int.Parse(tab[k]));
        }
    }
}
