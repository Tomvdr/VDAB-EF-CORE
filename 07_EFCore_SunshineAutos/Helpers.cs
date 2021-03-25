using System;

namespace _07_EFCore_SunshineAutos
{
    public static class Helpers
    {
        // Vraagt tekst op -- mag niet leeg zijn
        public static string TextInput(string veld)
        {
            string input;
            do
            {
                Console.Write($"> {veld}: ");
                input = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(input));
            return input;
        }

        // Vraagt een integer op -- moet geldig zijn
        public static int NumericInput(string veld)
        {
            int value;
            do
            {
                Console.Write($"> {veld}: ");
            } while (!int.TryParse(Console.ReadLine(), out value));
            return value;
        }

        // Rode error message
        public static void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: {message}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        // Groene success message
        public static void Success(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Succes: {message}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        // Blauwe info message
        public static void Info(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Info: {message}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
