using System;

using PlutoRover.Api;
using System.Collections.Generic;
using PlutoRover.Api.Exceptions;
using NUnit.Framework;

namespace MarsRoverKataTests
{
    [TestFixture]
    public class GridTests
    {

        [Test]
        public void Grid_Dimensions_Are_Invalid()
        {

            var gridDimension = new Point(0, 1);
            var obstacleList = new List<Obstacle>();

            Assert.Throws<GridDimensionInvalidException>(() => new Grid(gridDimension, obstacleList));
        }

        [Test]
        public void Obstacle_Position_Is_Invalid()
        {

            var gridDimension = new Point(1, 1);
            var obstacleList = new List<Obstacle>();
            obstacleList.Add(new Obstacle(new Point(1, 2)));

            Assert.Throws<ObstaclePositionInvalidException>(() => new Grid(gridDimension, obstacleList));
        }

        [Test]
        public void Rover_Turns_Left_From_North()
        {

            var gridDimension = new Point(1, 1);
            var obstacleList = new List<Obstacle>();

            var grid = new Grid(gridDimension, obstacleList);

            var newDirection = grid.TurnRoverLeft(Direction.North);

            Assert.IsTrue(newDirection == Direction.West);

        }
    }
}
