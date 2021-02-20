using System;
using System.IO;
using System.Collections.Generic;

namespace Aoc_Day18a
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "input.txt";
            string[] lines = File.ReadAllLines(filename);

            long ret = 0;
            foreach(var line in lines)
            {
                // we add spaces before and after parenthesis
                string new_line = line.Replace("(", "( "); 
                new_line = new_line.Replace(")", " )");

                string[] words = new_line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Stack<string> s = new Stack<string>();
                foreach(var word in words)
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
                ret += long.Parse(s.Pop());
            }

            Console.WriteLine(ret);
        }
    }
}
