using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Globalization;
using System.Text;

namespace Ovning_2_Flode
{
    class Program
    {
        // Flag to terminate program
        private static bool terminate = false;

        static void Main(string[] args)
        {   
            do
            {
                PrintMainMenu();
                HandleMainMenu();
            } while (terminate == false);
        }

        /// <summary>
        /// prints main menu
        /// </summary>
        private static void PrintMainMenu()
        {
            Console.WriteLine("Huvudmenyn");
            Console.WriteLine("1: Ungdom eller pensionär");
            Console.WriteLine("2: Upprepa tio gånger");
            Console.WriteLine("3: Det tredje ordet");
            Console.WriteLine("4: Sällskap");
            Console.WriteLine("0: Avsluta");
            Console.Write("Välj alternativ: ");
        }

        /// <summary>
        /// Takes care of input from main menu
        /// </summary>
        private static void HandleMainMenu()
        {
            int choice;

            choice = CheckInput("integ");

            switch (choice)
            {
                case 0:
                    terminate = true;
                    break;
                case 1: // Ungdom pensionär
                    CalculatePrice();
                    break;
                case 2: // Upprepa tio gånger
                    Repeat();
                    break;
                case 3: // Det tredje ordet
                    pickThirdWord();
                    break;
                case 4: // Sällskap
                    Company();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Felaktig inmatning. Försök igen!");
                    break;
            }
        }


        private static int CheckInput(string inputType)
        {
            if (inputType == "integ")
            {
                int outputInteger = 0;

                try
                {
                    outputInteger = int.Parse(Console.ReadLine());
                    return outputInteger;
                }
                catch (FormatException)
                {
                    outputInteger = -1;
                    return outputInteger;
                }
                catch (OverflowException)
                {
                    outputInteger = -1;
                    return outputInteger;
                }
                catch (Exception)
                {
                    outputInteger = -1;
                    return outputInteger;
                }
            }

            return 0;
        }


            /// <summary>
            /// Extracts the third word from a sentence
            /// </summary>
            private static void pickThirdWord()
        {
            Console.Clear();
            Console.WriteLine("Ange en mening med minst tre ord!");
            var sentence = Console.ReadLine();
            string[] words = sentence.Split(" ");
            Console.WriteLine($"Det tredje ordet är: {words[2]}");
            Console.WriteLine();
        }

        /// <summary>
        /// Repeats a string ten times
        /// </summary>
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

        /// <summary>
        /// Calculates ticket (?) price from person age
        /// </summary>
        /// <param name="person"></param>
        /// <returns>"price"</returns>
        private static int CalculatePrice(int person = 0) // Default, 0, is for non companies
        {
            int price;

            Console.Write("Ange ålder");

            if (person > 0)
            {
                Console.Write($" för person {person}");
            }
            Console.Write(": ");
         
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
