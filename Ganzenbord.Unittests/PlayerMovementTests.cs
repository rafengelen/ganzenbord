using Ganzenbord.Business;
using Ganzenbord.Business.GameBoard;
using Ganzenbord.Business.Logger;
using Ganzenbord.Business.Player;
using Moq;

namespace Ganzenbord.Unittests
{
    public class PlayerMovementTests
    {
        [Fact]
        public void WhenPlayerRollsDice_ThenPlayerMoves()
        {
            //arrange
            Game.Instance.StartGame();
            Mock<ILogger> logger = new Mock<ILogger>();
            Player player = new Player(logger.Object, PlayerColor.Red);
            player.MoveToPosition(1);
            int[] dice = { 1, 2 };

            //act
            player.Move(dice);

            //assert
            Assert.Equal(4, player.Position);
        }

        [Fact]
        public void WhenPlayerMovesFurtherThan63_ThenPlayerWalksRemainingStepsBackwards()
        {
            //arrange
            Game.Instance.StartGame();
            Mock<ILogger> logger = new Mock<ILogger>();
            Player player = new Player(logger.Object, PlayerColor.Red);
            player.MoveToPosition(62);
            int[] dice = { 1, 2 };

            //act
            player.Move(dice);

            //assert
            Assert.Equal(61, player.Position);
        }

        [Fact]
        public void WhenPlayerRolls5And4InTurn1_ThenGoTo26()
        {
            //ARRANGE
            Game.Instance.StartGame();
            Mock<ILogger> logger = new Mock<ILogger>();
            Player player = new Player(logger.Object, PlayerColor.Red);
            player.MoveToPosition(0);
            int[] dice = { 5, 4 };

            //ACT
            player.Move(dice);

            //ASSERT
            Assert.Equal(26, player.Position);
        }

        [Fact]
        public void WhenPlayerRolls5And4InTurn2_ThenNotGoTo26()
        {
            //ARRANGE
            Game.Instance.StartGame();
            Mock<ILogger> logger = new Mock<ILogger>();
            Player player = new Player(logger.Object, PlayerColor.Red);
            player.MoveToPosition(0);
            int[] dice = { 5, 4 };
            Game.Instance.Turn = 2;

            //ACT
            player.Move(dice);

            //ASSERT
            Assert.NotEqual(26, player.Position);
        }

        [Fact]
        public void WhenPlayerRolls4And5InTurn1_ThenGoTo26()
        {
            //ARRANGE
            Game.Instance.StartGame();
            Mock<ILogger> logger = new Mock<ILogger>();
            Player player = new Player(logger.Object, PlayerColor.Red);
            player.MoveToPosition(0);
            int[] dice = { 4, 5 };

            //ACT
            player.Move(dice);

            //ASSERT
            Assert.Equal(26, player.Position);
        }

        [Fact]
        public void WhenPlayerRolls4And5InTurn2_ThenNotGoTo26()
        {
            //ARRANGE
            Game.Instance.StartGame();
            Mock<ILogger> logger = new Mock<ILogger>();
            Player player = new Player(logger.Object, PlayerColor.Red);
            int[] dice = { 4, 5 };
            Game.Instance.Turn = 2;

            //ACT
            player.Move(dice);

            //ASSERT
            Assert.NotEqual(26, player.Position);
        }

        [Fact]
        public void WhenPlayerRolls6And3InTurn1_ThenGoTo53()
        {
            //ARRANGE
            Game.Instance.StartGame();
            Mock<ILogger> logger = new Mock<ILogger>();
            Player player = new Player(logger.Object, PlayerColor.Red);
            player.MoveToPosition(0);
            int[] dice = [3, 6];
            //Game.Instance.Turn = 1;

            //ACT
            player.Move(dice);

            //ASSERT
            Assert.Equal(53, player.Position);
        }

        [Fact]
        public void WhenPlayerRolls6And3InTurn2_ThenNotGoTo53()
        {
            //ARRANGE
            Game.Instance.StartGame();
            Mock<ILogger> logger = new Mock<ILogger>();
            Player player = new Player(logger.Object, PlayerColor.Red);
            player.MoveToPosition(0);
            int[] dice = [6, 3];
            Game.Instance.Turn = 2;

            //ACT
            player.Move(dice);

            //ASSERT
            Assert.NotEqual(53, player.Position);
        }

        [Fact]
        public void WhenPlayerRolls3And6InTurn1_ThenGoTo53()
        {
            //ARRANGE
            Game.Instance.StartGame();
            Mock<ILogger> logger = new Mock<ILogger>();
            Player player = new Player(logger.Object, PlayerColor.Red);
            player.MoveToPosition(0);
            int[] dice = [3, 6];

            //ACT
            player.Move(dice);

            //ASSERT
            Assert.Equal(53, player.Position);
        }

        [Fact]
        public void WhenPlayerRolls3And6InTurn2_ThenNotGoTo53()
        {
            //ARRANGE
            Mock<ILogger> logger = new Mock<ILogger>();
            Player player = new Player(logger.Object, PlayerColor.Red);
            GameTmp game = new GameTmp(
                logger.Object,
                [player],
                GameBoardType.GooseGame
            );
           
            player.MoveToPosition(0);
            int[] dice = [3, 6];
            game.Turn = 2;

            //ACT
            game.HandleFirstRound();

            //ASSERT
            Assert.NotEqual(53, player.Position);
        }
    }
}