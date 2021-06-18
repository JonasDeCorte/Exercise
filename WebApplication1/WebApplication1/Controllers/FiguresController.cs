using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FiguresController : ControllerBase
    {
        [HttpPost]
        public ActionResult<List<Point>> PostFigure(Figure figure)
        {
            if (ModelState.IsValid)
            {
                Figure figureToCreate = new Figure(figure.Name);
                FillFigureToCreateCollections(figure, figureToCreate);
                return figureToCreate.CreateFigureOutputList();
            }
            else
            {
                return BadRequest();
            }
        }

        private static void FillFigureToCreateCollections(Figure figure, Figure figureToCreate)
        {
            FillLinesCollectionFigureToCreate(figure, figureToCreate);
            FillAnglesCollectionFigureToCreate(figure, figureToCreate);
        }

        private static void FillAnglesCollectionFigureToCreate(Figure figure, Figure figureToCreate)
        {
            foreach (var item in figure.Angles)
            {
                figureToCreate.AddAngle(new Angle(item.Value, item.LineNumber));
            }
        }

        private static void FillLinesCollectionFigureToCreate(Figure figure, Figure figureToCreate)
        {
            foreach (var item in figure.Lines)
            {
                figureToCreate.AddLine(new Line(item.Name, item.Number, item.Length, item.Weight, item.Cost));
            }
        }

        [HttpPost("{greaterThanValue}")]
        public ActionResult<List<Point>> PostFigureGreaterValueThan(Figure figure, int greaterThanValue = 10)
        {
            {
                if (ModelState.IsValid)
                {
                    Figure figureToCreate = new Figure(figure.Name);
                    FillFigureToCreateCollections(figure, figureToCreate);
                    return figureToCreate.FigureOutPustListGreaterThanValue(greaterThanValue);
                }
                else
                {
                    return BadRequest();
                }
            }
        }
    }
}