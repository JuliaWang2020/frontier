using Frontier.CodeChallange.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Frontier.CodeChallange.Application.Commands
{
    public class CommandFactory : ICommandFactory
    {
        public IEnumerable<ICommand> _commands;

        public CommandFactory(IEnumerable<ICommand> commands)
        {
            _commands = commands;
        }

        public ICommand? GetCommand(string commandString)
        {
            if (_commands == null || !_commands.Any())
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(commandString))
            {
                return null;
            }

            return _commands.FirstOrDefault(x => Regex.IsMatch(
               commandString,
               x.CommandValidationString,
               RegexOptions.IgnoreCase));
        }
    }
}
