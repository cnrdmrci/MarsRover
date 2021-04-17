using NUnit.Framework;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System;

namespace MarsRover.Test
{
    public class TestCommandParser
    {
        [TestCaseSource("TestCases")]
        public void CommandText_WhenParseToCommandList_ThenExpectedCommandListEqual(string commandText, List<IRoverCommand> expectedRoverCommandList)
        {
            //Given
            CommandParser commandParser = new CommandParser(commandText);

            //When
            List<IRoverCommand> roverCommandList = commandParser.GetRoverCommandList();

            //Then
            IEnumerable<Type> roverCommandTypeList = roverCommandList.Select(x => x.GetType());
            IEnumerable<Type> expectedRoverCommandTypeList = expectedRoverCommandList.Select(x => x.GetType());

            CollectionAssert.AreEqual(roverCommandTypeList,expectedRoverCommandTypeList);
        }

        private static readonly object[] TestCases =
        {
            new object[]
            {
                "LRMLMLMLMM",
                new List<IRoverCommand>()
                {
                    new TurnLeftCommand(),
                    new TurnRightCommand(),
                    new MoveForwardCommand(),
                    new TurnLeftCommand(),
                    new MoveForwardCommand(),
                    new TurnLeftCommand(),
                    new MoveForwardCommand(),
                    new TurnLeftCommand(),
                    new MoveForwardCommand(),
                    new MoveForwardCommand()
                }
            }
        };
    }
}