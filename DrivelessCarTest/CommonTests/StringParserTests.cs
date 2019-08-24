using Xunit;
using FluentAssertions;
using System;
using DrivelessCar.Common;

namespace DrivelessCarTest.CommonTests
{
    public class StringParserTests
    {
        [Fact]
        public void StringToIntShouldThrowArgumentException()
        {
            var testString = "12a";

            Action act = () => testString.StringToInt();

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void StringToIntShouldReturnCorrectNumber()
        {
            var testString = "12";

            var result = testString.StringToInt();

            result.Should().Be(12);
        }
    }
}
