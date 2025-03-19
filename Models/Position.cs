namespace OthelloGame.Models
{
    using OthelloGame.Interfaces;

    public struct Position : IPosition
    {
        public int Row { get; }
        public int Col { get; }

        public Position(int row, int col)
        {
            Row = row;
            Col = col;
        }
    }
}
