using System;
using System.Collections.Generic;

namespace MarsRover
{
    public class RoverProcessor : IRoverProcessor
    {
        private readonly IRover _rover;
        private readonly List<IRoverCommand> _roverCommandList;
        private readonly RoverDiscoveryInformation _roverDiscoveryInformation;

        public RoverProcessor(MarsArea marsArea, RoverDiscoveryInformation roverDiscoveryInformation)
        {
            _roverDiscoveryInformation = roverDiscoveryInformation;
            _rover = GetRover(marsArea,roverDiscoveryInformation.Location);
            _roverCommandList = GetRoverCommandList(roverDiscoveryInformation.Command);
        }

        public RoverDiscoveryInformation GetRoverDiscoveryInformation()
        {
            return _roverDiscoveryInformation;
        }

        public IRover GetRover()
        {
            return _rover;
        }

        public List<IRoverCommand> GetRoverCommandList()
        {
            return _roverCommandList;
        }

        private List<IRoverCommand> GetRoverCommandList(string command)
        {
            CommandParser commandParser = new CommandParser(command);
            return commandParser.GetRoverCommandList();
        }

        private Rover GetRover(MarsArea marsArea, string locationText)
        {
            RoverLocation roverLocation = GetRoverLocation(locationText);

            IDirectionState directionState = GetDirectionState(locationText);
            ILocation location = new Location(marsArea,roverLocation);

            return new Rover(directionState,location);
        }

        private RoverLocation GetRoverLocation(string location)
        {
            var areaInfo = location.Split(Constant.CHAR_SPACE);
            return new RoverLocation
            {
                CurrentXaxis = Convert.ToInt32(areaInfo[0]),
                CurrentYaxis = Convert.ToInt32(areaInfo[1])
            };
        }

        private IDirectionState GetDirectionState(string locationInfo)
        {
            string directionKey = locationInfo.Split(Constant.CHAR_SPACE)[2];
            return directionKey switch
            {
                Constant.NORTH_KEY => new NorthState(),
                Constant.EAST_KEY => new EastState(),
                Constant.WEST_KEY => new WestState(),
                Constant.SOUTH_KEY => new SouthState(),
                _ => throw new Exception(Constant.UNDEFINED_DIRECTION)
            };
        }
        
    }
}