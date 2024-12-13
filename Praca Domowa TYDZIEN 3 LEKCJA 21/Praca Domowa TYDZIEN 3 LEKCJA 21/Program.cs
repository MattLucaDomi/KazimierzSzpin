using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Praca_Domowa_TYDZIEN_3_LEKCJA_21
{
    internal class Program
    {
        /**
         * Napisz aplikację, która na podstawie wprowadzonych przez użytkownika danych tj. imię, rok urodzenia, miesiąc urodzenia, dzień urodzenia i miejsce urodzenia zwraca 1 zdanie opisujące tego użytkownika. Np „Cześć IMIE urodziłeś się w MIEJSCOWOŚĆ i masz WIEK lat”.

            Podpowiedzi:
            DateTime, DateTime.Now, DateTime.Year, age.DayOfYear**/
        static void Main(string[] args)
        {
            Console.WriteLine("Prosze wprowadzic ponizsze dane");

            Console.WriteLine("Prosze wprowadz swoje pierwsze imie");
            string imie = GetStringInput();
            Console.WriteLine($"\nTwoje imie to {imie}");

            Console.WriteLine("Czy masz drugie imie? Y/N");
            string pytanie = GetStringInput();
            string dodatkowe = "";
            if (pytanie == "y" || pytanie == "Y")
            {
                Console.WriteLine("Prosze wprowadz swoje drugie imie");
                string imie2 = GetStringInput();
                Console.WriteLine($"\nTwoje imie to {imie2}");
                dodatkowe = imie2;
            };

            Console.WriteLine("Prosze wprowadz swoje nazwisko");
            string nazwisko = GetStringInput();
            Console.WriteLine($"\nTwoje nazwisko to {nazwisko}");

            Console.WriteLine("Prosze wprowadz miejsce swojego uroszenia (nazwe miasta)");
            string miejscowosc = GetStringInput();
            Console.WriteLine($"\nUrodziles sie w/we {miejscowosc}");

            Console.WriteLine("Prosze wprowadzic rok swojego urodzenia");
            var rok = GetIntInput(1900, DateTime.Now.Year);
            Console.WriteLine($"\nUrodziles sie w {rok} roku");

            Console.WriteLine("Prosze wprowadzic miesiac swojego urodzenia");
            var miesiac = GetIntInput(1, 12);
            Console.WriteLine($"\nUrodziles sie w {miesiac}.{rok} roku");

            Console.WriteLine("Prosze wprowadzic dzien swojego urodzenia");
            var dzien = GetIntInput(1, 31);
            Console.WriteLine($"\nUrodziles sie w {dzien}.{miesiac}.{rok} roku");

            try
            {
                DateTime dataUrodzenia = new DateTime(rok, miesiac, dzien);
                int wiek = ObliczWiek(dataUrodzenia);

                Console.WriteLine($"Czesc, namywam sie {imie}{dodatkowe}{nazwisko} urodzilem sie {miejscowosc} i mam  {wiek} lat");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Podana data jest nieprawidłowa!");
            }


            Console.ReadLine();
        }

        private static int ObliczWiek(DateTime dataUrodzenia)
        {
            var dzisiaj = DateTime.Now;
            var wiek = dzisiaj.Year - dataUrodzenia.Year;
            if (dataUrodzenia > dzisiaj.AddYears(-wiek))
            {
                wiek--;
            }

            return wiek;
        }

        private static int GetIntInput(int min, int max)
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    if (result >= int.MinValue && result <= max)
                    {
                        return result;
                    }
                }
                Console.WriteLine($"PRosze podac liczbe mieszy {min} a {max}");
            }
        }
        private static string GetStringInput()
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Tekst nie moze byc puste! Sprobuj ponownie");
                    continue;
                }
                if (input.All(char.IsLetter))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("To nie jest czysty tekst! Sprubuj poniownie.");
                }
            }
        }

    }
}
