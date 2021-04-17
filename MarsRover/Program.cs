using System;
using System.Collections.Generic;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            MarsDiscoveryInformation marsDiscoveryInformation = new MarsDiscoveryInformation()
            {
                Area = "5 5",
                RoverInformationList = new List<RoverDiscoveryInformation>()
                {
                    new RoverDiscoveryInformation()
                    {
                        Location = "1 2 N",
                        Command = "LMLMLMLMM"
                    },
                    new RoverDiscoveryInformation()
                    {
                        Location = "3 3 E",
                        Command = "MMRMMRMRRM"
                    }
                }
            };
            IMarsDiscover marsDiscovery = new MarsDiscover(marsDiscoveryInformation);

            ConsoleWriteInput(marsDiscovery);

            marsDiscovery.ExecuteCommand();

            ConsoleWriteOutput(marsDiscovery);
        }

        private static void ConsoleWriteInput(IMarsDiscover marsDiscovery)
        {
            Console.WriteLine("----INPUT----");
            Console.WriteLine(marsDiscovery.GetMarsArea().ToString());
            foreach (var roverInformation in marsDiscovery.GetRoverInfoList())
            {
                Console.WriteLine(roverInformation.Location);
                Console.WriteLine(roverInformation.Command);
            }
        }

        private static void ConsoleWriteOutput(IMarsDiscover marsDiscovery)
        {
            Console.WriteLine("----OUTPUT----");
            marsDiscovery.GetLocationList().ForEach( x => Console.WriteLine(x));
        }
    }
}
