// See https://aka.ms/new-console-template for more information

using Ganzenbord;
using Ganzenbord.Business;
using Ganzenbord.Business.Dice;
using Ganzenbord.Business.Factory;
using Ganzenbord.Business.Logger;
using Ganzenbord.Business.Player;

ILogger logger = new ConsoleLogger();
IDiceGenerator diceGenerator = new DiceGenerator();
IPlayerFactory factory = new PlayerFactory();

Game game = new Game(
    logger,
    diceGenerator,
    factory,
    PlayerType.Regular
    );
game.StartGame();