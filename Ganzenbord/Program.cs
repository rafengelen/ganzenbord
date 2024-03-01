// See https://aka.ms/new-console-template for more information

using Ganzenbord;
using Ganzenbord.Business;
using Ganzenbord.Business.GameBoard;
using Ganzenbord.Business.Logger;
using Ganzenbord.Business.Player;

ILogger logger = new ConsoleLogger();
/*GameProgression game = new GameProgression(logger);
Player player1 = new Player(logger,PlayerColor.Red);
Player player2 = new Player(logger,PlayerColor.Blue);
game.StartGame([player1, player2*/

Player red= new Player(logger, PlayerColor.Red);
Player blue = new Player(logger, PlayerColor.Blue);
Player yellow = new Player(logger, PlayerColor.Yellow);
GameTmp game = new GameTmp(
    logger,
    [red, blue, yellow],
    GameBoardType.GooseGame
    );
game.StartGame();