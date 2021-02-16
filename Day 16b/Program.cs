using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AoC_Day16b
{
    class Program
    {
        static void ReadParams(ref int[,] pars, string[] lines, ref int i)
        {
            // First we count how many params are there
            i = 0;
            for (; i < lines.Length; i++)
                if (lines[i] == "")
                    break;

            // We reserve memory for params
            pars = new int[i, 4];

            // We read params values
            for (i = 0; i < lines.Length; i++)
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
        }

        static Dictionary<int, List<int>> ValidateTickets(int[,] pars, string[] lines, ref int i)
        {
            i += 5; // Skip to "nearby tickets" 
            List<string> tickets = new List<string>
            {
                lines[i - 3] // Add "your ticket"
            };

            // We check the correctness of values
            for (; i < lines.Length; i++)
            {
                string[] words = lines[i].Split(',');
                bool valid_ticket = false;

                for (int j = 0; j < words.Length; j++)
                {
                    int num = int.Parse(words[j]);
                    valid_ticket = false;

                    for (int k = 0; k < pars.GetLength(0); k++)
                    {
                        if ((num >= pars[k, 0] && num <= pars[k, 1]) ||
                            (num >= pars[k, 2] && num <= pars[k, 3]))
                        {
                            valid_ticket = true;
                            break;
                        }
                    }
                    if (!valid_ticket)
                        break;
                }
                if (valid_ticket)
                    tickets.Add(lines[i]);
            }

            // transform string tickets to lists of numbers
            Dictionary<int, List<int>> ret = new Dictionary<int, List<int>>();
            for(i = 0; i < tickets.Count; i++)
            {
                string[] words = tickets[i].Split(',');
                ret.Add(i, new List<int>());

                foreach (var word in words)
                    ret[i].Add(int.Parse(word));
            }

            return ret;
        }

        static Dictionary<int, int> AssignParams(int[,] pars, Dictionary<int, List<int>> valid_tickets)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            List<List<int>> solutions = new List<List<int>>();

            // First we create a solution based on our ticket
            for(int i = 0; i < valid_tickets[0].Count; i++)
            {
                solutions.Add(new List<int>());

                for(int j = 0; j < pars.GetLength(0); j++)
                    if ((valid_tickets[0][i] >= pars[j, 0] && valid_tickets[0][i] <= pars[j, 1]) ||
                        (valid_tickets[0][i] >= pars[j, 2] && valid_tickets[0][i] <= pars[j, 3]))
                        solutions[i].Add(j);
            }


            // Then we remove solutions that doesn't match other tickets
            for(int i = 1; i < valid_tickets.Count; i++)
            {
                for(int j = 0; j < valid_tickets[i].Count; j++)
                {
                    List<int> to_remove = new List<int>();
                    foreach(int sol in solutions[j])
                    {
                        if (!((valid_tickets[i][j] >= pars[sol, 0] && valid_tickets[i][j] <= pars[sol, 1]) ||
                              (valid_tickets[i][j] >= pars[sol, 2] && valid_tickets[i][j] <= pars[sol, 3])))
                        {
                            to_remove.Add(sol);
                        }
                    }

                    foreach (int x in to_remove)
                        solutions[j].Remove(x);
                }
            }

            // Now we need to pick the best solution
            List<int> remaining = new List<int>();
            for (int i = 0; i < pars.GetLength(0); i++) remaining.Add(i);

            while(remaining.Count != 0)
            {
                int x = 0;
                foreach(int rem in remaining)
                {
                    x = rem;
                    if(solutions[rem].Count == 1)
                    {
                        int num = solutions[rem][0];
                        dict.Add(rem, num);

                        foreach (var val in solutions)
                            val.Remove(num);
                        break;
                    }
                }
                remaining.Remove(x);
            }

            return dict; 
        }

        static void Main(string[] args)
        {
            string filename = "input.txt";
            string[] lines = File.ReadAllLines(filename);
            int[,] pars = new int[0, 0];
            int i = 0;

            ReadParams(ref pars, lines, ref i);
            Dictionary<int, List<int>> valid_tickets = ValidateTickets(pars, lines, ref i);

            // number in order - number of corresponding parameter
            Dictionary<int, int> dict = AssignParams(pars, valid_tickets);

            long ret = 1;
            for (i = 0; i < pars.GetLength(0); i++)
                if (dict[i] < 6)
                    ret *= valid_tickets[0][i];

            Console.WriteLine(ret);
        }
    }
}
