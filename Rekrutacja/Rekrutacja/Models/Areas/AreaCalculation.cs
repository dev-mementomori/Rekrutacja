using System;

namespace Rekrutacja.Models.Areas
{
    public interface IAreaCalculation
    {
        double CalculateArea(double a, double b);
    }

    public class SquareArea : IAreaCalculation
    {
        public double CalculateArea(double a, double b) => a * a;
    }

    public class RectangleArea : IAreaCalculation
    {
        public double CalculateArea(double a, double b) => a * b;
    }

    public class TriangleArea : IAreaCalculation
    {
        public double CalculateArea(double a, double b) => (a * b) / 2;
    }

    public class CircleArea : IAreaCalculation
    {
        public double CalculateArea(double a, double b) => (double)(Math.PI * a * a);
    }
}
