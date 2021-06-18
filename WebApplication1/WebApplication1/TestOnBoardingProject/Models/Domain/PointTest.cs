using FluentAssertions;
using System;
using WebApplication1.Exceptions;
using WebApplication1.Models;
using Xunit;

namespace TestOnBoardingProject.Models.Domain
{
    public class PointTest
    {
        private readonly Point point;

        public PointTest()
        {
            point = new Point();
        }

        [Fact]
        public void CalculateValueForOneLineCorrectExampleAddedExpectedSuccess()
        {
            Line line = new Line
            {
                Name = "f",
                Number = 0,
                Length = 5.26,
                Weight = 197,
                Cost = 99
            };
            line.Should().NotBeNull();
            double value = line.CalculateValue();
            point.CalculateValueForOneLine(line);
            point.Value.Should().Be(value);
        }

        [Fact]
        public void CalculateValueForOneLineNullObjectExpectedExceptionThrown()
        {
            Line line = null;
            line.Should().BeNull("Because the value is null");
            point.Invoking(x => x.CalculateValueForOneLine(line)).Should().Throw<NullReferenceException>()
                .WithMessage("Line: object passed is null. Make sure the object exists.");
        }

        [Fact]
        public void CalculateValueForOneLineValueExceeds2000ExpectedCustomException()
        {
            Line line = new Line("f", 0, 34343, 197, 99);
            point.Invoking(x => x.CalculateValueForOneLine(line)).Should().Throw<InvalidValueException>();
        }

        [Fact]
        public void CalculateCoordinatesNullLineObjectExpectedExceptionThrown()
        {
            Line line = null;
            Angle angle = null;
            point.Invoking(x => x.CalculateCoordinates(line, angle)).Should().Throw<NullReferenceException>();
        }

        [Fact]
        public void CalculateCoordinatesExpectedSuccess()
        {
            Line line = new Line("f", 0, 5.26, 197, 99);
            Angle angle = new Angle(5.57, 0);
            double X = line.Length * Math.Cos(angle.Value);
            double Y = -(line.Length * Math.Sin(angle.Value));
            point.CalculateCoordinates(line, angle);
            point.X.Should().Be(X);
            point.Y.Should().Be(Y);
        }
    }
}