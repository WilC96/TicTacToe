using TicTacToe.Factories;
using TicTacToe.Services;

namespace TicTacToe
{
    public class GameLauncher : IGameLauncher
    {
        private readonly IAbstractFactory<IDisplayService> _displayServiceFactory;
        private readonly IPlayerInput _playerInput;

        public GameLauncher(IAbstractFactory<IDisplayService> displayServiceFactory, IPlayerInput playerInput)
        {
            this._displayServiceFactory = displayServiceFactory;
            this._playerInput = playerInput;
        }

        IDisplayService? displayService;

        int currentPlayer = 2;
        char[] boardMarkers = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        bool refreshDisplay = false;

        public void Run()
        {
            displayService = _displayServiceFactory.Create();

            while (true)
            {
                if (refreshDisplay)
                {
                    // Get new service via DI
                    displayService = _displayServiceFactory.Create();
                    currentPlayer = 2;
                    boardMarkers = "123456789".ToCharArray();
                    refreshDisplay = false;
                    continue;
                }

                Console.Clear();

                currentPlayer = currentPlayer.Equals(1) ? 2 : 1;

                displayService!.DisplayGameInfo(currentPlayer);

                displayService!.DrawGameboard(boardMarkers);

                GameEngine(boardMarkers, currentPlayer);

                boardMarkers = displayService!.CheckWinner(boardMarkers, currentPlayer);
            }
        }

        private void GameEngine(char[] boardMarkers, int currentPlayer)
        {
            bool notValidMove = true;

            do
            {
                string userInput = _playerInput.GetPlayerInput();

                if (!string.IsNullOrEmpty(userInput) &&
                    (userInput.Equals("1") ||
                    userInput.Equals("2") ||
                    userInput.Equals("3") ||
                    userInput.Equals("4") ||
                    userInput.Equals("5") ||
                    userInput.Equals("6") ||
                    userInput.Equals("7") ||
                    userInput.Equals("8") ||
                    userInput.Equals("9") ||
                    userInput.Equals("reset")))
                {
                    if (userInput.Equals("reset"))
                    {
                        refreshDisplay = true;
                        break;
                    }

                    _ = int.TryParse(userInput, out var gamePlacementMarker);

                    char currentMarker = boardMarkers[gamePlacementMarker - 1];

                    if (currentMarker.Equals('X') || currentMarker.Equals('O'))
                    {
                        Console.WriteLine("Cannot override placement, pick another square.");
                    }
                    else
                    {
                        boardMarkers[gamePlacementMarker - 1] = currentPlayer % 2 == 0 ? 'O' : 'X';

                        notValidMove = false;
                    }
                }
                else
                {
                    Console.WriteLine("Nope.");
                }
            } while (notValidMove);
        }
    }
}