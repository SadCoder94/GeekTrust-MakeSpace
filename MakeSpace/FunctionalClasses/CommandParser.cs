using System;
using System.Collections.Generic;
using System.IO;

namespace MakeSpace.FunctionalClasses
{
    public static class CommandParser
    {
        public static List<Command> ParseCommands(string filePath)
        {
            var commands = new List<Command>();
            foreach (var commandString in File.ReadLines(@$"{filePath}"))
            {
                string[] command = commandString.Split(' ');
                bool isValidStartDate = DateTimeParser.TryParse(command[1], out DateTime startDate);
                bool isValidEndDate = DateTimeParser.TryParse(command[2], out DateTime endDate);

                switch (command[0])
                {
                    case "VACANCY":
                        commands.Add(new VacancyCommand(startDate, endDate, isValidStartDate && isValidEndDate));
                        break;
                    case "BOOK":
                        int capacity = int.TryParse(command[3], out int result) ? result : 0;
                        commands.Add(new BookCommand(startDate, endDate, capacity, isValidStartDate && isValidEndDate));
                        break;
                    default:
                        break;
                }
            }
            return commands;
        }
    }
}
