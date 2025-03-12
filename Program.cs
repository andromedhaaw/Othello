namespace OthelloGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            Display display = new Display();
            GameController gameController = new GameController(board, display);
            gameController.Play();
        }
    }
}
