using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AoC_Day20a
{
    class Program
    {
        static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        static string[] GetBorders(int tile_id, ref Dictionary<int, List<string>> tiles)
        {
            string[] borders = new string[4];

            borders[0] = tiles[tile_id][0];
            borders[1] = tiles[tile_id][^1];
            borders[2] = "";
            borders[3] = "";

            foreach(var line in tiles[tile_id])
            {
                borders[2] += line[0];
                borders[3] += line[^1];
            }

            return borders;
        }
        static bool CheckIfCorner(int tile_id, ref Dictionary<int, List<string>> tiles)
        {
            int dist_borders = 4;
            string[] tile_id_borders = GetBorders(tile_id, ref tiles);

            foreach(var tile in tiles.Keys)
            {
                int same_borders = 0;
                string[] borders = GetBorders(tile, ref tiles);

                if (tile_id != tile)
                {
                    foreach (var border1 in tile_id_borders)
                        foreach (var border2 in borders)
                            if (border1 == border2 || border1 == Reverse(border2))
                                same_borders++;
                }
                dist_borders -= same_borders;
            }
            return dist_borders == 2;
        }
        static void Main(string[] args)
        {
            string filename = "input.txt";
            string[] lines = File.ReadAllLines(filename);

            Dictionary<int, List<string>> tiles = new Dictionary<int, List<string>>();
            int current_id = 0;
            foreach (var line in lines)
            {
                if (line.Contains("Tile"))
                {
                    current_id = int.Parse(
                        line.Split(new char[] { ' ', ':' }, StringSplitOptions.RemoveEmptyEntries).Last());

                    tiles[current_id] = new List<string>();
                }
                else if (line.Contains('.') || line.Contains('#'))
                    tiles[current_id].Add(line);
            }

            // Corner tiles are the only tiles that have exactly 
            // two borders that don't line up with any other file
            long ret = 1;
            foreach (var tile in tiles.Keys)
                if (CheckIfCorner(tile, ref tiles))
                    ret *= tile;

            Console.WriteLine(ret);
        }
    }
}
