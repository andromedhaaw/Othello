namespace OthelloGame
{
    class Piece
    {
        public PieceColor Color { get; private set; }

        public Action Flip => () => 
        {
            Color = (Color == PieceColor.Black) ? PieceColor.White : PieceColor.Black;
        };

        public Piece(PieceColor color)
        {
            Color = color;
        }
    }
}
