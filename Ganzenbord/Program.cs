// See https://aka.ms/new-console-template for more information

using Ganzenbord;
using Ganzenbord.Business;
using Ganzenbord.Business.Dice;
using Ganzenbord.Business.Logger;
using Ganzenbord.Business.Player;

ILogger logger = new ConsoleLogger();
IDiceGenerator diceGenerator = new DiceGenerator();
/*GameProgression game = new GameProgression(logger);
Player player1 = new Player(logger,PlayerColor.Red);
Player player2 = new Player(logger,PlayerColor.Blue);
game.StartGame([player1, player2*/

string playersInput = logger.Input("How many players are playing? (default is 4 and max is 4) ");
int amountOfPlayers;

if (playersInput != "")
{
    amountOfPlayers = Int32.Parse(playersInput);
}

string amountOfDice = logger.Input("How many dice are you going to use? (default is 2) ");
//int amountOfPlayers = Int32.Parse();
//int amountOfDice = Int32.Parse());
Game game = new Game(
    logger,
    diceGenerator,
    PlayerType.Regular,
    2,
    4
    );
game.StartGame();