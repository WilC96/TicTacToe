namespace TicTacToe.Services
{
    public interface IDisplayService
    {
        void DisplayGameInfo(int PlayerNumber);
        void DrawGameboard(char[] gameMarkers);
        char[] CheckWinner(char[] gameMarkers, int currentPlayer);
    }
}
