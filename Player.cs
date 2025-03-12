namespace OthelloGame
{
    class Player
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
