using Frontier.CodeChallange.Application.Commands;
using Frontier.CodeChallange.Application.Interfaces;
using Frontier.CodeChallange.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ICommand = Frontier.CodeChallange.Application.Interfaces.ICommand;

namespace Frontier.CodeChallange.Application
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Inject all application level services
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<TableService>();
            services.AddScoped<ITableService>(x => x.GetRequiredService<TableService>());
            services.AddScoped<ITablePositionValidation>(x => x.GetRequiredService<TableService>());

            //// add commands
            services.AddScoped<ICommand, PlaceRobotOnTableCommand>();
            services.AddScoped<ICommand, RobotMoveLeftCommand>();
            services.AddScoped<ICommand, RobotMoveRightCommand>();
            services.AddScoped<ICommand, RobotMoveCommand>();
            services.AddScoped<ICommand, RobotReportCommand>();
            services.AddScoped<ICommand, ResetCommand>();
            
            services.AddScoped<ICommandFactory, CommandFactory>();
            return services;
        }
    }
}
