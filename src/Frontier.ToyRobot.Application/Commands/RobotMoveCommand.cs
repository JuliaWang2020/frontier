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
    public class RobotMoveCommand : RobotMoveBaseCommand
    {
        public RobotMoveCommand(
            ITableService tableService,
            ITablePositionValidation tablePositionValidation)
                : base(tableService, tablePositionValidation)
        {
        }

        public override string CommandValidationString => @"MOVE\(\s*\)";

        public override CommandType CommandType => CommandType.TableCommand;

        protected override Position GetNextPosition(int x, int y, FacingDirection direction)
        {
            switch (direction)
            {

                case FacingDirection.EAST:
                    x++;
                    break;
                case FacingDirection.WEST:
                    x--;
                    break;
                case FacingDirection.NORTH:
                    y++;
                    break;
                case FacingDirection.SOUTH:
                    y--;
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
