using System;
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
                    price();
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
            Console.WriteLine("Ange antal personer i sällskapet");
            int nrOfPersons = int.Parse(Console.ReadLine());
            int[] persons = new int[nrOfPersons];

            foreach (var person in persons)
            {

            }
        }


        private static void price()
        {
            Console.WriteLine();
            
            Console.Write("Ange ålder: ");
            int age = int.Parse(Console.ReadLine());

            if (age < 20)
            {
                Console.WriteLine("Ungdomspris: 80kr");
            }
            else if (age > 64)
            {
                Console.WriteLine("Pensionärspris: 90kr");
            }
            else
            {
                Console.WriteLine("Standardpris: 120kr");
            }
        }
    }
}
