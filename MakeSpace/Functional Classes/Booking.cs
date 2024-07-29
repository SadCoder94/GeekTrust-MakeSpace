using MakeSpace.Member_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeSpace.Functional_Classes
{
    public class Booking
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int PersonCapacity { get; set; }
        public MeetingRoom Room { get; set; }

        public Booking(DateTime startTime, DateTime endTime, int personCapacity, MeetingRoom room)
        {
            StartTime = startTime;
            EndTime = endTime;
            PersonCapacity = personCapacity;
            Room = room;
        }
    }

}
