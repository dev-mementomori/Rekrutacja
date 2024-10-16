using Rekrutacja.Enums.Calculator;
using Rekrutacja.Models.Areas;
using System;

namespace Rekrutacja.Factories.Areas
{
    public class AreasFactory
    {
        public static IAreaCalculation GetFigure(FigureType figureType)
        {
            switch (figureType)
            {
                case FigureType.Square:
                    return new SquareArea();
                case FigureType.Rectangle:
                    return new RectangleArea();
                case FigureType.Triangle:
                    return new TriangleArea();
                case FigureType.Circle:
                    return new CircleArea();
                default:
                    throw new InvalidOperationException("Nie wybrano figury.");
            }
        }
    }
}
