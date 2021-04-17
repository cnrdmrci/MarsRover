using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class MarsDiscover : IMarsDiscover
    {
        private readonly MarsArea _marsArea;
        private readonly ConcurrentBag<IRoverProcessor> _roverProcessorList;
        public MarsDiscover(MarsDiscoveryInformation marsDiscoveryInformation)
        {
            _roverProcessorList = new ConcurrentBag<IRoverProcessor>();
            _marsArea = GetMarsArea(marsDiscoveryInformation.Area);
            Parallel.ForEach(marsDiscoveryInformation.RoverInformationList, roverInfo =>
            {
                _roverProcessorList.Add(new RoverProcessor(_marsArea,roverInfo));
            });
        }

        public MarsArea GetMarsArea()
        {
            return _marsArea;
        }

        private MarsArea GetMarsArea(string area)
        {
            var areaInfo = area.Split(Constant.CHAR_SPACE);
            return new MarsArea
            {
                MaximumXaxis = Convert.ToInt32(areaInfo[0]),
                MaximumYaxis = Convert.ToInt32(areaInfo[1]),
                MinimumXaxis = 0,
                MinimumYaxis = 0
            };
        }

        private string GetDirectionStateKey(IDirectionState directionState)
        {
            return directionState switch
            {
                NorthState => Constant.NORTH_KEY,
                EastState => Constant.EAST_KEY,
                WestState => Constant.WEST_KEY,
                SouthState => Constant.SOUTH_KEY,
                _ => throw new Exception(Constant.UNDEFINED_DIRECTION)
            };
        }

        public string GetLocation(IRoverProcessor roverProcessor)
        {
            ILocation location = roverProcessor.GetRover().GetLocation();
            RoverLocation roverLocation = location.GetRoverLocation();

            IDirectionState directionState = roverProcessor.GetRover().GetDirectionState();
            string directionKey = GetDirectionStateKey(directionState);

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(roverLocation.CurrentXaxis);
            stringBuilder.Append(Constant.TEXT_SPACE);
            stringBuilder.Append(roverLocation.CurrentYaxis);
            stringBuilder.Append(Constant.TEXT_SPACE);
            stringBuilder.Append(directionKey);
            
            return stringBuilder.ToString();
        }

        public void ExecuteCommand()
        {
            Parallel.ForEach(_roverProcessorList, roverProcessor =>
            {
                ExecuteCommand(roverProcessor);
            });
        }

        public void ExecuteCommand(IRoverProcessor roverProcessor)
        {
            roverProcessor.GetRoverCommandList().ForEach(x => x.ExecuteCommand(roverProcessor.GetRover()));
        }

        public List<string> GetLocationList()
        {
            List<string> locationList = new List<string>();
            foreach (var roverProcessor in _roverProcessorList)
            {
                IRover rover = roverProcessor.GetRover();

                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(rover.GetLocation().GetRoverLocation().ToString());
                stringBuilder.Append(Constant.TEXT_SPACE);
                stringBuilder.Append(GetDirectionStateKey(rover.GetDirectionState()));

                locationList.Add(stringBuilder.ToString());
            }

            return locationList;
        }

        public List<RoverDiscoveryInformation> GetRoverInfoList()
        {
            return _roverProcessorList.Select(x => x.GetRoverDiscoveryInformation()).ToList();
        }
    }
}