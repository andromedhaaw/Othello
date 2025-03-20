namespace OthelloGame.Models
{
    using OthelloGame.Interfaces;  // Ensure the IBoard interface is referenced

    public class Board : IBoard  // Make sure Board implements IBoard
    {
        private int _size;
        private Piece?[,] _grid;  // Nullable array of Piece

        public Board(int size = 8)
        {
            _size = size;
            _grid = new Piece?[_size, _size];  // Initialize the grid
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

        // Implement the GetBoard() method from the IBoard interface
        public Piece?[,] GetBoard()  // Return a nullable 2D array of Piece
        {
            return _grid;
        }
    }
}
