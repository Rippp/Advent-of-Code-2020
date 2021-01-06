using System;
using System.IO;

namespace AoC_Day4a
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "input.txt";
            string[] lines = File.ReadAllLines(filename);

            bool byr, iyr, eyr, hgt, hcl, ecl, pid;
            byr = iyr = eyr = hgt = hcl = ecl = pid = false;
            int ret = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] != "")
                {
                    string[] words = lines[i].Split(' ');
                    for (int j = 0; j < words.Length; j++)
                        switch(words[j][0..3])
                        {
                            case "byr":
                                byr = true;
                                break;
                            case "iyr":
                                iyr = true;
                                break;
                            case "eyr":
                                eyr = true;
                                break;
                            case "hgt":
                                hgt = true;
                                break;
                            case "hcl":
                                hcl = true;
                                break;
                            case "ecl":
                                ecl = true;
                                break;
                            case "pid":
                                pid = true;
                                break;
                            default:
                                break;
                        }
                }
                if(lines[i] == "" || i == lines.Length - 1)
                {
                    if (byr && iyr && eyr && hgt && hcl && ecl && pid)
                        ret++;

                    byr = iyr = eyr = hgt = hcl = ecl = pid = false;
                }
            }

            Console.WriteLine(ret);
        }
    }
}
