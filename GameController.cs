using System;
using System.Collections.Generic;

namespace OthelloGame
{
    class GameController
    {
        private Board _board;
        private Player[] _players;
        private int _currentPlayer;
        private GameState _gameState;
        private Display _display;
        private MoveHistory _moveHistory;
        private Action _switchTurn;

        public GameController(Board board, Display display)
        {
            _board = board;
            _display = display;
            _players = new Player[] { new Player(PieceColor.Black), new Player(PieceColor.White) };
            _currentPlayer = 0;
            _gameState = GameState.Playing;
            _moveHistory = new MoveHistory();
            _switchTurn = () => _currentPlayer = (_currentPlayer == 0) ? 1 : 0;

            // Initialize _isInsideBoard as a Func
            _isInsideBoard = (row, col) =>
            {
                return row >= 0 && row < _board.GetBoard().GetLength(0) && 
                       col >= 0 && col < _board.GetBoard().GetLength(1);
            };
        }

        public void Play()
        {
            _display.DisplayMessage("Welcome to Othello/Reversi!");
            _display.DisplayMessage("Instructions:");
            _display.DisplayMessage("- Enter your move in format like A1, C5, etc.");
            _display.DisplayMessage("- Black (B) plays first");
            _display.DisplayMessage("- Valid moves are shown with a * symbol");
            _display.DisplayMessage("- Type 'quit' to exit game");
            
            _display.DisplayMessage("\nPress any key to start...");
            Console.ReadKey();

            while (_gameState == GameState.Playing)
            {
                Player currentPlayer = _players[_currentPlayer];
                List<Position> validMoves = GetValidMoves(currentPlayer);

                _display.DisplayBoard(_board, validMoves);
                var (blackCount, whiteCount) = GetScoreCounts();
                _display.DisplayMessage($"Score - Black: {blackCount} | White: {whiteCount}");
                _display.DisplayMessage($"Player {currentPlayer.Color}'s turn.");

                if (validMoves.Count == 0)
                {
                    List<Position> opponentMoves = GetValidMoves(_players[(_currentPlayer + 1) % 2]);
                    if (opponentMoves.Count == 0)
                    {
                        _display.DisplayBoard(_board, new List<Position>());
                        DisplayWinner();
                        _gameState = GameState.Finished;
                        break;
                    }

                    _display.DisplayMessage($"Player {currentPlayer.Color} has no valid moves. Turn skipped.");
                    _switchTurn();
                    _display.DisplayMessage("Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }

                _display.DisplayMessage("Enter your move (e.g., A1, B2), or 'quit': ");
                string input = _display.AskNonNullInput().ToUpper();

                if (input == "QUIT")
                {
                    _display.DisplayMessage("Thanks for playing!");
                    break;
                }

                if (TryParseMove(input, out int row, out int col) && IsValidMove(row, col, currentPlayer))
                {
                    _moveHistory.SaveState(_board, _players[_currentPlayer]);
                    PlacePiece(row, col, currentPlayer);
                    _switchTurn();
                }
                else
                {
                    _display.DisplayMessage("Invalid move. Press any key to try again.");
                    Console.ReadKey();
                }
            }
        }

        private bool PlacePiece(int row, int col, Player player)
        {
            if (!IsValidMove(row, col, player))
                return false;

            _board.GetBoard()[row, col] = new Piece(player.Color);
            List<Position> flippablePieces = GetFlippablePieces(row, col, player);
            foreach (var position in flippablePieces)
            {
                _board.GetBoard()[position.Row, position.Col]?.Flip();
            }

            return true;
        }

        private List<Position> GetFlippablePieces(int row, int col, Player player)
        {
            List<Position> flippablePieces = new List<Position>();
            PieceColor opponentColor = (player.Color == PieceColor.Black) ? PieceColor.White : PieceColor.Black;
            int[] directions = { -1, 0, 1 };

            foreach (var dRow in directions)
            {
                foreach (var dCol in directions)
                {
                    if (dRow == 0 && dCol == 0) continue;

                    int r = row + dRow;
                    int c = col + dCol;
                    List<Position> piecesToFlip = new List<Position>();

                    while (_isInsideBoard(r, c) && 
                        _board.GetBoard()[r, c] != null && 
                        _board.GetBoard()[r, c].Color == opponentColor)
                    {
                        piecesToFlip.Add(new Position(r, c));
                        r += dRow;
                        c += dCol;
                    }

                    if (_isInsideBoard(r, c) && 
                        _board.GetBoard()[r, c] != null && 
                        _board.GetBoard()[r, c].Color == player.Color)
                    {
                        flippablePieces.AddRange(piecesToFlip);
                    }
                }
            }

            return flippablePieces;
        }

        private bool IsValidMove(int row, int col, Player player)
        {
            if (!_isInsideBoard(row, col)) return false;
            if (_board.GetBoard()[row, col] != null) return false;

            return GetFlippablePieces(row, col, player).Count > 0;
        }

        private List<Position> GetValidMoves(Player player)
        {
            List<Position> validMoves = new List<Position>();

            for (int i = 0; i < _board.GetBoard().GetLength(0); i++)
            {
                for (int j = 0; j < _board.GetBoard().GetLength(1); j++)
                {
                    if (_board.GetBoard()[i, j] == null && IsValidMove(i, j, player))
                    {
                        validMoves.Add(new Position(i, j));
                    }
                }
            }

            return validMoves;
        }

        private bool TryParseMove(string input, out int row, out int col)
        {
            row = -1;
            col = -1;

            if (string.IsNullOrEmpty(input) || input.Length < 2) return false;

            try
            {
                col = input[0] - 'A';
                row = int.Parse(input.Substring(1)) - 1;

                return _isInsideBoard(row, col);
            }
            catch (Exception)
            {
                return false;
            }
        }

        private (int blackCount, int whiteCount) GetScoreCounts()
        {
            int blackCount = 0, whiteCount = 0;

            for (int i = 0; i < _board.GetBoard().GetLength(0); i++)
            {
                for (int j = 0; j < _board.GetBoard().GetLength(1); j++)
                {
                    if (_board.GetBoard()[i, j] != null)
                    {
                        if (_board.GetBoard()[i, j].Color == PieceColor.Black) blackCount++;
                        else whiteCount++;
                    }
                }
            }

            return (blackCount, whiteCount);
        }

        private void DisplayWinner()
        {
            var (blackCount, whiteCount) = GetScoreCounts();

            _display.DisplayMessage($"Game Over! Final Score - Black: {blackCount} | White: {whiteCount}");

            if (blackCount > whiteCount) _display.DisplayMessage("Black wins!");
            else if (whiteCount > blackCount) _display.DisplayMessage("White wins!");
            else _display.DisplayMessage("It's a draw!");
        }
    }
}
