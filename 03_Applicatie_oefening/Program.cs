using _00_Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace _03_Applicatie_oefening
{
    // Maak een applicatie die de boekendatabase kan beheren en uitlezen
    // ERD staat in de ppt slide 15
    // Minimale eisen:
    //  - Records toevoegen aan elke tabel
    //  - Elke tabel volledig kunnen uitlezen via PK, naam of titel
    //    - de PK moet identiek zijn, naam of titel mag via een LIKE 
    //  - Een detail kunnen tonen van een boek a.h.v. ISBN-nr
    // Hieronder is al een geraamte voor de selectiemenu's.
    // Aan jou om alles uit te breiden!
    // Uitbreiding indien tijd over/snel klaar:
    //  - Inputvalidatie. Tekst moet altijd ingevuld zijn (string.IsNullOrEmpty)
    class Program
    {
        static void Main(string[] args)
        {
            ListActions();
        }

        private static void ListActions()
        {
            Console.WriteLine("Welke actie wil je ondernemen?");
            Console.WriteLine("1. Een auteur toevoegen");
            Console.WriteLine("2. Een uitgeverij toevoegen");
            Console.WriteLine("3. Een boek toevoegen");
            Console.WriteLine("4. Alle auteurs tonen");
            Console.WriteLine("5. Alle uitgeverijen tonen"); 
            Console.WriteLine("6. Alle boeken tonen");

          
            // Verkrijg een numerieke input via readline. Deze mag maximaal 6 zijn!
            int choice = GetNumericInput(6);
            
            Header();

            switch (choice)
            {
                case 1:
                    AddAuthor();
                    break;
                case 2:
                    AddPublisher();
                    break;
                case 3:
                    AddBook();
                    break;
                case 4:
                    ShowAuthors();
                    break;
                case 5:
                    ShowPublishers();
                    break;
                case 6:
                    ShowBooks();
                    break;
            }

            ListActions();
        }


        // Methode voor de herhalende code van het openen van een connectie te beperken
        // Gebruik deze bij al je database queries!
        private static SqlConnection OpenConnection()
        {
            var connection = new SqlConnection(ConnectionString.Boekendatabase);
            connection.Open();
            return connection;
        }

        private static void Header()
        {
            Console.WriteLine("--------------------------");
        }

        // Methode voor een numerieke waarde in te geven
        // Gaat blijven vragen naar een waarde totdat een geldig nummer is
        private static int GetNumericInput(int max)
        {
            Console.Write("> ");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice > max || choice < 0)
            {
                Console.WriteLine("Fout! Vul een numerieke waarde in.");
                Console.Write("> ");
            }

            return choice;
        }

        // TODO!
        // Toevoegen van een auteur
        // Tip: een auteur heeft veld [Id] (automatisch gegenereerd) en een [Naam]
        private static void AddAuthor()
        {
            Console.WriteLine("# Auteur toevoegen");
           
            Console.Write("> Naam:");
            string naam = Console.ReadLine();

            SqlConnection connection = OpenConnection();
            // ...
        }

        // TODO!
        // Toevoegen van een uitgeverij
        // Tip: een auteur heeft veld [Id] (automatisch gegenereerd) en een [Naam]
        private static void AddPublisher()
        {

        }

        // TODO!
        // Toevoegen van een boek
        // Tip: een auteur heeft veld [Id] (automatisch gegenereerd), [Titel], [PaginaAantal] en 2 foreign keys
        private static void AddBook()
        {

        }

        // TODO!
        // Lijst tonen van alle auteurs
        // Tip: een auteur heeft veld [Id] (automatisch gegenereerd) en een [Naam]
        private static void ShowAuthors()
        {

        }

        // TODO!
        // Lijst tonen van alle uitgeverijen
        // Tip: een auteur heeft veld [Id] (automatisch gegenereerd) en een [Naam]
        private static void ShowPublishers()
        {

        }

        // TODO!
        // Lijst tonen van alle boeken
        // TIP: gebruik 2 joins (één op auteur, één op uitgeverij)
        // De gebruiker heeft geen boodschap aan ids, hier dient een lijstje te komen met volgende velden:
        // - ISBN-nr
        // - Pagina aantal
        // - Auteur (naam)
        // - Uitgeverij (naam)
        private static void ShowBooks()
        {

        }
    }
}
