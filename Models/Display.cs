namespace OthelloGame.Models
{
    using OthelloGame.Interfaces;
    using System;
    using System.Collections.Generic;

    public class Display : IDisplay
    {
        public void DisplayBoard(IBoard board, List<IPosition> validMoves)
        {
            Console.Clear();
            Console.WriteLine("  A B C D E F G H");

            Piece?[,] grid = board.GetBoard();
            int size = grid.GetLength(0);

            HashSet<(int, int)> validMovesSet = new HashSet<(int, int)>();
            foreach (var move in validMoves)
            {
                validMovesSet.Add((move.Row, move.Col));
            }

            for (int i = 0; i < size; i++)
            {
                Console.Write($"{i + 1} ");
                for (int j = 0; j < size; j++)
                {
                    if (validMovesSet.Contains((i, j)))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("* ");
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

                            Console.Write(grid[i, j]?.Color == PieceColor.Black ? "O " : "X ");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write(". ");
                        }
                    }
                }
                Console.WriteLine();
            }
        }

        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public string AskNonNullInput()
        {
            string input = Console.ReadLine() ?? string.Empty;
            return input ?? string.Empty;
        }
    }
}
