// See https://aka.ms/new-console-template for more information

using Ganzenbord;
using Ganzenbord.Business;
using Ganzenbord.Business.Dice;
using Ganzenbord.Business.Factory;
using Ganzenbord.Business.Logger;
using Microsoft.Extensions.DependencyInjection;

// Add services to the container.
var serviceProvider = new ServiceCollection()
    .AddTransient<ILogger, ConsoleLogger>() // Transient: Creates a new instance every time it's requested.
    .AddTransient<IDiceGenerator, DiceGenerator>()
    .AddTransient<IPlayerFactory, PlayerFactory>()
    .AddTransient<ISquareFactory, SquareFactory>()
    .AddTransient<IFooService, FooService>()
    .AddSingleton<IGooseGameBoard, GooseGameBoard>() // Singleton: Creates a single instance for the entire application.
    .AddSingleton<IGame, Game>()

.BuildServiceProvider();

IGame game  = serviceProvider.GetRequiredService<IGame>();
game.StartGame();