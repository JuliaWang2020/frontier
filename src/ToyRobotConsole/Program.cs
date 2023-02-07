// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using ToyRobotConsole;

var services = Startup.ConfigureServices().BuildServiceProvider();

var app = services.GetRequiredService<App>();

app.Run();
