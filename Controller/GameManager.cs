using OthelloGame.Interfaces;

namespace OthelloGame
{
    class GameManager
    {
        private GameController _gameController;

        public GameManager(IBoard board, IDisplay display)
        {
            _gameController = new GameController(board, display);
        }

        public void Play()
        {
            _gameController.Play();
        }
    }
}
