using Frontier.CodeChallange.Application.Entities;
using Frontier.CodeChallange.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontier.CodeChallange.Application.Interfaces
{
    public interface ICommand
    {
        string CommandValidationString { get; }

        CommandType CommandType { get; }

        CommandResponse ProcessCommand(string command);
    }
}
