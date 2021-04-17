using System;

namespace MarsRover
{
    public class Location : ILocation
    {
        private readonly MarsArea _marsArea;
        private readonly RoverLocation _roverLocation;
        public Location(MarsArea marsArea, RoverLocation roverLocation)
        {
            _marsArea = marsArea;
            _roverLocation = roverLocation;
        }

        public MarsArea GetMarsArea()
        {
            return _marsArea;
        }

        public RoverLocation GetRoverLocation()
        {
            return _roverLocation;
        }

        public void MoveForward(IDirectionState directionState)
        {
            switch(directionState)
            {
                case NorthState: MoveNorth();
                    break;
                case EastState: MoveEast();
                    break;
                case WestState: MoveWest();
                    break;
                case SouthState: MoveSouth();
                    break;
                default:
                    throw new Exception(Constant.UNDEFINED_DIRECTION);
            };
        }

        private void MoveEast()
        {
            ControlPositiveAxisMovement(_marsArea.MaximumXaxis,_roverLocation.CurrentXaxis);
            _roverLocation.CurrentXaxis += 1;
        }

        private void MoveNorth()
        {
            ControlPositiveAxisMovement(_marsArea.MaximumYaxis,_roverLocation.CurrentYaxis);
            _roverLocation.CurrentYaxis += 1;
        }

        private void MoveSouth()
        {
            ControlNegativeAxisMovement(_marsArea.MinimumYaxis,_roverLocation.CurrentYaxis);
            _roverLocation.CurrentYaxis -= 1;
        }

        private void MoveWest()
        {
            ControlNegativeAxisMovement(_marsArea.MinimumXaxis,_roverLocation.CurrentXaxis);
            _roverLocation.CurrentXaxis -= 1;
        }

        private void ControlPositiveAxisMovement(int maxAxis, int currentAxis)
        {
            if(currentAxis + 1 > maxAxis)
            {
                throw new Exception(Constant.OUT_OF_RANGE);
            }
        }

        private void ControlNegativeAxisMovement(int minAxis, int currentAxis)
        {
            if(currentAxis - 1 < minAxis)
            {
                throw new Exception(Constant.OUT_OF_RANGE);
            }
        }
    }
}