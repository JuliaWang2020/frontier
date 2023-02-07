using Frontier.CodeChallange.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontier.CodeChallange.Application.Interfaces
{
    public interface ITablePositionValidation
    {
        bool IsPositionValid(Position position);
    }
}
