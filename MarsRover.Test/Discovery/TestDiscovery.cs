using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace MarsRover.Test
{
    public class TestDiscovery
    {
        private MarsDiscoveryInformation _marsDiscoveryInformation;

        private static readonly object[] TestCasesForSuccess =
        {
            new object[]
            {
                new MarsDiscoveryInformation()
                {
                    Area = "5 5",
                    RoverInformationList = new List<RoverDiscoveryInformation>()
                    {
                        new RoverDiscoveryInformation()
                        {
                            Location = "1 2 N",
                            Command = "LMLMLMLMM"
                        }
                    }
                },
                new List<string>()
                {
                    "1 3 N"
                }
            },
            new object[]
            {
                new MarsDiscoveryInformation()
                {
                    Area = "5 5",
                    RoverInformationList = new List<RoverDiscoveryInformation>()
                    {
                        new RoverDiscoveryInformation()
                        {
                            Location = "3 3 E",
                            Command = "MMRMMRMRRM"
                        }
                    }
                },
                new List<string>()
                {
                    "5 1 E"
                }
            }
        };

        [SetUp]
        public void Setup()
        {
            _marsDiscoveryInformation = new MarsDiscoveryInformation()
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
        }

        [Test]
        public void MarsDiscover_WhenSetMarsArea_ThenGetExpectedMarsArea()
        {
            //Given
            IMarsDiscover marsDiscover = new MarsDiscover(_marsDiscoveryInformation);

            //When
            MarsArea marsArea = marsDiscover.GetMarsArea();

            //Then
            MarsArea expectedMarsArea = new MarsArea()
            {
                MinimumXaxis = 0,
                MinimumYaxis = 0,
                MaximumXaxis = 5,
                MaximumYaxis = 5
            };
            marsArea.Should().BeEquivalentTo(expectedMarsArea);
        }

        [TestCaseSource("TestCasesForSuccess")]
        public void MarsDiscover_WhenCommandExecute_ThenExpectedLocation(MarsDiscoveryInformation marsDiscoveryInformation,List<string> expectedLocationList)
        {
            //Given
            IMarsDiscover marsDiscover = new MarsDiscover(marsDiscoveryInformation);

            //When
            marsDiscover.ExecuteCommand();

            //Then
            List<string> locationList = marsDiscover.GetLocationList();
            locationList.Should().BeEquivalentTo(expectedLocationList);
        }
    }
}