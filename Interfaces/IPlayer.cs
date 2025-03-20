namespace OthelloGame.Interfaces
{
    public interface IPlayer
    {
        PieceColor Color { get; }
        int Score { get; set; }
    }
}
