﻿using Ganzenbord.Business.Player;

namespace Ganzenbord.Unittests
{
    public class GooseSquareTests
    {
        [Theory]
        [InlineData(new int[] { 1, 1 }, 3, 7)]
        [InlineData(new int[] { 2, 1 }, 38, 44)]
        [InlineData(new int[] { 3, 3 }, 8, 20)]
        public void WhenPlayerLandsOnGoose_ThenGoForwardSameAmountOfSteps(int[] dice, int startPosition, int endPosition)
        {
            //ARRANGE
            IPlayer player = PlayerHelper.GenerateTestPlayer(startPosition);

            //ACT
            player.Move(dice);

            //ASSERT
            Assert.Equal(endPosition, player.Position);
        }

        

        [Theory]
        [InlineData(new int[] { 1, 3 }, 37, 49)]
        [InlineData(new int[] { 2, 2 }, 10, 22)]
        [InlineData(new int[] { 3, 1 }, 28, 40)]
        public void WhenPlayerLandsOnMultipleGoose_ThenKeepGoingForward(int[] dice, int startPosition, int endPosition)
        {
            //ARRANGE
            IPlayer player = PlayerHelper.GenerateTestPlayer(startPosition);

            //ACT
            player.Move(dice);

            //ASSERT
            Assert.Equal(endPosition, player.Position);
        }

        [Theory]
        [InlineData(new int[] { 1, 1 }, 47, 43)]
        [InlineData(new int[] { 2, 1 }, 17, 11)]
        public void WhenPlayerLandsOnGooseAndIsMovingBackwards_ThenKeepGoingBackwards(int[] dice, int startPosition, int endPosition)
        {
            //ARRANGE
            IPlayer player = PlayerHelper.GenerateTestPlayer(startPosition);
            player.ReverseMoving = true;

            //ACT
            player.Move(dice);

            //ASSERT
            Assert.Equal(endPosition, player.Position);
        }

        [Theory]
        [InlineData(new int[] { 3, 2 }, 55, 40)]
        [InlineData(new int[] { 3, 1 }, 13, 1)]
        [InlineData(new int[] { 1, 3 }, 49, 37)]
        public void WhenPlayerLandsOnMultipleGeeseAndIsMovingBackwards_KeepMovingBackwards(int[] dice, int startPosition, int endPosition)
        {
            //ARRANGE
            IPlayer player = PlayerHelper.GenerateTestPlayer(startPosition);
            player.ReverseMoving = true;

            //ACT
            player.Move(dice);

            //ASSERT
            Assert.Equal(endPosition, player.Position);
        }

        [Theory]
        [InlineData(new int[] { 4, 3 }, 60, 52)]
        [InlineData(new int[] { 4, 6 }, 57, 49)]
        public void WhenPlayerPassesEndAndLandsOnGoose_ThenKeepGoingBackwards(int[] dice, int startPosition, int endPosition)
        {
            //ARRANGE
            IPlayer player = PlayerHelper.GenerateTestPlayer(startPosition);

            //ACT
            player.Move(dice);

            //ASSERT
            Assert.Equal(endPosition, player.Position);
        }
    }
}