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
    public class ResetCommand : ICommand
    {
        private readonly ITableService _table;
        public ResetCommand(ITableService tableService)
        {
            _table = tableService ?? throw new ArgumentNullException(nameof(tableService));
        }

        public string CommandValidationString => @"RESET\(\)";

        public CommandType CommandType => CommandType.TableCommand;

        public CommandResponse ProcessCommand(string command)
        {
            _table.Reset();

            return new CommandResponse
            {
                Status = ResponseStatus.Success
            };
        }
    }
}
