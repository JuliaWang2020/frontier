using Frontier.CodeChallange.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontier.CodeChallange.Application.Tests.Entities
{
    public class PlaceRobotOnTableTestCase
    {
        public CommandResponse ExpectedReponse { get; set; }
        public string InputCommand { get; set; }
        public bool IsPlacedOnTable { get; set; }
        public int? TableWidth { get; set; }
        public string TestName { get; set; }

        public override string ToString()
        {
            return TestName;
        }
    }
}
