namespace OthelloGame.Models
{
    using OthelloGame.Interfaces;

    public class Piece : IPiece
    {
        public PieceColor Color { get; private set; }

        // Implement Flip as a method
        public void Flip()
        {
            Color = (Color == PieceColor.Black) ? PieceColor.White : PieceColor.Black;
        }

        // Constructor to initialize Piece with a specific color
        public Piece(PieceColor color)
        {
            Color = color;
        }
    }
}
