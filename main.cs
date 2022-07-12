using System;                       // Przedstawienie projektu i pisanie aplikacji - GOTOWE
using System.Collections.Generic;   // Obsługa wyjątków - GOTOWE
using System.Linq;                  // Wyliczeniowy typ danych - ENUM - GOTOWE
using System.Text;                  // Ulepszenia wizualne

namespace Consoleapp2
{
    class Program
    {
        enum TypeOfValue
        {
            PLN,
            EURO
        }

        static void Main(string[] args) // Entry point
        {
            bool runAgain = true;

            while (runAgain)
            {
                TypeOfValue check = GetValueType();
                int money = GetMoney();
                InformationAboutMoney(check, money);
                runAgain = RunAgain();
            }
            Console.WriteLine("Dziękuję za skorzystanie z mojej aplikacji!");
        }

        static TypeOfValue GetValueType() // Informacje o walucie
        {
            runAgain:

            try
            {
                Console.WriteLine("Wybierz walutę:\n");

                Console.WriteLine("1) PLN");
                Console.WriteLine("2) EURO\n");

                string check = Console.ReadLine();
                if (check == "1")
                    return TypeOfValue.PLN;
                else if (check == "2")
                    return TypeOfValue.EURO;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(1);
            }
            goto runAgain;
        }

        static int GetMoney() // Informacje o pieniądzach
        {
            try
            {

                Console.WriteLine("Wpisz liczbę pieniędzy w danej walucie:\n");

                string money = Console.ReadLine();
                return Int32.Parse(money);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }
            return 0;
        }

        static void InformationAboutMoney(TypeOfValue check, int money) // Przetworzone informacje
        {
            double pln;
            double euro;

            if (TypeOfValue.PLN == check)
            {
                pln = money;
                euro = pln / 4.82;

                Console.WriteLine("PLN: " + pln);
                Console.WriteLine("EURO: " + euro);
            }
            else if (TypeOfValue.EURO == check)
            {
                euro = money;
                pln = euro / 0.21;

                Console.WriteLine("PLN: " + pln);
                Console.WriteLine("EURO: " + euro);
            }
        }

        static bool RunAgain() // Uruchom ponownie
        {
            checkAgain:

            Console.WriteLine("\nCzy chcesz przeprowadzić konwersję" +
                              " jeszcze raz?\n\n1) Tak\n2) Nie");

            
                string db = Console.ReadLine();

                if (db == "1")
                {
                    return true;
                }
                else if (db == "2")
                {
                    return false;
                }
                else
                    goto checkAgain;
        }
    }
}
