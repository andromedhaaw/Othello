/* 
using System;
using System.Collections.Generic;

namespace OthelloGame
{
    class Display
    {
        public void DisplayBoard(Board board, List<Position> validMoves)
        {
            Console.Clear();
            Console.WriteLine("    A   B   C   D   E   F   G   H");
            Console.WriteLine("  +---+---+---+---+---+---+---+---+");

            Piece?[,] grid = board.GetBoard();
            int size = grid.GetLength(0);

            HashSet<(int, int)> validMovesSet = new HashSet<(int, int)>();
            foreach (var move in validMoves)
            {
                validMovesSet.Add((move.Row, move.Col));
            }

            for (int i = 0; i < size; i++)
            {
                Console.Write($"{i + 1} |");

                for (int j = 0; j < size; j++)
                {
                    if (validMovesSet.Contains((i, j)))
                    {
                        // Highlight valid moves with color
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("*");
                        Console.ResetColor();
                    }
                    else
                    {
                        if (grid[i, j] != null)
                        {
                            if (grid[i, j]?.Color == PieceColor.Black)
                                Console.ForegroundColor = ConsoleColor.Blue;
                            else if (grid[i, j]?.Color == PieceColor.White)
                                Console.ForegroundColor = ConsoleColor.White;

                            Console.Write(grid[i, j]?.Color == PieceColor.Black ? "B" : "W");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }

                    if (j < size - 1) Console.Write(" |");
                }
                // Print the right border after the last piece
                Console.WriteLine(" |");

                // Print the separator line after each row
                Console.WriteLine("  +---+---+---+---+---+---+---+---+");
            }

            Console.WriteLine("    A   B   C   D   E   F   G   H");
        }

        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public string AskNonNullInput()
        {
            string input = Console.ReadLine();
            while (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Input cannot be empty. Please try again:");
                input = Console.ReadLine();
            }
            return input;
        }
    }
}
*/
