using _00_Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace _03_Applicatie_oefening
{
    // Maak een applicatie die de boekendatabase kan beheren en uitlezen
    // ERD staat in de ppt slide 15
    // Minimale eisen:
    //  - Records toevoegen aan elke tabel
    //  - Elke tabel volledig kunnen uitlezen via PK, naam of titel
    //    - de PK moet identiek zijn, naam of titel mag via een LIKE 
    // Hieronder is al een geraamte voor de selectiemenu's.
    // Aan jou om alles uit te breiden!
    // Uitbreiding indien tijd over/snel klaar:
    //  - Inputvalidatie. Tekst moet altijd ingevuld zijn (string.IsNullOrEmpty)
    //  - Het verwijderen van uitgeverij, auteur of boek (bij het verwijderen van een auteur of een uitgeverij, eerst melding tonen indien die ergens gebruikt wordt!)
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new BoekenDatabaseContext())
            {
                string input = "Roald Dahl";


                var auteur = context.Auteurs.FirstOrDefault(_ => _.Naam == input);


                var boek = new Boek
                {
                    ISBNNr = "1203918231_2",
                    PaginaAantal = 200,
                    Title = "Tom's boek 2",
                   Auteur = auteur,
                    UitgeverijId = 2
                };

                context.Boeken.Add(boek);
                context.SaveChanges();
            }


           //ListActions();
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
            Console.WriteLine("7. Een uitgeverij verwijderen (uitbreiding)");
            Console.WriteLine("8. Een auteur verwijderen (uitbreiding)");
            Console.WriteLine("9. Een boek verwijderen (uitbreiding)");

            // Verkrijg een numerieke input via readline. Deze mag maximaal 9 zijn!
            int choice = GetNumericInput(9);            
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
                case 7:
                    DeleteAuthor();
                    break;
                case 8:
                    DeletePublisher();
                    break;
                case 9:
                    DeleteBook();
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

            // Invoer + validatie (mag niet leeg zijn)
            string naam;
            do
            {
                Console.Write("> Naam: ");
                naam = Console.ReadLine();
            } while (string.IsNullOrEmpty(naam));


            using (var context = new BoekenDatabaseContext())
            {
                // Kijk of boek al bestaat
                var auteurBestaat = context.Auteurs.Any(auteur => auteur.Naam == naam);

                if(auteurBestaat)
                {
                    Console.WriteLine("Deze auteur bestaat al!");
                } 
                else
                {
                    context.Auteurs.Add(new Auteur
                    {
                        Naam = naam
                    });

                    Console.WriteLine($"Auteur '{naam}' toegevoegd.");
                }
            }
            Header();
        }

        // TODO!
        // Toevoegen van een uitgeverij
        // Tip: een auteur heeft veld [Id] (automatisch gegenereerd) en een [Naam]
        private static void AddPublisher()
        {
            Console.WriteLine("# Uitgeverij toevoegen");

            // Invoer + validatie (mag niet leeg zijn)
            string naam;
            do
            {
                Console.Write("> Naam: ");
                naam = Console.ReadLine();
            } while (string.IsNullOrEmpty(naam));

            using (var context = new BoekenDatabaseContext())
            {
                // Kijk of boek al bestaat
                var uitgeverijBestaat = context.Uitgeverijen.Any(uitgeverij => uitgeverij.Naam == naam);

                if (uitgeverijBestaat)
                {
                    Console.WriteLine("Deze uitgeverij bestaat al!");
                }
                else
                {
                    context.Uitgeverijen.Add(new Uitgeverij
                    {
                        Naam = naam
                    });

                    Console.WriteLine($"Uitgeverij '{naam}' toegevoegd.");
                }
            }

            Header();
        }

        // TODO!
        // Toevoegen van een boek
        // Tip: een auteur heeft veld [Id] (automatisch gegenereerd), [Titel], [PaginaAantal] en 2 foreign keys
        private static void AddBook()
        {

            // Invoer + validatie (mag niet leeg zijn)
            string title;
            do
            {
                Console.Write("> Titel: ");
                title = Console.ReadLine();
            } while (string.IsNullOrEmpty(title));

            // Invoer + validatie (mag niet leeg zijn)
            string isbnnr;
            do
            {
                Console.Write("> ISBN-nr: ");
                isbnnr = Console.ReadLine();
            } while (string.IsNullOrEmpty(isbnnr));

            // Aantal pagina's
            int aantalPaginas;
            do
            {
                Console.Write("> Aantal pagina's: ");
            } while (!int.TryParse(Console.ReadLine(), out aantalPaginas));


            // Invoer + validatie (mag niet leeg zijn)
            string uitgeverijNaam;
            do
            {
                Console.Write("> Naam uitgeverij: ");
                uitgeverijNaam = Console.ReadLine();
            } while (string.IsNullOrEmpty(uitgeverijNaam));

            // Invoer + validatie (mag niet leeg zijn)
            string auteurNaam;
            do
            {
                Console.Write("> Naam auteur: ");
                auteurNaam = Console.ReadLine();
            } while (string.IsNullOrEmpty(auteurNaam));



            using (var context = new BoekenDatabaseContext())
            {
                // Bestaat boek al ?
                var bestaandBoek= context.Boeken.FirstOrDefault(boek => boek.ISBNNr == isbnnr || boek.Title == title);
                if(bestaandBoek != null)
                {
                    Console.WriteLine($"Dit boek bestaat al (id = {bestaandBoek.ISBNNr})");
                } else
                {
                    // Boek toevoegen -- een boek heeft een auteur en uitgeverij nodig.
                    // Indien een auteur al bestaat, wil ik dat deze gebruikt wordt. Anders aanmaken.
                    // Idem voor een uitgeverij 
                    Uitgeverij uitgeverij = context.Uitgeverijen.FirstOrDefault(u => u.Naam == uitgeverijNaam);
                    // Uitgeverij werd niet gevonden
                    if(uitgeverij == null)
                    {
                        // Dus maken we één aan:
                        uitgeverij = new Uitgeverij
                        {
                            Naam = uitgeverijNaam
                        };
                        context.Uitgeverijen.Add(uitgeverij);
                        Console.WriteLine("Info: nieuwe uitgeverij aangemaakt");
                    }

                    // We doen hetzelfde voor auteur 
                    Auteur auteur = context.Auteurs.FirstOrDefault(u => u.Naam == auteurNaam);
                    // Auteur werd werd niet gevonden
                    if (auteur == null)
                    {
                        // Dus maken we één aan:
                        auteur = new Auteur
                        {
                            Naam = auteurNaam
                        };
                        context.Auteurs.Add(auteur);
                        Console.WriteLine("Info: nieuwe auteur aangemaakt");
                    }


                    // Ik heb nu toegang tot zowel Auteur als Uitgeverij
                    // Of die al dan niet 'nieuw' of 'bestaand' is, maakt niet meer uit. EF Core houdt daar rekening mee.

                    // Volgende stap is om het boek te maken
                    var boek = new Boek
                    {
                        ISBNNr = isbnnr,
                        Auteur = auteur,
                        Uitgeverij = uitgeverij,
                        PaginaAantal = aantalPaginas,
                        Title = title
                        // UitgeverijID en AuteurID moet ik niet invullen
                    };

                    // En toevoegen aan de context
                    context.Boeken.Add(boek);

                    // Laatste stap is om te saven
                    context.SaveChanges();

                    Console.WriteLine("Boek werd toegevoegd!");
                }

            

            }

            Header();
        }

        // TODO!
        // Lijst tonen van alle auteurs
        // Tip: een auteur heeft veld [Id] (automatisch gegenereerd) en een [Naam]
        private static void ShowAuthors()
        {
            using (var connection = OpenConnection())
            {
                // We maken een commando object richting de database
                SqlCommand command = connection.CreateCommand();

                // We geven deze een CommandText, nl. onze query
                command.CommandText = "SELECT Id, Naam FROM Auteur";

                // Commando uitvoeren. Ook deze implementeert de IDisposable interface, 
                // dus ofwel roepen we Dispose() op, ofwel gebruiken we using
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // reader.Read() blijft 'true' geven zolang er nog rijen beschikbaar zijn om te raadplegen
                    // indien geen rijen meer beschikbaar, wordt het resultaat 'false' en stopt onze while-loop
                    while (reader.Read())
                    {
                        Console.WriteLine("Auteur: {1} (id = {0})", reader["Id"], reader["Naam"]);
                    }
                }
            }
            
        }

        // TODO!
        // Lijst tonen van alle uitgeverijen
        // Tip: een auteur heeft veld [Id] (automatisch gegenereerd) en een [Naam]
        private static void ShowPublishers()
        {
            using (var connection = OpenConnection())
            {
                // We maken een commando object richting de database
                SqlCommand command = connection.CreateCommand();

                // We geven deze een CommandText, nl. onze query
                command.CommandText = "SELECT Id, Naam FROM Uitgeverij";

                // Commando uitvoeren. Ook deze implementeert de IDisposable interface, 
                // dus ofwel roepen we Dispose() op, ofwel gebruiken we using
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // reader.Read() blijft 'true' geven zolang er nog rijen beschikbaar zijn om te raadplegen
                    // indien geen rijen meer beschikbaar, wordt het resultaat 'false' en stopt onze while-loop
                    while (reader.Read())
                    {
                        Console.WriteLine("Uitgeverij: {1} (id = {0})", reader["Id"], reader["Naam"]);
                    }
                }
            }
            Header();
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
            using (var context = new BoekenDatabaseContext())
            {
                var lijstBoeken = context.Boeken
                    .Include(boek => boek.Uitgeverij)
                    .Include(boek => boek.Auteur)
                    .ToList();

                Console.WriteLine($"Er werden {lijstBoeken.Count} boeken gevonden:");
                foreach(var boek in lijstBoeken)
                {
                    Console.WriteLine($" - '{boek.Title}' met ISBN-nummer '{boek.ISBNNr}' heeft {boek.PaginaAantal} pagina's," +
                        $" is geschreven door '{boek.Auteur.Naam}' en" + 
                        $" is uitgebracht door '{boek.Uitgeverij.Naam}'"
                    );
                }
            }
            Header();

        }

        // TODO! (uitbreiding)
        // TIP: Je kan een auteur pas verwijderen indien geen enkel boek deze nog referenced.
        // Toon dus een gepaste melding als dit het geval is -- geen exception!
        private static void DeleteAuthor()
        {
            
        }


        // TODO! (uitbreiding)
        // TIP: Je kan een uitgeverij pas verwijderen indien geen enkel boek deze nog referenced.
        // Toon dus een gepaste melding als dit het geval is -- geen exception!
        private static void DeletePublisher()
        {

        }


        // TODO! (uitbreiding)
        // TIP: Je kan een auteur pas verwijderen indien geen enkel boek deze nog referenced.
        // Toon dus een gepaste melding als dit het geval is -- geen exception!
        private static void DeleteBook()
        {

        }
    }
}
