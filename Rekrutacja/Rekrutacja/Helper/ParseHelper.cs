using System;

namespace Rekrutacja.Helper
{
    public static class ParseHelper
    {
        public static int MyIntParse(string input)
        {
            // Sprawdza, czy podany tekst (input) jest pusty lub null. Jeśli tak, rzuca wyjątek, że to nieprawidłowe.
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException("Input cannot be null or empty");
            }

            int result = 0; // Zmienna, w której przechowujemy nasz wynik - zaczynamy od zera.
            bool isNegative = false; // Flaga, która sprawdza, czy liczba jest ujemna. Domyślnie ustawiona na false.
            int startIndex = 0; // Indeks początkowy do przetwarzania znaków, zaczynamy od początku tekstu.

            // Sprawdza, czy pierwszy znak to '-' (oznacza liczbę ujemną)
            if (input[0] == '-')
            {
                isNegative = true; // Jeśli liczba jest ujemna, ustawiamy flagę na true.
                startIndex = 1; // Zaczynamy od drugiego znaku, bo pierwszy to '-'.
            }

            // Sprawdza, czy liczba jest tylko jednym znakiem '-' - to jest błąd, rzuca wyjątek.
            if (isNegative && input.Length == 1)
            {
                throw new FormatException("Input string was not in a correct format.");
            }

            // Przechodzi przez każdy znak ciągu zaczynając od startIndex do końca
            for (int i = startIndex; i < input.Length; i++)
            {
                char c = input[i]; // Pobiera aktualny znak

                // Sprawdza, czy znak nie jest cyfrą (czyli coś, co nie jest liczbą od '0' do '9')
                if (c < '0' || c > '9')
                {
                    throw new FormatException("Input string was not in a correct format."); // Rzuca wyjątek, jeśli znajdzie coś, co nie jest cyfrą.
                }

                // Mnożymy dotychczasowy wynik przez 10 (aby przesunąć w lewo o jedną pozycję) i dodajemy wartość aktualnej cyfry.
                result = result * 10 + (c - '0');
            }

            // Jeśli liczba była ujemna, zmieniamy wynik na ujemny i zwracamy go.
            return isNegative ? -result : result;
        }
    }
}
