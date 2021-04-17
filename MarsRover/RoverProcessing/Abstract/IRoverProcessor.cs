using System.Collections.Generic;

namespace MarsRover
{
    public interface IRoverProcessor
    {
        RoverDiscoveryInformation GetRoverDiscoveryInformation();
        IRover GetRover();
        List<IRoverCommand> GetRoverCommandList();
    }
}