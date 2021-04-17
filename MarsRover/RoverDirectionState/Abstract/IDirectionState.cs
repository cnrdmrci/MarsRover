namespace MarsRover
{
    public interface IDirectionState
    {
        IDirectionState TurnLeft();
        IDirectionState TurnRight();
    }
}