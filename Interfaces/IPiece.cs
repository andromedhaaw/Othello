namespace OthelloGame.Interfaces
{
    public interface IPiece
    {
        PieceColor Color { get; }
        void Flip();
    }
}
