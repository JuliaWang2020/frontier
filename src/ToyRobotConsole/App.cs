using Frontier.CodeChallange.Application.Enums;
using Frontier.CodeChallange.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ToyRobotConsole
{
    public class App
    {
        private readonly ICommandFactory _commandFactory;
        public App(ICommandFactory commandFactory)
        {
            _commandFactory = commandFactory ?? throw new ArgumentNullException(nameof(_commandFactory));
        }

        public void Run()
        {
            bool continueRun = true;

            WriteHelpInfo();

            while (continueRun)
            {
                var commandString = Console.ReadLine().Trim();
                if (string.Compare(commandString, "exit", StringComparison.CurrentCultureIgnoreCase) == 0)
                {
                    break;
                }

                var command = _commandFactory.GetCommand(commandString);

                if (command == null)
                {
                    // currently there is no out put for wrong command
                    continue;
                }

                var result = command.ProcessCommand(commandString);

                // could put more complex logic here to control the output
                if (result.Status == ResponseStatus.Success
                    && !string.IsNullOrWhiteSpace(result.Message))
                {
                    Console.WriteLine(result.Message);
                }
            }
        }

        private void WriteHelpInfo()
        {
            Console.WriteLine("Supported commands:");
            Console.WriteLine("place(x, y, facing)");
            Console.WriteLine("move()");
            Console.WriteLine("left()");
            Console.WriteLine("right()");
            Console.WriteLine("report()");
            Console.WriteLine("reset()");
            Console.WriteLine("exit()");
            Console.WriteLine("Please input command line");
        }
    }
}
