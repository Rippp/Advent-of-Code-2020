using System;
using System.IO;

namespace AoC_Day11b
{
    class Program
    {

        public enum seat
        {
            floor,
            empty,
            occ
        }
        public static void fill_seats(seat[,] seats, string[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                    switch (input[i][j])
                    {
                        case 'L':
                            seats[i, j] = seat.empty;
                            break;
                        case '.':
                            seats[i, j] = seat.floor;
                            break;
                        case '#':
                            seats[i, j] = seat.occ;
                            break;
                        default:
                            break;
                    }
            }
        }

        public static int count_occ(int i, int j, seat[,] seats)
        {
            int pi, pj;
            int occ = 0;
            int imax = seats.GetLength(0), jmax = seats.GetLength(1);

            // up, down, left, right check
            pi = i - 1;
            while(pi >= 0)
            {
                if(seats[pi, j] == seat.occ)
                {
                    occ++;
                    break;
                }
                if (seats[pi, j] == seat.floor) pi--;
                else break;
            }

            pi = i + 1; 
            while(pi < imax)
            {
                if(seats[pi, j] == seat.occ)
                {
                    occ++;
                    break; 
                }
                if (seats[pi, j] == seat.floor) pi++;
                else break;
            }

            pj = j - 1;
            while (pj >= 0)
            {
                if (seats[i, pj] == seat.occ)
                {
                    occ++;
                    break;
                }
                if (seats[i, pj] == seat.floor) pj--;
                else break;
            }

            pj = j + 1;
            while (pj < jmax)
            {
                if (seats[i, pj] == seat.occ)
                {
                    occ++;
                    break;
                }
                if (seats[i, pj] == seat.floor) pj++;
                else break;
            }

            // diagonal check
            pi = i - 1; pj = j - 1;
            while(pi >= 0 && pj >= 0)
            {
                if(seats[pi, pj] == seat.occ)
                {
                    occ++;
                    break;
                }
                if (seats[pi, pj] == seat.floor) { pi--; pj--; }
                else break;
            }

            pi = i + 1; pj = j + 1;
            while (pi < imax && pj < jmax)
            {
                if (seats[pi, pj] == seat.occ)
                {
                    occ++;
                    break;
                }
                if (seats[pi, pj] == seat.floor) { pi++; pj++; }
                else break;
            }

            pi = i - 1; pj = j + 1;
            while (pi >= 0 && pj < jmax)
            {
                if (seats[pi, pj] == seat.occ)
                {
                    occ++;
                    break;
                }
                if (seats[pi, pj] == seat.floor) { pi--; pj++; }
                else break;
            }

            pi = i + 1; pj = j - 1;
            while (pi < imax && pj >= 0)
            {
                if (seats[pi, pj] == seat.occ)
                {
                    occ++;
                    break;
                }
                if (seats[pi, pj] == seat.floor) { pi++; pj--; }
                else break;
            }
            return occ;
        }

        public static void print_seats(seat[,] seats)
        {
            Console.Write('\n');
            for(int i = 0; i < seats.GetLength(0); i++)
            {
                for(int j = 0; j < seats.GetLength(1); j++)
                    switch(seats[i, j])
                    {
                        case seat.empty:
                            Console.Write('L');
                            break;
                        case seat.floor:
                            Console.Write('.');
                            break;
                        case seat.occ:
                            Console.Write('#');
                            break;
                        default:
                            break;
                    }
                Console.Write('\n');
            }
        }
        public static void run_simulation(seat[,] seats)
        {
            bool sth_changed = true;
            seat[,] prev_seats;

            while (sth_changed)
            {
                // DEBUG:
                //print_seats(seats);
                sth_changed = false;
                prev_seats = seats.Clone() as seat[,];

                for (int i = 0; i < seats.GetLength(0); i++)
                    for (int j = 0; j < seats.GetLength(1); j++)
                    {
                        if (prev_seats[i, j] == seat.empty && count_occ(i, j, prev_seats) == 0)
                        {
                            seats[i, j] = seat.occ;
                            sth_changed = true;
                        }
                        else if (prev_seats[i, j] == seat.occ && count_occ(i, j, prev_seats) > 4)
                        {
                            seats[i, j] = seat.empty;
                            sth_changed = true;
                        }
                    }
            }
        }

        public static int count_all_occ(seat[,] seats)
        {
            int occ = 0;
            for (int i = 0; i < seats.GetLength(0); i++)
            {
                for (int j = 0; j < seats.GetLength(1); j++)
                {
                    if (seats[i, j] == seat.occ) occ++;
                }
            }

            return occ;
        }

        static void Main(string[] args)
        {
            string filename = "input.txt";
            string[] input = File.ReadAllLines(filename);

            seat[,] seats = new seat[input.Length, input[0].Length];
            fill_seats(seats, input);
            run_simulation(seats);
            Console.WriteLine(count_all_occ(seats));
        }
    }
}
