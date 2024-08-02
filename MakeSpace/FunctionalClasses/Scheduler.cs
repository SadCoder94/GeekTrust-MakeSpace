using MakeSpace.Member_Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MakeSpace.FunctionalClasses
{
    public interface IScheduler
    {
        void AddMeetingRooms(MeetingRoom room);
        string BookRoom(DateTime startTime, DateTime endTime, int personCapacity);
        string ViewVacancy(DateTime startTime, DateTime endTime);
    }

    public class Scheduler : IScheduler
    {
        private List<MeetingRoom> meetingRooms;
        private List<Booking> bookings;

        public Scheduler()
        {
        }

        public string BookRoom(DateTime startTime, DateTime endTime, int personCapacity)
        {
            if (personCapacity < (int)RoomConstraints.Min || personCapacity > (int)RoomConstraints.Max)
                return "NO_VACANT_ROOM";

            if (!IsValidTime(startTime) || !IsValidTime(endTime) || endTime <= startTime)
                return "INCORRECT_INPUT";

            foreach (var room in meetingRooms.OrderBy(r => r.Capacity))
            {
                if (room.Capacity >= personCapacity && IsRoomAvailable(room, startTime, endTime))
                {
                    bookings.Add(new Booking(startTime, endTime, personCapacity, room));
                    return room.Name;
                }
            }

            return "NO_VACANT_ROOM";
        }

        public string ViewVacancy(DateTime startTime, DateTime endTime)
        {
            if (!IsValidTime(startTime) || !IsValidTime(endTime) || endTime <= startTime)
                return "INCORRECT_INPUT";

            var availableRooms = meetingRooms
                .Where(room => IsRoomAvailable(room, startTime, endTime))
                .OrderBy(room => room.Capacity)
                .Select(room => room.Name);

            return string.Join(" ", availableRooms);
        }

        private bool IsRoomAvailable(MeetingRoom room, DateTime startTime, DateTime endTime)
        {
            if (IsBufferTime(startTime, endTime))
                return false;

            return !bookings.Any(b => b.Room == room &&
                                      ((startTime >= b.StartTime && startTime < b.EndTime) ||
                                       (endTime > b.StartTime && endTime <= b.EndTime)));
        }

        private static bool IsBufferTime(DateTime startTime, DateTime endTime)
        {
            var bufferTimes = new List<(TimeSpan, TimeSpan)>
            {
                (new TimeSpan(9, 0, 0), new TimeSpan(9, 15, 0)),
                (new TimeSpan(13, 15, 0), new TimeSpan(13, 45, 0)),
                (new TimeSpan(18, 45, 0), new TimeSpan(19, 0, 0))
            };

            return bufferTimes.Any(bt => (startTime.TimeOfDay < bt.Item2 && endTime.TimeOfDay > bt.Item1));
        }

        private static bool IsValidTime(DateTime time)
        {
            return time.Minute % (int)TimeConstraints.Quarter == 0;
        }

        public void AddMeetingRooms(MeetingRoom room)
        {
            meetingRooms.Add(room);
        }
    }

}
