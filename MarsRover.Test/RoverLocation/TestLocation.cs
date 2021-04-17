using NUnit.Framework;
using FluentAssertions;

namespace MarsRover.Test
{
    public class TestLocation
    {
        private MarsArea _defaultMarsArea;
        private RoverLocation _defaultRoverLocation;

        [SetUp]
        public void Setup()
        {
            _defaultMarsArea = new MarsArea()
            {
                MinimumXaxis = 0,
                MinimumYaxis = 0,
                MaximumXaxis = 5,
                MaximumYaxis = 5
            };

            _defaultRoverLocation = new RoverLocation()
            {
                CurrentXaxis = 2,
                CurrentYaxis = 2
            };
        }

        [TestCaseSource("TestCases")]
        public void FirstLocation_WhenMoveForward_ThenLastLocation(IDirectionState directionState, RoverLocation expectedRoverLocation)
        {
            //Given
            ILocation location = new Location(_defaultMarsArea,_defaultRoverLocation);

            //When
            location.MoveForward(directionState);

            //Then
            location.GetRoverLocation().Should().BeEquivalentTo(expectedRoverLocation);
        }

        private static readonly object[] TestCases =
        {
            new object[]
            {
                new NorthState(),
                new RoverLocation() { CurrentXaxis = 2, CurrentYaxis = 3 }
            },
            new object[]
            {
                new WestState(),
                new RoverLocation() { CurrentXaxis = 1, CurrentYaxis = 2 }
            },
            new object[]
            {
                new EastState(),
                new RoverLocation() { CurrentXaxis = 3, CurrentYaxis = 2 }
            },
            new object[]
            {
                new SouthState(),
                new RoverLocation() { CurrentXaxis = 2, CurrentYaxis = 1 }
            }
        };
    }
}