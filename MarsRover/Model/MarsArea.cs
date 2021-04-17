namespace MarsRover
{
    public class RoverLocation
    {
        public int CurrentXaxis { get; set; }
        public int CurrentYaxis { get; set; }

        public override string ToString()
        {
            return CurrentXaxis + Constant.TEXT_SPACE + CurrentYaxis;
        }
    }
}