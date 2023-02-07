using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontier.CodeChallange.IntegrationTests.Entities
{
    public class ToyRobotTestCase
    {
        public IList<CommandWithResponse> Inputs { get; set; }

        public string TestName { get; set; }

        public override string ToString()
        {
            return TestName;
        }
    }
}
