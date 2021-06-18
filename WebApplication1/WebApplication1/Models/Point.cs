using System;
using WebApplication1.Exceptions;

namespace WebApplication1.Models
{
    public class Point
    {
        public string Name { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Value { get; set; }

        public char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        public Point()
        {
        }

        public Point(int i)
        {
            Name = GetNameCharacter(i).ToString();
        }

        public void CalculateCoordinates(Line line, Angle angle)
        {
            if (line == null || angle == null)
                throw new NullReferenceException($"Object passed is null. Make sure the object exists.");
            X = line.Length * Math.Cos(angle.Value);
            Y = -(line.Length * Math.Sin(angle.Value));
        }

        public void CalculateValueForOneLine(Line line)
        {
            if (line == null)
                throw new NullReferenceException("Line: object passed is null. Make sure the object exists.");
            double value = line.CalculateValue();
            if (value > 2000)
                throw new InvalidValueException($"Value : {value} exceeds maximum");
            Value = value;
        }

        private char GetNameCharacter(int i)
        {
            return (char)alpha.GetValue(i);
        }
    }
}