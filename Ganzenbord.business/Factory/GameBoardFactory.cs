using Ganzenbord.Business.GameBoard;

namespace Ganzenbord.Business.Factory
{
    internal class GameBoardFactory
    {
        public static IGameBoard Create(GameBoardType type)
        {
            switch (type)
            {
                case GameBoardType.GooseGame:
                    return new GooseGameBoard();

                default:
                    return new GooseGameBoard();
            }
        }
    }
}