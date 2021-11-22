using System;
using PlutoRover.Api;
using System.Collections.Generic;
using PlutoRover.Api.Exceptions;
using NUnit.Framework;

namespace MarsRoverKataTests
{
    [TestFixture]
    public class RoverTests
    {
        [Test]
        public void Rover_Starting_Position_Is_Invalid_Because_It_Is_Outside_The_Grid()
        {

            var gridDimension = new Point(1, 1);
            var obstacleList = new List<Obstacle>();

            var grid = new Grid(gridDimension, obstacleList);
            Assert.Throws<RoverStartingPositionInvalidException>(() => new Rover(grid, new Point(1, 2), Direction.South));
        }

        [Test]
        public void Rover_Starting_Position_Is_Invalid_Because_It_Is_On_An_Obstacle()
        {

            var gridDimension = new Point(3, 3);
            var obstacleList = new List<Obstacle>();
            obstacleList.Add(new Obstacle(new Point(1, 2)));

            var grid = new Grid(gridDimension, obstacleList);
            Assert.Throws<RoverStartingPositionInvalidException>(() => new Rover(grid, new Point(1, 2), Direction.South));
        }

        [Test]
        public void Rover_Direction_Is_Invalid()
        {

            var gridDimension = new Point(1, 1);
            var obstacleList = new List<Obstacle>();

            var grid = new Grid(gridDimension, obstacleList);

            Assert.Throws<RoverStartingDirectionInvalidException>(() => new Rover(grid, new Point(1, 1), "D"));
        }

        [Test]
        public void Rover_Receives_No_Commands()
        {
            var gridDimension = new Point(2, 2);
            var obstacleList = new List<Obstacle>();

            var grid = new Grid(gridDimension, obstacleList);

            var rover = new Rover(grid, new Point(2, 2), Direction.North);

            var roverInfo = rover.MoveAndTurn("");

            Assert.IsTrue(roverInfo.RoverDirection == Direction.North &&
                          roverInfo.RoverPosition.X == 2 &&
                          roverInfo.RoverPosition.Y == 2);

        }
    }
}
