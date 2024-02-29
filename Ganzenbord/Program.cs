﻿// See https://aka.ms/new-console-template for more information

using Ganzenbord;
using Ganzenbord.Business;
using Ganzenbord.Business.Logger;
using Ganzenbord.Business.Player;

ILogger logger = new ConsoleLogger();
GameProgression game = new GameProgression(logger);
Player player1 = new Player(PlayerColor.Red, logger);
Player player2 = new Player(PlayerColor.Blue, logger);
game.StartGame([player1, player2]);