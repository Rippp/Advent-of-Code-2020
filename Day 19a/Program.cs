using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC_Day19a
{
    class Program
    {
        static int CountRules(string[] lines)
        {
            int ret = 0;
            foreach (var line in lines)
                if (line == "")
                    break;
                else
                    ret++;

            return ret;
        }
        static void SortRules(ref string[] lines, int rule_num)
        {
            var temp = lines[..rule_num].OrderBy(x => { return int.Parse(x.Split(':').First()); }).ToArray();

            for (int i = 0; i < rule_num; i++)
                lines[i] = temp[i];
        }
        static void InitiateDict(ref Dictionary<int, List<string>> dict, int rule_num)
        {
            for (int i = 0; i < rule_num; i++)
                dict.Add(i, new List<string>());
        }
        static void ParseRule(ref Dictionary<int, List<string>>dict, string[] lines, int rule)
        {
            // We already parsed that rule
            if (dict[rule].Count > 0)
                return;

            // Rule contains a letter
            if (lines[rule].Contains('"'))
            {
                dict[rule].Add(lines[rule].Substring(lines[rule].IndexOf('"') + 1, 1));
                return;
            }

            // Rule contains multiple sets of rules
            if(lines[rule].Contains('|'))
            {
                string[] sets = lines[rule][(lines[rule].IndexOf(':')+1)..].Split('|');
                foreach (var set in sets)
                {
                    string[] rule_nums = set.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    // Recursively parse each member of rule set
                    foreach (var rule_num in rule_nums)
                        ParseRule(ref dict, lines, int.Parse(rule_num));


                    // Concatenate subrule strings
                    // There are always one or two rule numbers so we just hardcode it 
                    if (rule_nums.Length == 2)
                        foreach (var s1 in dict[int.Parse(rule_nums[0])])
                            foreach (var s2 in dict[int.Parse(rule_nums[1])])
                                dict[rule].Add(s1 + s2);
                    else
                        foreach (var s in dict[int.Parse(rule_nums[0])])
                            dict[rule].Add(s);
                }
            }
            // Rule contains only one set of rules
            else
            {
                string[] set = lines[rule][(lines[rule].IndexOf(':') + 1)..].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                
                // Recursively parse each member of rule set
                foreach (var rule_num in set)
                    ParseRule(ref dict, lines, int.Parse(rule_num));

                // There are always one or two rule numbers so we just hardcode it 
                if (set.Length == 2)
                    foreach (var s1 in dict[int.Parse(set[0])])
                        foreach (var s2 in dict[int.Parse(set[1])])
                            dict[rule].Add(s1 + s2);
                else
                    foreach (var s in dict[int.Parse(set[0])])
                        dict[rule].Add(s);
            }

        }
        static void Main(string[] args)
        {
            string filename = "input.txt";
            string[] lines = File.ReadAllLines(filename);

            int rule_num = CountRules(lines);
            SortRules(ref lines, rule_num);
            Dictionary<int, List<string>> dict = new Dictionary<int, List<string>>();
            InitiateDict(ref dict, rule_num);
            ParseRule(ref dict, lines, 0);

            int ret = 0;
            for (int i = rule_num + 1; i < lines.Length; i++)
                if (dict[0].Contains(lines[i]))
                    ret++;

            Console.WriteLine(ret);
        }
    }
}
