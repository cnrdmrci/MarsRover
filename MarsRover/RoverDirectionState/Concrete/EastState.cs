namespace MarsRover
{
    public class EastState : IDirectionState
    {
        public IDirectionState TurnLeft()
        {
            return new NorthState();
        }

        public IDirectionState TurnRight()
        {
            return new SouthState();
        }
    }
}