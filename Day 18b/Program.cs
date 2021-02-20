using System;
using System.IO;
using System.Collections.Generic;

namespace Aoc_Day18b
{
    class Program
    {

        static string AddParenthesisAroundPlus(string line)
        {
            for(int i = 0; i < line.Length; i++)
            {
                if(line[i] == '+')
                {
                    // We add parenthesis before the first product
                    if (line[i - 2] == ')')
                    {
                        int j = i - 3;
                        int t = 1; //number of "open" parenthesis
                        while (t != 0)
                        {
                            if (line[j] == ')')
                                t++;
                            else if (line[j] == '(')
                                t--;
                            j--;
                        }

                        line = line[..(j + 1)] + "(" + line[(j + 1)..];
                    }
                    else 
                    {
                        line = line[..(i - 2)] + "(" + line[(i - 2)..];
                    }

                    // We increment the i because we added a single character before current index
                    i++;

                    // We add parenthesis after the first product
                    if (line[i+2] == '(')
                    {
                        int j = i + 3;
                        int t = 1; // number of "open" parenthesis
                        while(t != 0)
                        {
                            if (line[j] == ')')
                                t--;
                            else if (line[j] == '(')
                                t++;
                            j++;
                        }

                        line = line[..j] + ")" + line[j..];
                    }
                    else // At position i+2 is a number
                    {
                        line = line[..(i + 3)] + ")" + line[(i + 3)..];
                    }
                }
            }
            return line;
        }
        static void Main(string[] args)
        {
            string filename = "input.txt";
            string[] lines = File.ReadAllLines(filename);

            long ret = 0;
            foreach (var line in lines)
            {
                string new_line = AddParenthesisAroundPlus(line);
                // we add spaces before and after parenthesis
                new_line = new_line.Replace("(", "( ");
                new_line = new_line.Replace(")", " )");
                Console.WriteLine($"Old_line: {line} \n New_line: {new_line}");

                string[] words = new_line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Stack<string> s = new Stack<string>();
                foreach (var word in words)
                {
                    if (word == "+" || word == "*" || word == "(")
                        s.Push(word);
                    else if (word == ")")
                    {
                        string top = s.Pop(); // we pop the number on top
                        s.Pop(); // we pop the "("

                        // if there is "+" or "*" on top
                        if (s.Count != 0 && s.Peek() != "(")
                        {
                            string op = s.Pop(); // we pop the "+" or "*"
                            long t = long.Parse(top);

                            if (op == "+")
                                t += long.Parse(s.Pop());
                            else
                                t *= long.Parse(s.Pop());

                            s.Push(Convert.ToString(t));
                        }
                        else
                            s.Push(top);
                    }
                    else //it's a number
                    {
                        if (s.Count == 0 || s.Peek() == "(")
                            s.Push(word);
                        else
                        {
                            long t = long.Parse(word);
                            string op = s.Pop();

                            if (op == "+")
                                t += long.Parse(s.Pop());
                            else
                                t *= long.Parse(s.Pop());

                            s.Push(Convert.ToString(t));
                        }
                    }

                }
                Console.WriteLine($"Result: {s.Peek()}");
                ret += long.Parse(s.Pop());
            }

            Console.WriteLine(ret);
        }
    }
}
