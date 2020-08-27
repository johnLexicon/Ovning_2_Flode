using System;
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
                printMenu();
                handleMenu();
            } while (terminate == false);
        }


        private static void printMenu()
        {
            //Console.Clear();
            Console.WriteLine("Huvudmenyn");
            Console.WriteLine("1: Ungdom eller pensionär");
            Console.WriteLine("2: Upprepa tio gånger");
            Console.WriteLine("3: Det tredje ordet");
            Console.WriteLine("0: Avsluta");
            Console.Write("Välj alternativ: ");
        }


        private static int handleMenu()
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
                    break;
                case 2:
                    // Upprepa tio gånger
                    break;
                case 3:
                    // Det tredje ordet
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Felaktig inmatning. Försök igen!");
                    break;
            }

            return choice;
        }
    }
}
