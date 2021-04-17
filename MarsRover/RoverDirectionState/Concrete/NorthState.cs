namespace MarsRover
{
    public class NorthState : IDirectionState
    {
        public IDirectionState TurnLeft()
        {
            return new WestState();
        }

        public IDirectionState TurnRight()
        {
            return new EastState();
        }
    }
}