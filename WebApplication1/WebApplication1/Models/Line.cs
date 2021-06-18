using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Line
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public double Length { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Cost must be between 1 and 100.")]
        public int Cost { get; set; }

        public Line()
        {
        }

        public Line(string name, int number, double length, double weight, int cost)
        {
            Name = name;
            Number = number;
            Length = length;
            Weight = weight;
            Cost = cost;
        }

        public double CalculateValue()
        {
            return Weight / Cost * Length;
        }
    }
}