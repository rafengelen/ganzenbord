// See https://aka.ms/new-console-template for more information

using Ganzenbord.Business;
using Ganzenbord.Business.Logger;
using Ganzenbord.Business.Squares;

Console.WriteLine("Starting program");
/*GameProgression game = new GameProgression(new ConsoleLogger());
Player player1 = new Player();
Player player2 = new Player();

game.StartGame([ player1,player2]);
Console.WriteLine("hi");*/

GameBoard board = new GameBoard();
board.SetupGameBoard();
for (int i = 0; i < 64; i++)
{
    Console.WriteLine(i);
    Console.WriteLine(board.GetSquare(i));
    Console.WriteLine();
}