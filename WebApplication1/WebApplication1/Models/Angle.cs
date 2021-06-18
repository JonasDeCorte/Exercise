using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Angle : IEquatable<Angle>
    {
        [Required]
        public double Value { get; set; }

        [Required]
        public int LineNumber { get; set; }

        public Angle()
        {
        }

        public Angle(double value, int lineNumber)
        {
            Value = value;
            LineNumber = lineNumber;
        }

        public bool Equals(Angle other)
        {
            return other != null &&
                   LineNumber == other.LineNumber;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(LineNumber);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Angle);
        }
    }
}