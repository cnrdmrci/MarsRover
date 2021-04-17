namespace MarsRover
{
    public class SouthState : IDirectionState
    {
        public IDirectionState TurnLeft()
        {
            return new EastState();
        }

        public IDirectionState TurnRight()
        {
            return new WestState();
        }
    }
}