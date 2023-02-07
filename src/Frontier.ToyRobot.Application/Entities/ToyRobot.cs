using Frontier.CodeChallange.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontier.CodeChallange.Application.Entities
{
    public class ToyRobot : Robot
    {
        public bool IsPlacedOnTable { get; set; }
    }
}
