namespace OthelloGame
{
    class MoveHistory
    {
        private List<(Piece?[,] boardState, Player player)> _history;

        public MoveHistory()
        {
            _history = new List<(Piece?[,] boardState, Player player)>();
        }

        public void SaveState(Board board, Player currentPlayer)
        {
            Piece?[,] originalBoard = board.GetBoard();
            int size = originalBoard.GetLength(0);
            Piece?[,] boardCopy = new Piece?[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (originalBoard[i, j] != null)
                    {
                        boardCopy[i, j] = new Piece(originalBoard[i, j]?.Color ?? PieceColor.Black);
                    }
                    else
                    {
                        boardCopy[i, j] = null;
                    }
                }
            }

            _history.Add((boardCopy, currentPlayer));
        }

        
    }
}
