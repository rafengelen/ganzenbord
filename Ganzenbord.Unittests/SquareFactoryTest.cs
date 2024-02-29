﻿using Ganzenbord.Business;
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
            SquareFactory squareFactory = new SquareFactory();
            //ACT
            ISquare square = squareFactory.Create(bridge, 6);

            //ASSERT

            Assert.Equal(typeof(Bridge), square.GetType());
        }

        [Fact]
        public void WhenTypeIsInn_ThenCreateInnSquare()
        {
            //ARRANGE
            SquareType inn = SquareType.Inn;

            SquareFactory squareFactory = new SquareFactory();
            //ACT
            ISquare square = squareFactory.Create(inn,1);

            //ASSERT

            Assert.Equal(typeof(Inn), square.GetType());
        }

        [Fact]
        public void WhenTypeIsDeath_ThenCreateDeathSquare()
        {
            //ARRANGE
            SquareType death = SquareType.Death;
            SquareFactory squareFactory = new SquareFactory();
            //ACT
            ISquare square = squareFactory.Create(death,1);

            //ASSERT

            Assert.Equal(typeof(Death), square.GetType());
        }

        [Fact]
        public void WhenTypeIsEnd_ThenCreateEndSquare()
        {
            //ARRANGE
            SquareType end = SquareType.End;
            SquareFactory squareFactory = new SquareFactory();
            //ACT
            ISquare square = squareFactory.Create(end,1);

            //ASSERT

            Assert.Equal(typeof(End), square.GetType());
        }

        [Fact]
        public void WhenTypeIsMaze_ThenCreateMazeSquare()
        {
            //ARRANGE
            SquareType maze = SquareType.Maze;
            SquareFactory squareFactory = new SquareFactory();
            //ACT
            ISquare square = squareFactory.Create(maze, 1);

            //ASSERT

            Assert.Equal(typeof(Maze), square.GetType());
        }

        [Fact]
        public void WhenTypeIsPrison_ThenCreatePrisonSquare()
        {
            //ARRANGE
            SquareType prison = SquareType.Prison;
            SquareFactory squareFactory = new SquareFactory();
            //ACT
            ISquare square = squareFactory.Create(prison,1);

            //ASSERT

            Assert.Equal(typeof(Prison), square.GetType());
        }

        [Fact]
        public void WhenTypeIsStatic_ThenCreateStaticSquare()
        {
            //ARRANGE
            SquareType staticSquare = SquareType.Static;

            SquareFactory squareFactory = new SquareFactory();
            //ACT
            ISquare square = squareFactory.Create(staticSquare,1);

            //ASSERT

            Assert.Equal(typeof(Static), square.GetType());
        }

        [Fact]
        public void WhenTypeIsWell_ThenCreateWellSquare()
        {
            //ARRANGE
            SquareType well = SquareType.Well;

            SquareFactory squareFactory = new SquareFactory();
            //ACT
            ISquare square = squareFactory.Create(well,1);

            //ASSERT

            Assert.Equal(typeof(Well), square.GetType());
        }
    }
}