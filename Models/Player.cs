namespace OthelloGame.Models
{
    using OthelloGame.Interfaces;

    public class Player : IPlayer
    {
        public PieceColor Color { get; }
        public int Score { get; set; }

        public Player(PieceColor color)
        {
            Color = color;
            Score = 0;
        }
    }
}
