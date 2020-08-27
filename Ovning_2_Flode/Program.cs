using System;
using System.Globalization;
using System.Text;

namespace Ovning_2_Flode
{
    class Program
    {
        private static bool terminate = false;

        static void Main(string[] args)
        {   
            do
            {
                PrintMainMenu();
                HandleMainMenu();
            } while (terminate == false);
        }


        private static void PrintMainMenu()
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


        private static void HandleMainMenu()
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
                    CalculatePrice();
                    break;
                case 2:
                    // Upprepa tio gånger
                    Repeat();
                    break;
                case 3:
                    // Det tredje ordet
                    break;
                case 4:
                    // Sällskap
                    Company();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Felaktig inmatning. Försök igen!"); // Bryta ut?
                    break;
            }
        }


        private static void Repeat()
        {
            Console.Clear();
            Console.Write("Skriv något! ");
            string userInput = Console.ReadLine();

            StringBuilder text = new StringBuilder();

            int nrOfRepeats = 10;

            for (int i = 0; i < nrOfRepeats; i++)
            {
                text.Append($"{i + 1}. {userInput}");
                
                if (i + 1 < nrOfRepeats)
                {
                    text.Append(", ");
                }
            }

            Console.WriteLine(text);
            Console.WriteLine();
        }


        private static void Company()
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
                totalCost += Program.CalculatePrice(i + 1);
            }

            Console.Clear();
            Console.WriteLine($"antal personer: {nrOfPersons}");
            Console.WriteLine($"Totalpris: {totalCost.ToString("C", CultureInfo.CurrentCulture)}");
            Console.WriteLine();
        }


        private static int CalculatePrice(int person = 1) //0? companymembers?
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
