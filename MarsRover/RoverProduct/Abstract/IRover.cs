namespace MarsRover
{
    public interface IRover
    {
        void TurnLeft();
        void TurnRight();
        void MoveForward();
        ILocation GetLocation();
        IDirectionState GetDirectionState();
    }
}