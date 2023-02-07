using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontier.CodeChallange.Application.Interfaces
{
    public interface ICommandFactory
    {
        ICommand? GetCommand(string commandString);
    }
}
