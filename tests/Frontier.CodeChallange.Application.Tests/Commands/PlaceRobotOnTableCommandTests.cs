using FluentAssertions;
using Frontier.CodeChallange.Application.Commands;
using Frontier.CodeChallange.Application.Entities;
using Frontier.CodeChallange.Application.Enums;
using Frontier.CodeChallange.Application.Interfaces;
using Frontier.CodeChallange.Application.Tests.Entities;
using Frontier.CodeChallange.Application.Tests.TestCases;
using Frontier.CodeChallange.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontier.CodeChallange.Application.Tests.Commands
{
    public class PlaceRobotOnTableCommandTests
    {
        private readonly Mock<ITableService> _mockTable;
        private readonly Mock<ITablePositionValidation> _mockValidation;
        public PlaceRobotOnTableCommandTests()
        {
            _mockTable = new Mock<ITableService>();
            _mockValidation = new Mock<ITablePositionValidation>();
        }


        /// <summary>
        /// This test focus on command parsing only, and do not care about position
        /// 
        /// </summary>
        /// <param name="commandString">The command string.</param>
        [Theory]
        [InlineData("place(1,1,EAST)")]
        [InlineData("place( 1,1, EAST)")]
        [InlineData("place( 1,1 ,EAST)")]
        [InlineData("place( 1,1,east)")]
        [InlineData("place( 1, 1,EAST)")]
        [InlineData("place( 1, 1 ,EAST)")]
        [InlineData("place( \t1,1,EAST)")]
        [InlineData("place( 1, 1\t,EAST)")]
        [InlineData("place( 1 , 1,EAST)")]
        [InlineData("place( 1,1,EAST )")]
        public void PlaceRobotOnTableCommand_Should_Work_When_There_is_Space_in_Command(string commandString)
        {
            /// Arrange
            _mockValidation.Setup(x => x.IsPositionValid(It.IsAny<Position>())).Returns(true);
            _mockTable.Setup(x => x.GetTableRobot()).Returns(new ToyRobot
            {
                IsPlacedOnTable = false
            });
            var command = new PlaceRobotOnTableCommand(_mockTable.Object, _mockValidation.Object);

            /// Act
            var result = command.ProcessCommand(commandString);

            /// Assert
            result.Should().NotBeNull();
            result.Status.Should().Be(ResponseStatus.Success);
        }



        /// <summary>
        /// Places the robot on table command business logic
        /// </summary>
        /// <param name="data">The data.</param>
        [Theory]
        [ClassData(typeof(PlaceRobotOnTableTestCases))]
        public void PlaceRobotOnTableCommand_Should_Work_For_Different_Input(PlaceRobotOnTableTestCase data)
        {
            /// Arrange
            _mockTable.Setup(x => x.GetTableRobot()).Returns(new ToyRobot
            {
                IsPlacedOnTable = data.IsPlacedOnTable
            });

            if (data.TableWidth.HasValue)
            {
                _mockValidation.Setup(x => x.IsPositionValid(It.IsAny<Position>())).Returns((Position x) => x.X >= 0
                    && x.Y >= 0
                    && x.X < data.TableWidth
                    && x.Y < data.TableWidth);
            }

            var command = new PlaceRobotOnTableCommand(_mockTable.Object, _mockValidation.Object);

            /// Act
            var result = command.ProcessCommand(data.InputCommand);

            /// Assert
            result.Should().BeEquivalentTo(data.ExpectedReponse);
        }

    }
}
