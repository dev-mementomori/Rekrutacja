using Rekrutacja.Enums.Calculator;
using Rekrutacja.Models.Operations;
using System;

namespace Rekrutacja.Factories.Operations
{
    public class OperationFactory
    {
        public static IOperation GetOperation(OperationType operationType)
        {
            switch (operationType)
            {
                case OperationType.None:
                    return new Operation();
                case OperationType.Addition:
                    return new Addition();
                case OperationType.Subtraction:
                    return new Subtraction();
                case OperationType.Multiplication:
                    return new Multiplication();
                case OperationType.Division:
                    return new Division();
                default:
                    throw new InvalidOperationException("Unknown operation.");
            }
        }
    }
}
