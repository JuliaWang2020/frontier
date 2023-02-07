using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontier.CodeChallange.Domain.Entities
{
    public class SquareTabletop
    {
        public SquareTabletop(int width)
        {
            Width = width;
        }

        public int Width { get; set; }
        public int Length => Width;
    }
}
