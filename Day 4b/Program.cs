using System;
using System.IO;

namespace AoC_Day4b
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "input.txt";
            string[] lines = File.ReadAllLines(filename);

            bool byr, iyr, eyr, hgt, hcl, ecl, pid;
            byr = iyr = eyr = hgt = hcl = ecl = pid = false;
            int val, ret = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] != "")
                {
                    string[] words = lines[i].Split(' ');
                    for (int j = 0; j < words.Length; j++)
                        switch (words[j][0..3])
                        {
                            case "byr":
                                val = int.Parse(words[j][4..8]);
                                if(val >= 1920 && val <= 2002)
                                    byr = true;
                                break;

                            case "iyr":
                                val = int.Parse(words[j][4..8]);
                                if(val >= 2010 && val <= 2020)
                                    iyr = true;
                                break;

                            case "eyr":
                                val = int.Parse(words[j][4..8]);
                                if(val >= 2020 && val <= 2030)
                                    eyr = true;
                                break;

                            case "hgt":
                                if(words[j][^2..] == "in")
                                {
                                    val = int.Parse(words[j][4..^2]);
                                    if (val >= 59 && val <= 76)
                                        hgt = true;
                                }
                                else if(words[j][^2..] == "cm")
                                {
                                    val = int.Parse(words[j][4..^2]);
                                    if (val >= 150 && val <= 193)
                                        hgt = true;
                                }
                                break;

                            case "hcl":
                                if(words[j][4] == '#')
                                {
                                    string number = words[j][5..];
                                    if (number.Length == 6)
                                        hcl = int.TryParse(number,
                                            System.Globalization.NumberStyles.HexNumber,
                                            null, out _);
                                }
                                break;

                            case "ecl":
                                string word = words[j][4..];
                                if (word == "amb" || word == "blu" ||
                                    word == "brn" || word == "gry" ||
                                    word == "grn" || word == "hzl" ||
                                    word == "oth")
                                    ecl = true;
                                break;

                            case "pid":
                                if(words[j][4..].Length == 9)
                                    pid = true;
                                break;

                            default:
                                break;
                        }
                }
                if (lines[i] == "" || i == lines.Length - 1)
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
