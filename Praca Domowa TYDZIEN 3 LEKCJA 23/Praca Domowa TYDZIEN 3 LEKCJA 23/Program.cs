using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praca_Domowa_TYDZIEN_3_LEKCJA_23
{
    internal class Program
    {
        /**
         * Najpierw aplikacja losuje 1 liczbę z zakresu od 0 do 100. Następnie użytkownik próbuje odgadnąć wylosowaną liczbę. Po każdej próbie odgadnięcia liczby, użytkownik dostaje odpowiedni komunikat (Twoja liczba jest za mała/za duża lub odgadłeś wylosowaną liczbę w x próbach).

            Podpowiedzi:
            Random, random.Next(), użyj pętli. Nie zapomnij o odpowiednich testach.
         * **/
        static void Main(string[] args)
        {
            Random rand = new Random();
            int liczba = rand.Next(0, 100 + 1);
            int zgaduje;
            bool czyPoprawnie;
            int cont = 0;

            Console.WriteLine("Zgadnij liczbe w przedziale od 0 do 100");

            Console.WriteLine(liczba);
            do
            {
                czyPoprawnie = int.TryParse(Console.ReadLine(), out zgaduje);
                cont++;

                if (!czyPoprawnie)
                {
                    Console.WriteLine("To nie jest liczba! Sprobuj ponownie w skali od 0 do 100!");
                    continue;
                }

                if (zgaduje < liczba)
                {
                    Console.WriteLine("Za mało! Spróbuj ponownie:");
                }
                else if (zgaduje > liczba)
                {
                    Console.WriteLine("Za dużo! Spróbuj ponownie:");
                }
                else
                {
                    Console.WriteLine($"Brawo! Zgadłeś liczbę w {cont} prubach !");
                    break;
                }
            } while (true);

            Console.WriteLine("Naciśnij Enter, aby zakończyć...");
            Console.ReadLine();
        }
    }
}
