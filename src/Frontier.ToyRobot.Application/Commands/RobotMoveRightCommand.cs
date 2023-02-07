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
    public class RobotMoveRightCommand : RobotMoveBaseCommand
    {
        public RobotMoveRightCommand(
            ITableService tableService,
            ITablePositionValidation tablePositionValidation)
            : base(tableService, tablePositionValidation)
        {
        }

        public override string CommandValidationString => @"RIGHT\(\s*\)";

        public override CommandType CommandType => CommandType.RobotCommand;

        protected override Position GetNextPosition(int x, int y, FacingDirection direction)
        {
            switch (direction)
            {
                case FacingDirection.EAST:
                    direction = FacingDirection.SOUTH;
                    break;
                case FacingDirection.WEST:
                    direction = FacingDirection.NORTH;
                    break;
                case FacingDirection.NORTH:
                    direction = FacingDirection.EAST;
                    break;
                case FacingDirection.SOUTH:
                    direction = FacingDirection.WEST;
                    break;
            }

            return new Position
            {
                X = x,
                Y = y,
                Direction = direction
            };
        }
    }
}
