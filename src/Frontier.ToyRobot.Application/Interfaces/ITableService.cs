using Frontier.CodeChallange.Application.Entities;
using Frontier.CodeChallange.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontier.CodeChallange.Application.Interfaces
{
    public interface ITableService
    {
        /// <summary>
        /// Gets table robot 
        /// </summary>
        /// <returns>
        ///   <br />
        /// </returns>
        ToyRobot GetTableRobot();
        void Reset();
    }
}
