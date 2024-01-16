using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDrawOfNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var randomNumber = new Random();
            var index = 0;

            try
            {
                bool isWinner;

                do
                {
                    index++;
                    Console.WriteLine("Podaj liczbę z zakresu od 0 to 100:");

                    var yourNumber = CheckInt(0, 100);

                    var theNumberDrawn = randomNumber.Next(0, 100);

                    if (yourNumber < theNumberDrawn)
                    {
                        Console.WriteLine("Twoja liczba jest mniejsza.!");
                        isWinner = false;
                    }
                    else if(yourNumber > theNumberDrawn)
                    {
                        Console.WriteLine("Twoja liczba jest większa.!");
                        isWinner = false;
                    }
                    else
                    {
                        Console.WriteLine($"Brawo ! Trafiłeś ! Wygrana.! za {index} razem.");
                        isWinner= true;
                    }
                    Console.WriteLine("Grasz dalej: T/N ?");

                } while (CheckAnswer(isWinner));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }

        private static int CheckInt(int minValues, int maxvalue)
        {
            var input = IsNotEmpty();

            var permissibleValuesForInputInt = "1234567890";

            foreach (var sign in input)
            {
                if (!permissibleValuesForInputInt.Contains(sign))
                {
                    throw new Exception("Wprowadzane dane muszą składać się wyłącznie z cyfr.! Naciśnij Enter.");
                }
            }

            if (!int.TryParse(input, out int inputInt))
            {
                throw new Exception("Podana wartość jest nieprawidłowa.! Naciśnij Enter.");
            }

            if (inputInt < minValues | inputInt > maxvalue)
            {
                throw new Exception($"Podano liczbę z poza zakresu: {minValues} - {maxvalue}.! Naciśnij Enter.");
            }
            return inputInt;
        }

        private static bool CheckAnswer(bool win)
        {
            var input = IsNotEmpty().ToUpper();

            var permissibleValuesForInputString = "TN";

            foreach (var sign in input)
            {
                if (!permissibleValuesForInputString.Contains(sign) | input.Length != 1)
                {
                    throw new Exception("Odpowiedź może zawierać tylko jeden znak T(t) lub N(n).! Naciśnij Enter.");
                }
            }

            if (input == "T")
            {
                return true;
            }
            else
            {
                if (win)
                {
                    Console.WriteLine("Koniec gry.! Wygrałeś.! Naciśnij Enter.");
                }
                else
                {
                    Console.WriteLine("Koniec gry.! Przegrałeś.! Naciśnij Enter.");
                }
                return false;
            }
        }

        private static string IsNotEmpty()
        {
            var input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new Exception("Nie podano odpowiedzi.! Naciśnij Enter.");
            }
            return input;
        }

    }
}
