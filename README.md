# Frontier Technical Challenge

This is Julia Wang's coding exercise for Frontier: create an app that allows commands to be issued to the robot on a grid of 5X5 units. The robot should be prevented from
failing off the tabletop.

## Technical Decision

- C#
- .NET Core SDK 6
- Visual Studio 2022
- xUnit
- Moq

**Note:**
I use .net core 6 instead of 7.0, just because .net core 6 is a long-time supported version. The project could be converted to .net core 7.0 if needed.

## This solution is based on the below assumptions:

- Only allow on toy robot on the table
- Do not need create the table (This can be done with new command if needed)
- Do not need save toy robot information.
- Do not add the cache, but could add this if needed.
- No log needed. But could add NLog or Serilog with lines of code
- I added two commands for debug purpose: reset(), exit()

## Folder Description

- `src` project source code
- `tests` all tests
- `docs` origin coding exercise document

### src

- `ConsoleApp` main project
- `Application`
- `Infrastructure`
- `Domain`

## run program

### run with Visual Studio

You could start the project with Visual Studio and `Run` or `Debug` the **ToyRobotConsole** project

### run with docker

run below command at root
`docker compose up`
