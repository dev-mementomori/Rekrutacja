using Soneta.Types;

namespace Rekrutacja.Enums.Calculator
{
    public enum OperationType
    {
        [Caption("")]
        None,
        [Caption("+")]
        Addition,
        [Caption("-")]
        Subtraction,
        [Caption("*")]
        Multiplication,
        [Caption("/")]
        Division
    }
}
