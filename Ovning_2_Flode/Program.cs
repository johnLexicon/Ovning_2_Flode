using System;
using System.Globalization;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace Ovning_2_Flode
{
    class Program
    {
        private static bool terminate = false;

        static void Main(string[] args)
        {   
            do
            {
                printMainMenu();
                handleMainMenu();
            } while (terminate == false);
        }


        private static void printMainMenu()
        {
            //Console.Clear();
            Console.WriteLine("Huvudmenyn");
            Console.WriteLine("1: Ungdom eller pensionär");
            Console.WriteLine("2: Upprepa tio gånger");
            Console.WriteLine("3: Det tredje ordet");
            Console.WriteLine("4: Sällskap");
            Console.WriteLine("0: Avsluta");
            Console.Write("Välj alternativ: ");
        }


        private static int handleMainMenu()
        {
            int choice;
            
            try
            {
                choice = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                choice = -1;
            }

            switch (choice)
            {
                case 0:
                    terminate = true;
                    break;
                case 1:
                    // ungdom pensionär
                    calculatePrice();
                    break;
                case 2:
                    // Upprepa tio gånger
                    break;
                case 3:
                    // Det tredje ordet
                    break;
                case 4:
                    // Sällskap
                    company();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Felaktig inmatning. Försök igen!");
                    break;
            }

            return choice;
        }


        private static void company()
        {
            int totalCost = 0;
            int nrOfPersons;

            Console.Clear();
            Console.Write("Ange antal personer i sällskapet: ");

            try
            {
                nrOfPersons = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("Felaktig inmatning. Försök igen!");
                return;
            }

            for (int i = 0; i < nrOfPersons; i++)
            {
                totalCost += Program.calculatePrice(i + 1);
            }

            Console.Clear();
            Console.WriteLine($"antal personer: {nrOfPersons}");
            Console.WriteLine($"Totalpris: {totalCost.ToString("C", CultureInfo.CurrentCulture)}");
            Console.WriteLine();
        }


        private static int calculatePrice(int person = 1)
        {
            int price;
            Console.Write("Ange ålder");

            Console.Write($" för person {person}: ");
         
            int age = int.Parse(Console.ReadLine());

            if (age < 20)
            {
                Console.WriteLine("Ungdomspris: 80kr");
                price = 80;
            }
            else if (age > 64)
            {
                Console.WriteLine("Pensionärspris: 90kr");
                price = 90;
            }
            else
            {
                Console.WriteLine("Standardpris: 120kr");
                price = 120;
            }

            Console.WriteLine();
            return price;
        }
    }
}
