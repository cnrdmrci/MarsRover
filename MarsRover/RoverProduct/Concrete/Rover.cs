namespace MarsRover
{
    public class Rover : IRover
    {
        private IDirectionState _directionState;
        private readonly ILocation _location;
        public Rover(IDirectionState directionState, ILocation location)
        {  
            _directionState = directionState;
            _location = location;
        }

        public void TurnLeft()
        {
            _directionState = _directionState.TurnLeft();
        }

        public void TurnRight()
        {
            _directionState = _directionState.TurnRight();
        }

        public void MoveForward()
        {
            _location.MoveForward(_directionState);
        }

        public ILocation GetLocation()
        {
            return _location;
        }

        public IDirectionState GetDirectionState()
        {
            return _directionState;
        }
    }
}