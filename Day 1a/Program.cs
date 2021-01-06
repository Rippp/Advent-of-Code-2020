using System;
using System.IO;

namespace AoC_Day1a
{
    class Program
    {

        static void Main(string[] args)
        {
            string filename = "input.txt";
            string[] tab = File.ReadAllLines(filename);

            for (int i = 1; i < tab.Length; i++)
                for (int j = i + 1; j < tab.Length; j++)
                    if (int.Parse(tab[i]) + int.Parse(tab[j]) == 2020)
                        Console.WriteLine(int.Parse(tab[i]) * int.Parse(tab[j]));

        }
    }
}
