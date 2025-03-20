using OthelloGame.Interfaces;  // For Interface
using OthelloGame.Models;      // For Position, Player, Piece, Board, and Display

namespace OthelloGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a Board object implementing IBoard
            IBoard board = new Board();  

            // Create a Display object implementing IDisplay
            IDisplay display = new Display();  

            // Create the GameManager and pass in the IBoard and IDisplay
            GameManager gameManager = new GameManager(board, display);

            // Start the game through GameManager
            gameManager.Play();
        }
    }
}
