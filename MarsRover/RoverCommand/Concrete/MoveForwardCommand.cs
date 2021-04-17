namespace MarsRover
{
    public class MoveForwardCommand : IRoverCommand
    {
        public void ExecuteCommand(IRover rover)
        {
            rover.MoveForward();
        }
    }
}