namespace TicTacToe.Services
{
    public sealed class DisplayService : IDisplayService
    {
        public int totalTurns = 0;
        public int PlayerOneWins = 0;
        public int PlayerTwoWins = 0;
        public int GamesPlayed = 0;
        public int GamesDrawn = 0;

        public void DisplayGameInfo(int PlayerNumber)
        {
            Console.WriteLine("Player 1: X");
            Console.WriteLine("Player 2: O");

            Console.WriteLine();

            Console.WriteLine($"Total Turns: {totalTurns}");
            Console.WriteLine($"Player 1's Wins: {PlayerOneWins}");
            Console.WriteLine($"Player 2's Wins: {PlayerTwoWins}");

            Console.WriteLine();

            Console.WriteLine($"Games Played: {GamesPlayed}");
            Console.WriteLine($"Draws: {GamesDrawn}");

            Console.WriteLine();

            Console.WriteLine($"Player {PlayerNumber}'s turn, select 1 through 9 from the game board.");
            Console.WriteLine("Type reset to clear game data");
            Console.WriteLine();
        }

        public void DrawGameboard(char[] gameMarkers)
        {
            Console.WriteLine($" {gameMarkers[0]} | {gameMarkers[1]} | {gameMarkers[2]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {gameMarkers[3]} | {gameMarkers[4]} | {gameMarkers[5]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {gameMarkers[6]} | {gameMarkers[7]} | {gameMarkers[8]} ");

            totalTurns++;
        }

        public char[] CheckWinner(char[] gameMarkers, int currentPlayer)
        {
            if (IsGameWinner(gameMarkers))
            {
                if (currentPlayer.Equals(1))
                {
                    PlayerOneWins++;
                }
                else
                {
                    PlayerTwoWins++;
                }
                return "123456789".ToCharArray();
            }

            if (IsGameDraw(gameMarkers))
            {
                GamesDrawn++;
                return "123456789".ToCharArray();
            }

            return gameMarkers;
        }

        private static bool IsGameDraw(char[] gameMarkers)
        {
            return gameMarkers[0] != '1' &&
                   gameMarkers[1] != '2' &&
                   gameMarkers[2] != '3' &&
                   gameMarkers[3] != '4' &&
                   gameMarkers[4] != '5' &&
                   gameMarkers[5] != '6' &&
                   gameMarkers[6] != '7' &&
                   gameMarkers[7] != '8' &&
                   gameMarkers[8] != '9';
        }

        private static bool IsGameWinner(char[] gameMarkers)
        {
            if (IsGameMarkersTheSame(gameMarkers, 0, 1, 2))
            {
                return true;
            }

            if (IsGameMarkersTheSame(gameMarkers, 3, 4, 5))
            {
                return true;
            }

            if (IsGameMarkersTheSame(gameMarkers, 6, 7, 8))
            {
                return true;
            }

            if (IsGameMarkersTheSame(gameMarkers, 0, 3, 6))
            {
                return true;
            }

            if (IsGameMarkersTheSame(gameMarkers, 1, 4, 7))
            {
                return true;
            }

            if (IsGameMarkersTheSame(gameMarkers, 2, 5, 8))
            {
                return true;
            }

            if (IsGameMarkersTheSame(gameMarkers, 0, 4, 8))
            {
                return true;
            }

            if (IsGameMarkersTheSame(gameMarkers, 2, 4, 6))
            {
                return true;
            }

            return false;
        }

        private static bool IsGameMarkersTheSame(char[] testGameMarkers, int pos1, int pos2, int pos3)
        {
            return testGameMarkers[pos1].Equals(testGameMarkers[pos2]) && testGameMarkers[pos2].Equals(testGameMarkers[pos3]);
        }
    }
}
