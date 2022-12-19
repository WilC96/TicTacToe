using Moq;
using NUnit.Framework;
using TicTacToe;
using TicTacToe.Factories;
using TicTacToe.Services;

namespace TicTacToeTests
{
    public class GameLauncherShould
    {
        private readonly GameLauncher _sut;
        private readonly Mock<IAbstractFactory<IDisplayService>> _displayServiceFactoryMock = new();
        private readonly Mock<IPlayerInput> _playerInput = new();


        public GameLauncherShould()
        {
            _sut = new GameLauncher(_displayServiceFactoryMock.Object, _playerInput.Object);
        }

        [TestCase(1, 'X')]
        [TestCase(2, 'O')]
        public void GameEngineShould(int currentPlayer, char expected)
        {
            char[] boardMarkers = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            _playerInput.Setup(input => input.GetPlayerInput()).Returns("1");

            var gameEngineShould = new TestPrivateMethodHelper(_sut);
            gameEngineShould.Invoke("GameEngine", boardMarkers, currentPlayer);

            Assert.AreEqual(expected, boardMarkers[0]);
        }
    }
}
