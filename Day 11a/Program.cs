using System;
using System.IO;

namespace AoC_Day11a
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
            for(int i = 0; i < input.Length; i++)
            {
                for(int j = 0; j < input[i].Length; j++)
                    switch(input[i][j])
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
            int occ = 0;
            int imax = seats.GetLength(0), jmax = seats.GetLength(1);
            
            // diagonal check
            if (i - 1 >= 0 && j - 1 >= 0 && seats[i - 1, j - 1] == seat.occ) occ++;
            if (i - 1 >= 0 && j + 1 < jmax && seats[i - 1, j + 1] == seat.occ) occ++;
            if (i + 1 < imax && j - 1 >= 0 && seats[i + 1, j - 1] == seat.occ) occ++;
            if (i + 1 < imax && j + 1 < jmax && seats[i + 1, j + 1] == seat.occ) occ++;

            // up, down, left, right check
            if (i - 1 >= 0 && seats[i - 1, j] == seat.occ) occ++;
            if (i + 1 < imax && seats[i + 1, j] == seat.occ) occ++;
            if (j - 1 >= 0 && seats[i, j - 1] == seat.occ) occ++;
            if (j + 1 < jmax && seats[i, j + 1] == seat.occ) occ++;

            return occ;
        }

        public static void run_simulation(seat[,] seats)
        {
            bool sth_changed = true;
            seat[,] prev_seats;

            while(sth_changed)
            {
                sth_changed = false;
                prev_seats = seats.Clone() as seat[,];

                for(int i = 0; i < seats.GetLength(0); i++)
                    for(int j = 0; j < seats.GetLength(1); j++)
                    {
                        if(prev_seats[i, j] == seat.empty && count_occ(i, j, prev_seats) == 0)
                        {
                            seats[i, j] = seat.occ;
                            sth_changed = true;
                        }    
                        else if(prev_seats[i, j] == seat.occ && count_occ(i, j, prev_seats) > 3)
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
            for(int i = 0; i < seats.GetLength(0); i++)
            {
                for(int j = 0; j < seats.GetLength(1); j++)
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
