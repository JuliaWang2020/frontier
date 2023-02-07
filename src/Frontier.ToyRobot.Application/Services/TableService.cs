using Frontier.CodeChallange.Application.Entities;
using Frontier.CodeChallange.Application.Interfaces;
using Frontier.CodeChallange.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontier.CodeChallange.Application.Services
{
    public class TableService : ITableService, ITablePositionValidation
    {
        private SquareTabletop _table;
        private ToyRobot _robot;
        public TableService()
        {
            _table = new SquareTabletop(5);
            // Currently we do not support multiple robot on table
            _robot = new ToyRobot();
        }

        public ToyRobot GetTableRobot()
        {
            return _robot;
        }

        public bool IsPositionValid(Position position)
        {
            if (position == null)
            {
                return false;
            }

            return position.X >= 0 &&
                position.Y >= 0 &&
                position.X < _table.Width &&
                position.Y < _table.Length;
        }

        public void Reset()
        {
            _robot.IsPlacedOnTable = false;
            _robot.Position = null;
        }
    }
}
