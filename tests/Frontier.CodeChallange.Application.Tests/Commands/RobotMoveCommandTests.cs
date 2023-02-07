using FluentAssertions;
using Frontier.CodeChallange.Application.Interfaces;
using Frontier.CodeChallange.Application.Tests.Entities;
using Frontier.CodeChallange.Application.Tests.MoqObject;
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
    public class RobotMoveCommandTests
    {
        private readonly string _command = "move()";

        [Theory]
        [ClassData(typeof(RobotMoveTestCases))]
        public void MoveCommand_Should_Work(RobotMoveTestCase data)
        {
            // Arrange
            var tableService = new Mock<ITableService>();
            var validationService = new Mock<ITablePositionValidation>();
            tableService.Setup(x => x.GetTableRobot()).Returns(new Application.Entities.ToyRobot
            {
                IsPlacedOnTable = data.IsPlacedOnTable,
                Position = data.CurrentLocation
            });

            if (data.TableWidth.HasValue)
            {
                validationService.Setup(x => x.IsPositionValid(It.IsAny<Position>())).Returns((Position x) => x.X >= 0
                    && x.Y >= 0
                    && x.X < data.TableWidth
                    && x.Y < data.TableWidth);
            }

            var command = new RobotMoveCommandMoq(tableService.Object, validationService.Object);

            // Act
            Position? nextLocation = null;
            if (data.CurrentLocation != null)
            {
                nextLocation = command.GetProtectedNextPosition(
                    data.CurrentLocation.X,
                    data.CurrentLocation.Y,
                    data.CurrentLocation.Direction);
            }

            var response = command.ProcessCommand(_command);

            // Assert
            if (data.ExpectedNextLocation != null)
            {
                nextLocation.Should().BeEquivalentTo(data.ExpectedNextLocation);
            }

            if (data.ExpectedReponse != null)
            {
                response.Should().BeEquivalentTo(data.ExpectedReponse);
            }
        }
    }
}
