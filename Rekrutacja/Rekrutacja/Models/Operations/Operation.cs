using System;

namespace Rekrutacja.Models.Operations
{
    public interface IOperation
    {
        double Calculate(double a, double b);
    }

    public class Operation : IOperation
    {
        public double Calculate(double a, double b)
        {
            return 0;
        }
    }
    public class Addition : IOperation
    {
        public double Calculate(double a, double b) => a + b;
    }

    public class Subtraction : IOperation
    {
        public double Calculate(double a, double b) => a - b;
    }

    public class Multiplication : IOperation
    {
        public double Calculate(double a, double b) => a * b;
    }

    public class Division : IOperation
    {
        public double Calculate(double a, double b)
        {
            if (b == 0)
                throw new InvalidOperationException("Cannot divide by zero.");
            return a / b;
        }
    }

}
