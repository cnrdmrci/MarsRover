using NUnit.Framework;
using System;

namespace MarsRover.Test
{
    public class TestDirectionState
    {

        [TestCaseSource("TestCases")]
        public void Direction_WhenTurnDirection_ThenExpectedDirection(IDirectionState directionState, Type leftDirectionType, Type rightDirectionType)
        {
            //Given from parameter

            //When
            IDirectionState turnedLeftDirectionState = directionState.TurnLeft();
            IDirectionState turnedRightDirectionState = directionState.TurnRight();

            //Then
            Assert.AreEqual(turnedLeftDirectionState.GetType(),leftDirectionType);
            Assert.AreEqual(turnedRightDirectionState.GetType(),rightDirectionType);
        }

        private static readonly object[] TestCases =
        {
            new object[] { new NorthState(), typeof(WestState), typeof(EastState)},
            new object[] { new SouthState(), typeof(EastState), typeof(WestState)},
            new object[] { new WestState(), typeof(SouthState), typeof(NorthState)},
            new object[] { new EastState(), typeof(NorthState), typeof(SouthState)},
        };
    }
}