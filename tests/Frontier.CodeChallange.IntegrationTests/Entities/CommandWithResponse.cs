using Frontier.CodeChallange.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontier.CodeChallange.IntegrationTests.Entities
{
    public class CommandWithResponse
    {
        public string InputCommand { get; set; }
        public CommandResponse ExpectedReponse { get; set; }
    }
}
