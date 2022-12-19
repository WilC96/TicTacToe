// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TicTacToe;
using TicTacToe.Factories;
using TicTacToe.Services;

var host = Host.CreateDefaultBuilder()
    .ConfigureServices((cxt, services) =>
    {
        services.AddAbstractFactory<IDisplayService, DisplayService>();
        services.AddSingleton<IPlayerInput, PlayerInput>();
        services.AddSingleton<IGameLauncher, GameLauncher>();
    })
    .Build();

var gameLauncher = ActivatorUtilities.CreateInstance<GameLauncher>(host.Services);

gameLauncher.Run();