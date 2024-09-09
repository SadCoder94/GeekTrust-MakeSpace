using MakeSpace.FunctionalClasses;
using MakeSpace.Member_Classes;
using System;
using System.Collections.Generic;
using Xunit;

namespace MakeSpaceUnitTests
{
    public class SchedulerTests
    {
        public Scheduler Setup()
        {
            List<MeetingRoom> meetingRooms = new List<MeetingRoom>
            {
            new MeetingRoom("C-Cave", 3),
            new MeetingRoom("D-Tower", 7),
            new MeetingRoom("G-Mansion", 20)
            };

            return new Scheduler(meetingRooms);
        }

        [Fact]
        public void BookRoom_ShouldReturnRoomName_WhenRoomAvailable()
        {

            var scheduler = Setup();
            var result = scheduler.BookRoom(new DateTime(2024, 9, 10, 10, 0, 0), new DateTime(2024, 9, 10, 11, 0, 0), 5);


            Assert.Equal("D-Tower", result);
        }

        [Fact]
        public void BookRoom_ShouldReturnNoVacantRoom_WhenNoRoomAvailable()
        {
            var scheduler = Setup();
            var result = scheduler.BookRoom(new DateTime(2024, 9, 10, 10, 0, 0), new DateTime(2024, 9, 10, 11, 0, 0), 25);

            Assert.Equal("NO_VACANT_ROOM", result);
        }

        [Fact]
        public void BookRoom_ShouldReturnIncorrectInput_WhenEndTimeIsBeforeStartTime()
        {
            var scheduler = Setup();
            var result = scheduler.BookRoom(new DateTime(2024, 9, 10, 11, 0, 0), new DateTime(2024, 9, 10, 10, 0, 0), 5);

            Assert.Equal("INCORRECT_INPUT", result);
        }

        [Fact]
        public void ViewVacancy_ShouldReturnRoomNames_WhenRoomsAreAvailable()
        {
            var scheduler = Setup();
            var result = scheduler.ViewVacancy(new DateTime(2024, 9, 10, 10, 0, 0), new DateTime(2024, 9, 10, 11, 0, 0));


            Assert.Equal("C-Cave D-Tower G-Mansion", result);
        }

        [Fact]
        public void ViewVacancy_ShouldReturnNoVacantRoom_WhenNoRoomIsAvailable()
        {
            var scheduler = Setup();
            var result = scheduler.ViewVacancy(new DateTime(2024, 9, 10, 9, 10, 0), new DateTime(2024, 9, 10, 9, 20, 0));

            Assert.Equal("NO_VACANT_ROOM", result);
        }

        [Fact]
        public void ViewVacancy_ShouldReturnIncorrectInput_WhenEndTimeIsBeforeStartTime()
        {
            var scheduler = Setup();
            var result = scheduler.ViewVacancy(new DateTime(2024, 9, 10, 11, 0, 0), new DateTime(2024, 9, 10, 10, 0, 0));

            Assert.Equal("INCORRECT_INPUT", result);
        }

        [Fact]
        public void BookRoom_ShouldReturnNoVacantRoom_WhenBookingDuringBufferTime()
        {
            var scheduler = Setup();
            var result = scheduler.BookRoom(new DateTime(2024, 9, 10, 9, 10, 0), new DateTime(2024, 9, 10, 9, 20, 0), 5);

            Assert.Equal("NO_VACANT_ROOM", result);
        }

        [Fact]
        public void BookRoom_ShouldAllowBooking_WhenOutsideBufferTime()
        {
            var scheduler = Setup();
            var result = scheduler.BookRoom(new DateTime(2024, 9, 10, 10, 0, 0), new DateTime(2024, 9, 10, 11, 0, 0), 5);

            Assert.Equal("D-Tower", result);  // Room with closest capacity
        }
    }
}