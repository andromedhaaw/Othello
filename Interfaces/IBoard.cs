namespace OthelloGame.Interfaces
{
    using OthelloGame.Models;  // Add this using statement to reference Piece class

    public interface IBoard
    {
        Piece?[,] GetBoard();  // Make sure the return type is correct (Piece?[,])
    }
}
