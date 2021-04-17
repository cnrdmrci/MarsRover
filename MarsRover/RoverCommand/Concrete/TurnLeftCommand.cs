namespace MarsRover
{
    public class TurnLeftCommand : IRoverCommand
    {
        public void ExecuteCommand(IRover rover)
        {
            rover.TurnLeft();
        }
    }
}