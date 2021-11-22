using System;
using PlutoRover.Api;
using System.Collections.Generic;
using PlutoRover.Api.Exceptions;
using NUnit.Framework;

namespace MarsRoverKataTests
{
    [TestFixture]
    public class RoverObstacleTests
    {
        [Test]
        public void Rover_Blocked_By_Obstacle_1()
        {

            var gridDimension = new Point(20, 17);

            var obstacleListString = "2,3;2,4;2,5;2,6;2,7;2,8;2,9;2,10";
            obstacleListString += ";4,8;4,14;7,4;8,4;9,4;9,12;9,13;13,10;13,11;17,16";
            var obstacleList = CreateObstacleList(obstacleListString);

            var grid = new Grid(gridDimension, obstacleList);

            var rover = new Rover(grid, new Point(8, 2), Direction.North);

            var roverInfo = rover.MoveAndTurn("LFFRFFFFFFLFFFF");

            Assert.IsTrue(roverInfo.RoverHasBeenBlockedByObstacle &&
                          roverInfo.RoverDirection == Direction.West &&
                          roverInfo.RoverPosition.X == 5 &&
                          roverInfo.RoverPosition.Y == 8);
        }

        [Test]
        public void Rover_Blocked_By_Obstacle_2()
        {

            var gridDimension = new Point(10, 9);

            var obstacleListString = "1,9;4,4;5,5;8,3;7,8";

            var obstacleList = CreateObstacleList(obstacleListString);

            var grid = new Grid(gridDimension, obstacleList);

            var rover = new Rover(grid, new Point(8, 6), Direction.South);

            var roverInfo = rover.MoveAndTurn("RFFFRFFFFFFFF");

            Assert.IsTrue(roverInfo.RoverDirection == Direction.North &&
                          roverInfo.RoverPosition.X == 5 &&
                          roverInfo.RoverPosition.Y == 4);
        }

        public List<Obstacle> CreateObstacleList(string obstacleListString)
        {

            var obstacleList = new List<Obstacle>();
            var obstaclePointList = obstacleListString.Split(';');

            foreach (var obstaclePoint in obstaclePointList)
            {

                var xy = obstaclePoint.Split(',');

                var obstacle = new Obstacle(new Point(Convert.ToInt32(xy[0]), Convert.ToInt32(xy[1])));
                obstacleList.Add(obstacle);
            }

            return obstacleList;

        }

    }
}
