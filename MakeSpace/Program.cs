using MakeSpace.Functional_Classes;
using MakeSpace.Member_Classes;
using System;
using System.Collections.Generic;

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

            var scheduler = new Scheduler();

            foreach (var room in rooms)
            {
                scheduler.AddMeetingRooms(room);
            }


        }
    }
}
