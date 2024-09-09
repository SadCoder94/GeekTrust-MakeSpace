using System;
using Xunit;
using MakeSpace.FunctionalClasses;

namespace MakeSpaceUnitTests
{
    public class DateTimeParserTests
    {
        [Theory]
        [InlineData("2024-09-09 12:00", true)]
        [InlineData("2024-09-09 12:15", true)]
        [InlineData("2024-09-09 12:30", true)]
        [InlineData("2024-09-09 12:45", true)]
        [InlineData("2024-09-09 12:10", false)] // Invalid time interval
        [InlineData("2024-09-09 35:45", false)] // Invalid time format
        public void TryParse_ShouldReturnExpectedResult(string dateTimeStr, bool expectedIsValid)
        {
            var result = DateTimeParser.TryParse(dateTimeStr, out DateTime parsedDate);

            Assert.Equal(expectedIsValid, result);
        }

    }

}