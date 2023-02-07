using FluentAssertions;
using Frontier.CodeChallange.Application.Interfaces;
using Frontier.CodeChallange.IntegrationTests.Entities;
using Frontier.CodeChallange.IntegrationTests.TestCases;
using Frontier.CodeChallange.IntegrationTests.TestFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontier.CodeChallange.IntegrationTests
{
    public class ToyRobotTestscs : IClassFixture<ApplicationTestFixture>
    {
        private readonly ICommandFactory _commandFactory;
        public ToyRobotTestscs(ApplicationTestFixture fixture)
        {
            // Arrange
            _commandFactory = fixture.CommandFactory;
        }

        [Theory]
        [ClassData(typeof(ToyRobotTestCases))]
        public void ToyRobot_Should_Work(ToyRobotTestCase data)
        {
            // Act && Assert
            foreach (var inputCommand in data.Inputs)
            {
                var command = _commandFactory.GetCommand(inputCommand.InputCommand);
                command.Should().NotBeNull();
                var response = command.ProcessCommand(inputCommand.InputCommand);
                response.Should().BeEquivalentTo(inputCommand.ExpectedReponse);
            }
        }

    }
}
