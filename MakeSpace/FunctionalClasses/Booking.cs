using MakeSpace.Member_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeSpace.FunctionalClasses
{
    public interface IBooking
    {
        DateTime EndTime { get;}
        int PersonCapacity { get; }
        MeetingRoom Room { get; }
        DateTime StartTime { get; }
    }

    public class Booking : IBooking
    {
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public int PersonCapacity { get; private set; }
        public MeetingRoom Room { get; private set; }

        public Booking(DateTime startTime, DateTime endTime, int personCapacity, MeetingRoom room)
        {
            StartTime = startTime;
            EndTime = endTime;
            PersonCapacity = personCapacity;
            Room = room;
        }
    }

}
