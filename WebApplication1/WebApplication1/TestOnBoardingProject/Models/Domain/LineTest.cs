using FluentAssertions;
using WebApplication1.Models;
using Xunit;

namespace TestOnBoardingProject.Models.Domain
{
    public class LineTest
    {
        private Line line;

        [Theory]
        [InlineData("f", 0, 5.26, 197, 99)]
        [InlineData("g", 1, 5.92, 200, 1)]
        [InlineData("h", 2, 5.35, 0, 25)]
        [InlineData("i", 3, 6.3, 100, 20)]
        [InlineData("j", 4, 5.83, 5.83, 20)]
        public void CalculateValueLineSuccess(string name, int number, double length, double weight, int cost)
        {
            line = new Line(name, number, length, weight, cost);
            line.Should().NotBeNull();
            double value = weight / cost * length;
            line.CalculateValue().Should().Be(value);
        }
    }
}