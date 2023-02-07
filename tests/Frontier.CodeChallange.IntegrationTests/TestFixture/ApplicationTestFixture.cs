using Frontier.CodeChallange.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotConsole;

namespace Frontier.CodeChallange.IntegrationTests.TestFixture
{
    public class ApplicationTestFixture : IDisposable
    {
        public readonly ICommandFactory CommandFactory;

        public ApplicationTestFixture()
        {
            var service = Startup.ConfigureServices().BuildServiceProvider();
            CommandFactory = service.GetRequiredService<ICommandFactory>();
        }

        public void Dispose()
        {
        }
    }
}
