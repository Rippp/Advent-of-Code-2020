using System;
using System.IO;
using System.Collections.Generic;

namespace AoC_Day17b
{
    class Program
    {
        const int ACTIVE = 1;
        const int INACTIVE = 0;
        static void MakeActive(ref Dictionary<string, int> game, int x, int y, int z, int w)
        {
            game[$"{x},{y},{z},{w}"] = ACTIVE;

            for (int i = -1; i <= 1; i++)
                for (int j = -1; j <= 1; j++)
                    for (int k = -1; k <= 1; k++)
                        for(int l = -1; l <= 1; l++)
                        if (!game.ContainsKey($"{x + i},{y + j},{z + k},{w + l}"))
                            MakeInactive(ref game, x + i, y + j, z + k, w + l);
        }
        static void MakeInactive(ref Dictionary<string, int> game, int x, int y, int z, int w)
        {
            game[$"{x},{y},{z},{w}"] = INACTIVE;
        }

        static int CountActiveNeighbours(ref Dictionary<string, int> game, int x, int y, int z, int w)
        {
            int ret = 0;
            for (int i = -1; i <= 1; i++)
                for (int j = -1; j <= 1; j++)
                    for (int k = -1; k <= 1; k++)
                        for(int l = -1; l <= 1; l++)
                            if (i != 0 || j != 0 || k != 0 || l != 0)
                                if (game.ContainsKey($"{x + i},{y + j},{z + k},{w + l}") &&
                                    game[$"{x + i},{y + j},{z + k},{w + l}"] == ACTIVE)
                                    ret++;
            return ret;
        }

        static void GameLoop(ref Dictionary<string, int> game, int cycles)
        {
            for (int i = 0; i < cycles; i++)
            {
                Dictionary<string, int> game_copy = new Dictionary<string, int>(game);
                foreach (var key in game_copy.Keys)
                {
                    string[] words = key.Split(',');
                    int x = int.Parse(words[0]);
                    int y = int.Parse(words[1]);
                    int z = int.Parse(words[2]);
                    int w = int.Parse(words[3]);

                    int c = CountActiveNeighbours(ref game_copy, x, y, z, w);
                    if (game_copy[$"{x},{y},{z},{w}"] == ACTIVE && c != 2 && c != 3)
                        MakeInactive(ref game, x, y, z, w);
                    else if (game_copy[$"{x},{y},{z},{w}"] == INACTIVE && c == 3)
                        MakeActive(ref game, x, y, z, w);
                }
            }
        }
        static void Main(string[] args)
        {
            string filename = "input.txt";
            string[] lines = File.ReadAllLines(filename);

            Dictionary<string, int> game = new Dictionary<string, int>();
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (lines[i][j] == '#')
                        MakeActive(ref game, j, i, 0, 0);
                }
            }

            GameLoop(ref game, 6);

            int ret = 0;
            foreach (var val in game.Values)
                if (val == ACTIVE)
                    ret++;

            Console.WriteLine(ret);
        }
    }
}
