using Frontier.CodeChallange.Application.Entities;
using Frontier.CodeChallange.Application.Enums;
using Frontier.CodeChallange.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontier.CodeChallange.Application.Commands
{
    public class RobotReportCommand : ICommand
    {
        private readonly ITableService _table;
        public RobotReportCommand(
            ITableService tableService,
            ITablePositionValidation tablePositionValidation)
        {
            _table = tableService ?? throw new ArgumentNullException(nameof(tableService));
        }

        public string CommandValidationString => @"REPORT\(\s*\)";

        public CommandType CommandType => CommandType.RobotCommand;

        public CommandResponse ProcessCommand(string command)
        {
            var robot = _table.GetTableRobot();

            if (robot == null)
            {
                return new CommandResponse
                {
                    Status = ResponseStatus.Ignore
                };
            }

            if (!robot.IsPlacedOnTable)
            {
                return new CommandResponse
                {
                    Status = ResponseStatus.Ignore
                };
            }

            return new CommandResponse
            {
                Status = ResponseStatus.Success,
                Message = robot.ToString()
            };
        }
    }
}
