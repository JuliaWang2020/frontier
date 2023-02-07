using Frontier.CodeChallange.Application.Commands;
using Frontier.CodeChallange.Application.Interfaces;
using Frontier.CodeChallange.Domain.Entities;
using Frontier.CodeChallange.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontier.CodeChallange.Application.Tests.MoqObject
{
    public class RobotMoveCommandMoq : RobotMoveCommand
    {
        public RobotMoveCommandMoq(ITableService tableService, ITablePositionValidation tablePositionValidation) : base(tableService, tablePositionValidation)
        {
        }

        public Position GetProtectedNextPosition(int x, int y, FacingDirection direction)
        {
            return GetNextPosition(x, y, direction);
        }
    }
}
