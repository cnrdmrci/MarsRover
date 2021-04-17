namespace MarsRover
{
    public class MarsArea
    {
        public int MinimumXaxis { get; set; }
        public int MaximumXaxis { get; set; }
        public int MinimumYaxis { get; set; }
        public int MaximumYaxis { get; set; }

        public override string ToString()
        {
            return MaximumXaxis + Constant.TEXT_SPACE + MaximumYaxis;
        }
    }
}