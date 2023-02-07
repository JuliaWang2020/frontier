using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontier.CodeChallange.Domain.Entities
{
    public class Robot
    {

        public Position? Position { get; set; }

        public override string ToString()
        {
            return Position == null
                ? string.Empty
                : $"{Position.X},{Position.Y},{Position.Direction}";
        }
    }
}
