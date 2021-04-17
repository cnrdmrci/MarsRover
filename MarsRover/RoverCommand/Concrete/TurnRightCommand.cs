namespace MarsRover
{
    public class TurnRightCommand : IRoverCommand
    {
        public void ExecuteCommand(IRover rover)
        {
            rover.TurnRight();
        }
    }
}