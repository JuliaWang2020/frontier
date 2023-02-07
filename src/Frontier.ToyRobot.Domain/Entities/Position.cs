using Frontier.CodeChallange.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontier.CodeChallange.Domain.Entities
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public FacingDirection Direction { get; set; }
    }
}
