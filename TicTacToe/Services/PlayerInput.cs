namespace TicTacToe.Services
{
    public sealed class PlayerInput : IPlayerInput
    {
        public string GetPlayerInput()
        {
            return Console.ReadLine()!;
        }
    }
}
