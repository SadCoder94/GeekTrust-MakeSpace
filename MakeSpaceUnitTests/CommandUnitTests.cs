using MakeSpace.FunctionalClasses;
using Moq;
using System;
using Xunit;

namespace MakeSpaceUnitTests
{
    public class CommandTests
    {
        private Mock<IScheduler> schedulerMock;

        public CommandTests()
        {
            schedulerMock = new Mock<IScheduler>(); // Mock the Scheduler class
        }

        [Fact]
        public void VacancyCommand_ValidInput_ReturnsVacancies()
        {
            // Arrange
            var startDate = new DateTime(2024, 9, 9, 9, 0, 0); // 9:00 AM
            var endDate = new DateTime(2024, 9, 9, 10, 0, 0);  // 10:00 AM
            var command = new VacancyCommand(startDate, endDate, true);

            schedulerMock.Setup(s => s.ViewVacancy(startDate, endDate)).Returns("Available");

            // Act
            var result = command.Execute(schedulerMock.Object);

            // Assert
            Assert.Equal("Available", result);
        }

        [Fact]
        public void VacancyCommand_EndTimeLessThanStartTime_ReturnsIncorrectInput()
        {
            // Arrange
            var startDate = new DateTime(2024, 9, 9, 10, 0, 0); // 10:00 AM
            var endDate = new DateTime(2024, 9, 9, 9, 0, 0);   // 9:00 AM
            var command = new VacancyCommand(startDate, endDate, true);

            // Act
            var result = command.Execute(schedulerMock.Object);

            // Assert
            Assert.Equal("INCORRECT_INPUT", result);
        }

        [Fact]
        public void VacancyCommand_InvalidInput_ReturnsIncorrectInput()
        {
            // Arrange
            var startDate = new DateTime(2024, 9, 9, 9, 0, 0);
            var endDate = new DateTime(2024, 9, 9, 10, 0, 0);
            var command = new VacancyCommand(startDate, endDate, false); // isValid = false

            // Act
            var result = command.Execute(schedulerMock.Object);

            // Assert
            Assert.Equal("INCORRECT_INPUT", result);
        }

        [Fact]
        public void BookCommand_ValidInput_ReturnsBooking()
        {
            // Arrange
            var startDate = new DateTime(2024, 9, 9, 9, 0, 0);
            var endDate = new DateTime(2024, 9, 9, 10, 0, 0);
            int capacity = 5;
            var command = new BookCommand(startDate, endDate, capacity, true);

            schedulerMock.Setup(s => s.BookRoom(startDate, endDate, capacity)).Returns("Room Booked");

            // Act
            var result = command.Execute(schedulerMock.Object);

            // Assert
            Assert.Equal("Room Booked", result);
        }

        [Fact]
        public void BookCommand_EndTimeLessThanStartTime_ReturnsIncorrectInput()
        {
            // Arrange
            var startDate = new DateTime(2024, 9, 9, 10, 0, 0);
            var endDate = new DateTime(2024, 9, 9, 9, 0, 0);
            int capacity = 5;
            var command = new BookCommand(startDate, endDate, capacity, true);

            // Act
            var result = command.Execute(schedulerMock.Object);

            // Assert
            Assert.Equal("INCORRECT_INPUT", result);
        }

        [Fact]
        public void BookCommand_InvalidInput_ReturnsIncorrectInput()
        {
            // Arrange
            var startDate = new DateTime(2024, 9, 9, 9, 0, 0);
            var endDate = new DateTime(2024, 9, 9, 10, 0, 0);
            int capacity = 5;
            var command = new BookCommand(startDate, endDate, capacity, false); // isValid = false

            // Act
            var result = command.Execute(schedulerMock.Object);

            // Assert
            Assert.Equal("INCORRECT_INPUT", result);
        }

        [Fact]
        public void BookCommand_InvalidCapacity_ReturnsIncorrectInput()
        {
            // Arrange
            var startDate = new DateTime(2024, 9, 9, 9, 0, 0);
            var endDate = new DateTime(2024, 9, 9, 10, 0, 0);
            int capacity = -1; // Invalid capacity
            var command = new BookCommand(startDate, endDate, capacity, true);

            // Act
            var result = command.Execute(schedulerMock.Object);

            // Assert
            Assert.Equal("INCORRECT_INPUT", result);
        }
    }
}