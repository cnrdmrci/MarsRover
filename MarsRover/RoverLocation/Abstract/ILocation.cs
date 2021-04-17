namespace MarsRover
{
    public interface ILocation
    {
        MarsArea GetMarsArea();
        RoverLocation GetRoverLocation();
        void MoveForward(IDirectionState directionState);
    }
}