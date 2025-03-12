namespace OthelloGame
{
    class Board
    {
        private int _size;
        private Piece?[,] _grid;

        public Board(int size = 8)
        {
            _size = size;
            _grid = new Piece?[_size, _size];
            InitBoard();
        }

        private void InitBoard()
        {
            for (int i = 0; i < _size; i++)
                for (int j = 0; j < _size; j++)
                    _grid[i, j] = null;

            int middle = _size / 2;
            _grid[middle - 1, middle - 1] = new Piece(PieceColor.White);
            _grid[middle - 1, middle] = new Piece(PieceColor.Black);
            _grid[middle, middle - 1] = new Piece(PieceColor.Black);
            _grid[middle, middle] = new Piece(PieceColor.White);
        }

        public Piece?[,] GetBoard()
        {
            return _grid;
        }
    }
}
