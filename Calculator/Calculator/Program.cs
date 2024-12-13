using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {

            bool continueProgram = true;

            while (continueProgram)
            {
                Console.WriteLine("Wybierz opcje: \n '1' => Wykonaj obliczenie \n '0' => Zero zakancza dzialanie programu");

                if(int.TryParse(Console.ReadLine(), out int choise))
                {
                    if(choise == 0)
                    {
                        Console.WriteLine("Zycze milego dnia");
                        continueProgram = false;
                        //break;
                    }
                    else if(choise == 1)
                    {
                        PerformCalculation();
                    }
                    else
                    {
                        Console.WriteLine("NIEPRAWIDLOWA opcja. Wybierz albo 1 albo 0.");
                    }  
                }
                else
                {
                    Console.WriteLine("NIEPRAWIDLOWA opcja. Wybierz albo 1 albo 0.");
                }
            }
            Console.ReadLine();

        }
                                                           
        private static void PerformCalculation()
        {
            try
            {
                Console.WriteLine("Podaj pierwsza liczne");
                var number1 = GetInput();
                   
                Console.WriteLine("Jaka operacje chesz wykonac? Mozliwe operacje to: '+', '-', '*', '/'. '0' Zero zakancza dzialanie programu ");
                var action = "";
                do
                {
                    action = Console.ReadLine();

                } while (action != "+" && action != "-" && action != "*" && action != "/");


                Console.WriteLine("Podaj druga liczne");
                var number2 = GetInput();

                var result = Calculate(number1, number2, action);

                Console.WriteLine($"\nDzialanie {number1} {action} {number2} = {result}");
                Console.WriteLine("\n \n =======================================");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        private static int GetInput()
        {
            if (!int.TryParse(Console.ReadLine(), out int input))
                throw new Exception("podana wartosc jest nieprawidlowa");
            return input;
        }
        private static int Calculate(int number1, int number2, string action)
        {
            switch (action)
            {
                case "+":
                    return number1 + number2;
                case "-":
                    return number1 - number2;
                case "*":
                    return number1 * number2;
                case "/":
                    if (number2 == 0)
                        throw new Exception("NIe mozna dziecic przez zero");
                    return number1 / number2;
                default:
                    throw new Exception("Wybrales zla operacje");
            }
        }
    }
}
