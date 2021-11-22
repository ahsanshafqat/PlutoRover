using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlutoRover.Api
{
    public partial class Rover
    {
        private Grid _grid;
        private Point _currentRoverPosition;
        private string _currentRoverDirection;
       
        public Rover(Grid grid,
                     Point roverStartingPosition,
                     string roverDirection)
        {


            _grid = grid;
            _currentRoverDirection = roverDirection.ToUpper();
            _currentRoverPosition = roverStartingPosition;

            ValidateRoverStartingPosition();
            ValidateRoverStartingDirection();
        }

        private void ValidateRoverStartingPosition()
        {
            _grid.ValidateRoverStartingPosition(_currentRoverPosition);

        }

        private void ValidateRoverStartingDirection()
        {

            if (_currentRoverDirection != Direction.North &&
                _currentRoverDirection != Direction.South &&
                _currentRoverDirection != Direction.West &&
                _currentRoverDirection != Direction.East)

            {
                throw new Exceptions.RoverStartingDirectionInvalidException(string.Format("Rover starting direction [{0}] is not valid", _currentRoverDirection));
            }

        }

       public RoverInfo MoveAndTurn(string roverCommands)
        {

            int cont = 0;
            char roverCommand;
            bool obstacleFound = false;
            MoveRoverResponse response;

            var roverCommandList = roverCommands.ToUpper().ToCharArray();
                      
            if (roverCommandList.Count() > 0)
                do
                {

                    roverCommand = roverCommandList[cont];

                    switch (roverCommand)
                    {

                        case RoverCommand.MoveForward:
                            response = _grid.MoveRover(roverCommand, _currentRoverDirection, _currentRoverPosition);
                            _currentRoverPosition = response.RoverPosition;
                            obstacleFound = response.RoverHasBeenBlockedByObstacle;
                            break;

                        case RoverCommand.MoveBackward:
                            response = _grid.MoveRover(roverCommand, _currentRoverDirection, _currentRoverPosition);
                            _currentRoverPosition = response.RoverPosition;
                            obstacleFound = response.RoverHasBeenBlockedByObstacle;
                            break;

                        case RoverCommand.TurnRight:
                            _currentRoverDirection = _grid.TurnRoverRight(_currentRoverDirection);
                            break;

                        case RoverCommand.TurnLeft:
                            _currentRoverDirection = _grid.TurnRoverLeft(_currentRoverDirection);
                            break;
                            
                    }

                    cont++;
                    
                } while (cont < roverCommandList.Count() && obstacleFound == false);

            var roverInfo = new RoverInfo() { RoverPosition = _currentRoverPosition, RoverDirection = _currentRoverDirection, RoverHasBeenBlockedByObstacle = obstacleFound };

            return roverInfo;
        }
    }
}
