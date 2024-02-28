using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ganzenbord.Business;
using Ganzenbord.Business.Factory;
using Ganzenbord.Business.Squares;
namespace Ganzenbord.Unittests
{
    public class SquareFactoryTest
    {

        [Fact]
        public void WhenTypeIsBridge_ThenCreateBridgeSquare()
        {
            //ARRANGE
            SquareType bridge = SquareType.Bridge;

            //ACT
            ISquare square = SquareFactory.Create(bridge);

            //ASSERT
            
            Assert.Equal(typeof(Bridge), square.GetType());
        }

        [Fact]
        public void WhenTypeIsInn_ThenCreateInnSquare()
        {
            //ARRANGE
            SquareType inn = SquareType.Inn;

            //ACT
            ISquare square = SquareFactory.Create(inn);

            //ASSERT

            Assert.Equal(typeof(Inn), square.GetType());
        }
        [Fact]
        public void WhenTypeIsDeath_ThenCreateDeathSquare()
        {
            //ARRANGE
            SquareType death = SquareType.Death;

            //ACT
            ISquare square = SquareFactory.Create(death);

            //ASSERT

            Assert.Equal(typeof(Death), square.GetType());
        }
        [Fact]
        public void WhenTypeIsEnd_ThenCreateEndSquare()
        {
            //ARRANGE
            SquareType end = SquareType.End;

            //ACT
            ISquare square = SquareFactory.Create(end);

            //ASSERT

            Assert.Equal(typeof(End), square.GetType());
        }
        [Fact]
        public void WhenTypeIsMaze_ThenCreateMazeSquare()
        {
            //ARRANGE
            SquareType maze = SquareType.Maze;

            //ACT
            ISquare square = SquareFactory.Create(maze);

            //ASSERT

            Assert.Equal(typeof(Maze), square.GetType());
        }
        [Fact]
        public void WhenTypeIsPrison_ThenCreatePrisonSquare()
        {
            //ARRANGE
            SquareType prison = SquareType.Prison;

            //ACT
            ISquare square = SquareFactory.Create(prison);

            //ASSERT

            Assert.Equal(typeof(Prison), square.GetType());
        }
        [Fact]
        public void WhenTypeIsStatic_ThenCreateStaticSquare()
        {
            //ARRANGE
            SquareType staticSquare = SquareType.Static;

            //ACT
            ISquare square = SquareFactory.Create(staticSquare);

            //ASSERT

            Assert.Equal(typeof(Static), square.GetType());
        }
        [Fact]
        public void WhenTypeIsWell_ThenCreateWellSquare()
        {
            //ARRANGE
            SquareType well = SquareType.Well;

            //ACT
            ISquare square = SquareFactory.Create(well);

            //ASSERT

            Assert.Equal(typeof(Well), square.GetType());
        }
    }
}
