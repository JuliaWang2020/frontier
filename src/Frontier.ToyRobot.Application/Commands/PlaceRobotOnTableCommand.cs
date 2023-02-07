using Frontier.CodeChallange.Application.Entities;
using Frontier.CodeChallange.Application.Enums;
using Frontier.CodeChallange.Application.Interfaces;
using Frontier.CodeChallange.Domain.Entities;
using Frontier.CodeChallange.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Frontier.CodeChallange.Application.Commands
{
    public class PlaceRobotOnTableCommand : ICommand
    {
        private readonly ITableService _table;
        private readonly ITablePositionValidation _positionValidator;
        public PlaceRobotOnTableCommand(
            ITableService tableService,
            ITablePositionValidation positionValidator)
        {
            _table = tableService ?? throw new ArgumentNullException(nameof(tableService));
            _positionValidator = positionValidator ?? throw new ArgumentNullException(nameof(positionValidator));
        }

        public string CommandValidationString => @"PLACE\(\s*(\d)+\s*,\s*(\d+)\s*,\s*\'*(EAST|SOUTH|WEST|NORTH)\'*\s*\)";

        public CommandType CommandType => CommandType.TableCommand;

        public CommandResponse ProcessCommand(string command)
        {
            var matches = Regex.Matches(command, CommandValidationString, RegexOptions.IgnoreCase);
            if (matches == null || matches.Count != 1)
            {
                return new CommandResponse
                {
                    Status = ResponseStatus.Fail,
                    Message = "Command not match"
                };
            }

            var matchGroups = matches[0].Groups;

            var robot = _table.GetTableRobot();

            if (robot == null)
            {
                return new CommandResponse
                {
                    Status = ResponseStatus.Fail,
                    Message = "Could not find robot"
                };
            }

            // business requirment is not clear, can we use place command again
            // when robot is on the table ?????
            // assume we could use place command again here
            // but keep the code here
            //if (robot.IsPlacedOnTable)
            //{
            //    return new CommandResponse
            //    {
            //        Status = ResponseStatus.Fail,
            //        Message = "This command could not be used"
            //    };
            //}

            var position = new Position
            {
                X = int.Parse(matchGroups[1].Value),
                Y = int.Parse(matchGroups[2].Value),
                Direction = (FacingDirection)Enum.Parse(typeof(FacingDirection), matchGroups[3].Value, true)
            };

            if (!_positionValidator.IsPositionValid(position))
            {
                return new CommandResponse
                {
                    Status = ResponseStatus.Ignore,
                    Message = "Blocked"
                };
            }

            robot.IsPlacedOnTable = true;
            robot.Position = position;

            return new CommandResponse
            {
                Status = ResponseStatus.Success
            };
        }
    }
}
