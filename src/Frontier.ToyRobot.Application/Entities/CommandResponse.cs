using Frontier.CodeChallange.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontier.CodeChallange.Application.Entities
{
    public class CommandResponse
    {
        public ResponseStatus Status { get; set; }
        public string Message { get; set; }
    }
}
