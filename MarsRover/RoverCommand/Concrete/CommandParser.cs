using System;
using System.Collections.Generic;

namespace MarsRover
{
    public class CommandParser
    {
        private readonly string _commandText;
        public CommandParser(string commandText)
        {  
            _commandText = commandText;
        }
        public List<IRoverCommand> GetRoverCommandList()
        {
            List<IRoverCommand> roverCommandList = new List<IRoverCommand>();

            foreach (char command in _commandText)
            {
                roverCommandList.Add(GetRoverCommandFromCommandText(command));
            }

            return roverCommandList;
        }

        private IRoverCommand GetRoverCommandFromCommandText(char command)
        {
            return command switch
            {
                Constant.LEFT_SIDE_DIRECTION => new TurnLeftCommand(),
                Constant.RIGHT_SIDE_DIRECTION => new TurnRightCommand(),
                Constant.FORWARD_SIDE_DIRECTION => new MoveForwardCommand(),
                _ => throw new Exception(Constant.UNDEFINED_COMMAND)
            };
        }
    }
}