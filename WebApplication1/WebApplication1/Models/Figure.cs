using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WebApplication1.Models
{
    public class Figure
    {
        public Figure()
        {
            Lines = new List<Line>();
            Angles = new HashSet<Angle>();
        }

        public Figure(string name) : this()
        {
            Name = name;
        }

        [Required]
        public HashSet<Angle> Angles { get; set; }

        [Required]
        public List<Line> Lines { get; set; }

        public string Name { get; set; }

        public void AddAngle(Angle angle)
        {
            if (angle == null)
                throw new NullReferenceException("Angle object passed is null. Make sure the object exists.");

            Angles.Add(angle);
        }

        public void AddLine(Line line)
        {
            if (line == null)
                throw new NullReferenceException("Line object passed is null. Make sure the object exists.");
            Lines.Add(line);
        }

        public List<Point> CreateFigureOutputList()
        {
            List<Point> figureOutput = new List<Point>();
            for (int i = 0; i < Lines.Count; i++)
            {
                figureOutput.Add(CreateOutput(i));
            }

            return figureOutput;
        }

        public List<Point> FigureOutPustListGreaterThanValue(int greaterThanValue)
        {
            return CreateFigureOutputList().Where(x => x.Value > greaterThanValue).ToList();
        }

        private Point CreateOutput(int index)
        {
            Point figureOutput = new Point(index);
            Line line = GetLine(index);
            Angle angle = GetAngle(index);
            figureOutput.CalculateCoordinates(line, angle);
            figureOutput.CalculateValueForOneLine(line);
            return figureOutput;
        }

        private Angle GetAngle(int id) => Angles.SingleOrDefault(angle => angle.LineNumber == id);

        private Line GetLine(int id) => Lines.SingleOrDefault(line => line.Number == id);
    }
}