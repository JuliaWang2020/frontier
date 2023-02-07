using Frontier.CodeChallange.Application.Entities;
using Frontier.CodeChallange.Application.Enums;
using Frontier.CodeChallange.Application.Interfaces;
using Frontier.CodeChallange.Domain.Entities;
using Frontier.CodeChallange.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontier.CodeChallange.Application.Commands
{
    public abstract class RobotMoveBaseCommand : ICommand
    {
        private readonly ITableService _table;
        private readonly ITablePositionValidation _positionValidator;
        public RobotMoveBaseCommand(
            ITableService tableService,
            ITablePositionValidation tablePositionValidation)
        {
            _table = tableService ?? throw new ArgumentNullException(nameof(tableService));
            _positionValidator = tablePositionValidation ?? throw new ArgumentNullException(nameof(tablePositionValidation));
        }

        public abstract string CommandValidationString { get; }

        public abstract CommandType CommandType { get; }

        protected abstract Position GetNextPosition(int x, int y, FacingDirection direction);

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

            if (robot.Position == null)
            {
                return new CommandResponse
                {
                    Status = ResponseStatus.Fail,
                    Message = "Could not get current location"
                };
            }

            var nextPostion = GetNextPosition(
                robot.Position.X,
                robot.Position.Y,
                robot.Position.Direction);


            if (!_positionValidator.IsPositionValid(nextPostion))
            {
                return new CommandResponse
                {
                    Status = ResponseStatus.Ignore,
                    Message = "Blocked"
                };
            }

            robot.Position = nextPostion;

            return new CommandResponse
            {
                Status = ResponseStatus.Success
            };
        }
    }
}
