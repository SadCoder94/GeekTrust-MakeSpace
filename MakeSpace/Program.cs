using MakeSpace.FunctionalClasses;
using MakeSpace.Member_Classes;
using System;
using System.Collections.Generic;
using System.IO;

namespace MakeSpace
{
    public class Program
    {
        static void Main(string[] args)
        {
            var rooms = new List<MeetingRoom>
            {
                new MeetingRoom("C-Cave", 3),
                new MeetingRoom("D-Tower", 7),
                new MeetingRoom("G-Mansion", 20)
            };

            var scheduler = new Scheduler(rooms);

            if (args.Length > 0 && !string.IsNullOrEmpty(args[0]))
            {
                var commands = CommandParser.ParseCommands(args[0]);
                foreach (var command in commands)
                {
                    var result = command.Execute(scheduler);
                    Console.WriteLine(result);
                }
            }


        }
    }
}
