namespace MarsRover
{
    public class WestState : IDirectionState
    {
        public IDirectionState TurnLeft()
        {
            return new SouthState();
        }

        public IDirectionState TurnRight()
        {
            return new NorthState();
        }
    }
}