using Ganzenbord.Business.GameBoard;

namespace Ganzenbord.Business.Factory
{
    public class GameBoardFactory
    {
        public static IGameBoard Create(GameBoardType type)
        {
            SquareFactory factory = new SquareFactory();
            switch (type)
            {
                case GameBoardType.GooseGame:
                    return new GooseGameBoard(factory);

                default:
                    return new GooseGameBoard(factory);
            }
        }
    }
}