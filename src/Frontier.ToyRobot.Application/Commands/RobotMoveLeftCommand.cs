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
    public class RobotMoveLeftCommand : RobotMoveBaseCommand
    {
        public RobotMoveLeftCommand(
            ITableService tableService,
            ITablePositionValidation tablePositionValidation)
            : base(tableService, tablePositionValidation)
        {
        }

        public override string CommandValidationString => @"LEFT\(\s*\)";

        public override CommandType CommandType => CommandType.RobotCommand;

        protected override Domain.Entities.Position GetNextPosition(int x, int y, FacingDirection direction)
        {

            switch (direction)
            {
                case FacingDirection.EAST:
                    direction = FacingDirection.NORTH;
                    break;
                case FacingDirection.WEST:
                    direction = FacingDirection.SOUTH;
                    break;
                case FacingDirection.NORTH:
                    direction = FacingDirection.WEST;
                    break;
                case FacingDirection.SOUTH:
                    direction = FacingDirection.EAST;
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
