using System.Collections.Generic;

namespace MarsRover
{
    public interface IMarsDiscover
    {
        MarsArea GetMarsArea();
        List<RoverDiscoveryInformation> GetRoverInfoList();
        List<string> GetLocationList();
        void ExecuteCommand();
    }
}