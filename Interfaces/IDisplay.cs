namespace OthelloGame.Interfaces
{
    public interface IDisplay
    {
        void DisplayBoard(IBoard board, List<IPosition> validMoves);
        void DisplayMessage(string message);
        string AskNonNullInput();
    }
}
