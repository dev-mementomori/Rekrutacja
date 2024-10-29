using System;

namespace Rekrutacja.Helper
{
    public static class ParseHelper
    {
        public static int MyIntParse(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException("Input cannot be null or empty");
            }
        
            //Sprawdzenie czy input jest ujemny
            bool isNegative = input
                .ToCharArray()
                .FirstOrDefault()
                .Equals('-');
        
            //Przygotowanie liczb wykluczajac liczbe ujemna
            var numbers = input.Skip(isNegative ? 1 : 0);
        
            //Sprawdzenie czy wszystkie litery sa cyframi
            if (!numbers.All(char.IsDigit))
            {
                throw new FormatException("Input string was not in a correct format.");
            }
        
            //Zamiana cyfr na liczbe
            int result = (isNegative ? -1 : 1) * numbers.Aggregate(0, (r, c) => r * 10 + ((int)char.GetNumericValue(c)));
        
            //Zwracamy wynik
            return result;
        }
    }
}
