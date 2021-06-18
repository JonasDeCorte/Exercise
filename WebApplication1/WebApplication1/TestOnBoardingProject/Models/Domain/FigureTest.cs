using FluentAssertions;
using System;
using WebApplication1.Models;
using Xunit;

namespace TestOnBoardingProject.Models.Domain
{
    public class FigureTest
    {
        private Figure figure;
        private Line line;
        private Angle angle;

        [Theory]
        [InlineData("f", 0, 5.26, 197, 99, 0, 5.57)]
        [InlineData("g", 1, 5.92, 200, 1, 1, 0.19)]
        [InlineData("h", 2, 5.35, 0, 25, 2, 0.8)]
        [InlineData("i", 3, 6.3, 100, 20, 3, 2.69)]
        [InlineData("j", 4, 5.83, 5.83, 20, 4, 3.68)]
        public void CreateFigureObjectNotNullSuccess(string name, int number, double length, double weight, int cost, double value, int lineNumber)
        {
            line = new Line(name, number, length, weight, cost);
            angle = new Angle(value, lineNumber);
            line.Should().NotBeNull();
            angle.Should().NotBeNull();

            figure = new Figure("randomName");
            figure.Should().BeOfType<Figure>("because a {0} is set", typeof(Figure));
            figure.AddLine(line);
            figure.AddAngle(angle);

            figure.Angles.Should().NotBeEmpty().And.HaveCount(1);
            figure.Lines.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void AddLineNullReferenceThrowsNullReferenceException()
        {
            line = null;
            line.Should().BeNull("Because the value is null");
            figure = new Figure("randomName");
            figure.Should().BeOfType<Figure>("because a {0} is set", typeof(Figure));
            figure.Invoking(fig => fig.AddLine(line)).Should().Throw<NullReferenceException>().WithMessage("Line object passed is null. Make sure the object exists.");
        }

        [Fact]
        public void AddAngleNullReferenceThrowsNullReferenceException()
        {
            angle = null;
            angle.Should().BeNull("Because the value is null");
            figure = new Figure("randomName");
            figure.Should().BeOfType<Figure>("because a {0} is set", typeof(Figure));
            figure.Invoking(fig => fig.AddAngle(angle)).Should().Throw<NullReferenceException>().WithMessage("Angle object passed is null. Make sure the object exists.");
        }
    }
}