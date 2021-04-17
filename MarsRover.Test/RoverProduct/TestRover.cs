using FluentAssertions;
using NUnit.Framework;

namespace MarsRover.Test
{
    public class TestRover
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

        [Test]
        public void Rover_WhenTurnLeft_ThenTurnedLeft()
        {
            //Given
            ILocation location = new Location(_defaultMarsArea,_defaultRoverLocation);
            IRover rover = new Rover(new NorthState(),location);

            //When
            rover.TurnLeft();

            //Then
            rover.GetDirectionState().GetType().Equals(typeof(WestState));
        }

        [Test]
        public void Rover_WhenTurnRight_ThenTurnedRight()
        {
            //Given
            ILocation location = new Location(_defaultMarsArea,_defaultRoverLocation);
            IRover rover = new Rover(new NorthState(),location);

            //When
            rover.TurnRight();

            //Then
            rover.GetDirectionState().GetType().Equals(typeof(EastState));
        }

        [Test]
        public void Rover_WhenMoveForward_ThenMovedForward()
        {
            //Given
            ILocation location = new Location(_defaultMarsArea,_defaultRoverLocation);
            IRover rover = new Rover(new NorthState(),location);

            //When
            rover.MoveForward();

            //Then
            RoverLocation expectedRoverLocation = new RoverLocation() {CurrentXaxis = 2, CurrentYaxis = 3};
            rover.GetLocation().GetRoverLocation().Should().BeEquivalentTo(expectedRoverLocation);
        }
    }
}