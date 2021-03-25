using Microsoft.EntityFrameworkCore;
using System;
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
            Console.WriteLine("7. Een uitgeverij verwijderen (uitbreiding)");
            Console.WriteLine("8. Een auteur verwijderen (uitbreiding)");
            Console.WriteLine("9. Een boek verwijderen (uitbreiding)");

            // Verkrijg een numerieke input via readline. Deze mag maximaal 9 zijn!
            int choice = NumericInput("Keuze");            
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
                    DeletePublisher();
                    break;
                case 8:
                    DeleteAuthor();
                    break;
                case 9:
                    DeleteBook();
                    break;
            }

            ListActions();
        }

        private static void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: {message}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void Success(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Succes: {message}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static string TextInput(string veld)
        {
            string input;
            do
            {
                Console.Write($"> {veld}: ");
                input = Console.ReadLine();
            } while (string.IsNullOrEmpty(input));
            return input;
        }

        private static int NumericInput(string veld)
        {
            int value;
            do
            {
                Console.Write($"> {veld}: ");
            } while (!int.TryParse(Console.ReadLine(), out value));
            return value;
        }


        private static void Header()
        {
            Console.WriteLine("--------------------------");
        }

      
        // TODO!
        // Toevoegen van een auteur
        // Tip: een auteur heeft veld [Id] (automatisch gegenereerd) en een [Naam]
        private static void AddAuthor()
        {
            Console.WriteLine("# Auteur toevoegen");
            string naam = TextInput("Naam");

            using (var context = new BoekenDatabaseContext())
            {
                // Kijk of boek al bestaat
                var auteurBestaat = context.Auteurs.Any(auteur => auteur.Naam == naam);

                if(auteurBestaat)
                {
                    Error("Deze auteur bestaat al!");
                    return;
                } 
                
                context.Auteurs.Add(new Auteur
                {
                    Naam = naam
                });

                context.SaveChanges();
                Success($"Auteur '{naam}' toegevoegd.");
                
            }
            Header();
        }

        // TODO!
        // Toevoegen van een uitgeverij
        // Tip: een auteur heeft veld [Id] (automatisch gegenereerd) en een [Naam]
        private static void AddPublisher()
        {
            Console.WriteLine("# Uitgeverij toevoegen");

            string naam = TextInput("Naam");

            using (var context = new BoekenDatabaseContext())
            {
                // Kijk of boek al bestaat
                var uitgeverijBestaat = context.Uitgeverijen
                    .Any(uitgeverij => uitgeverij.Naam == naam);

                if (uitgeverijBestaat)
                {
                    Error("Deze uitgeverij bestaat al!");
                    return;
                }
               
                context.Uitgeverijen.Add(new Uitgeverij
                {
                    Naam = naam
                });

                context.SaveChanges();
                Success($"Uitgeverij '{naam}' toegevoegd.");
                
            }

            Header();
        }

        // TODO!
        // Toevoegen van een boek
        // Tip: een auteur heeft veld [Id] (automatisch gegenereerd), [Titel], [PaginaAantal] en 2 foreign keys
        private static void AddBook()
        {
            string title = TextInput("Titel");
            string isbnnr = TextInput("ISBN-nummer");
            int aantalPaginas = NumericInput("Aantal pagina's");
            string uitgeverijNaam = TextInput("Naam uitgeverij");
            string auteurNaam = TextInput("Naam auteur");

            using (var context = new BoekenDatabaseContext())
            {
                // Bestaat boek al ?
                var bestaandBoek= context.Boeken.FirstOrDefault(boek => boek.ISBNNr == isbnnr || boek.Title == title);
                if (bestaandBoek != null)
                {
                    Error($"Dit boek bestaat al (id = {bestaandBoek.ISBNNr})");
                }
                else
                {
                    // Boek toevoegen -- een boek heeft een auteur en uitgeverij nodig.
                    // Indien een auteur al bestaat, wil ik dat deze gebruikt wordt. Anders aanmaken.
                    // Idem voor een uitgeverij 
                    Uitgeverij uitgeverij = context.Uitgeverijen.FirstOrDefault(u => u.Naam == uitgeverijNaam);
                    // Uitgeverij werd niet gevonden
                    if (uitgeverij == null)
                    {
                        // Dus maken we één aan:
                        uitgeverij = new Uitgeverij
                        {
                            Naam = uitgeverijNaam
                        };
                        context.Uitgeverijen.Add(uitgeverij);
                        Success("Info: nieuwe uitgeverij aangemaakt");
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
                        Success("Info: nieuwe auteur aangemaakt");
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

                    Success("Boek werd toegevoegd!");
                }       
            }
            Header();
        }

        // TODO!
        // Lijst tonen van alle auteurs
        // Tip: een auteur heeft veld [Id] (automatisch gegenereerd) en een [Naam]
        private static void ShowAuthors()
        {
            using (var context = new BoekenDatabaseContext())
            {
                var auteurs = context.Auteurs
                    .Include(auteur => auteur.Boeken)
                    .ToList();

                foreach (var auteur in auteurs)
                {
                    Console.WriteLine("Auteur: {1} (id = {0}) heeft {2} boek(en) geschreven: ",
                        auteur.Naam, auteur.Id, auteur.Boeken.Count);

                    foreach (var boek in auteur.Boeken)
                    {
                        Console.WriteLine($" - Boek: {boek.Title} (ISBN-nummer = {boek.ISBNNr}");
                    }
                }

            }
            Header();
        }

        // TODO!
        // Lijst tonen van alle uitgeverijen
        // Tip: een auteur heeft veld [Id] (automatisch gegenereerd) en een [Naam]
        private static void ShowPublishers()
        {
            using (var context = new BoekenDatabaseContext())
            {
                var uitgeverijen = context.Uitgeverijen
                    .Include(uitgeverij => uitgeverij.Boeken)
                    .ToList();

                foreach(var uitgeverij in uitgeverijen)
                {
                    Console.WriteLine("Uitgeverij: {1} (id = {0}) heeft {2} boek(en) uitgebracht: ", 
                        uitgeverij.Naam, uitgeverij.Id, uitgeverij.Boeken.Count);

                    foreach(var boek in uitgeverij.Boeken)
                    {
                        Console.WriteLine($" - Boek: {boek.Title} (ISBN-nummer = {boek.ISBNNr}");
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
            int authorId = NumericInput("Author ID");
         
            using (var context = new BoekenDatabaseContext())
            {
                // zoek de auteur; kijk of die bestaat
                var auteur = context.Auteurs
                    .Include(auteur => auteur.Boeken)
                    .FirstOrDefault(auteur => auteur.Id == authorId);

                if(auteur == null)
                {
                    Error("Geen auteur met deze ID gevonden");
                    return;
                }

                if (auteur.Boeken.Any())
                {
                    Error("Deze auteur heeft verschillende boeken uitgebracht. Verwijderen is niet toegestaan!");
                    return;
                }
                
                context.Auteurs.Remove(auteur);
                context.SaveChanges();
                Success("Deze auteur werd verwijderd");
            }
            Header();
        }


        // TODO! (uitbreiding)
        // TIP: Je kan een uitgeverij pas verwijderen indien geen enkel boek deze nog referenced.
        // Toon dus een gepaste melding als dit het geval is -- geen exception!
        private static void DeletePublisher()
        {
            string uitgeverijNaam = TextInput("Naam uitgeverij");
      
            using (var context = new BoekenDatabaseContext())
            {
                // zoek de auteur; kijk of die bestaat
                // FirstOrDefault geeft een uitgeverij terug indien gevonden
                // of 'null' indien niks gevonden
                var uitgeverij = context.Uitgeverijen
                    .Include(uitgeverij => uitgeverij.Boeken)
                    .FirstOrDefault(uitgeverij => uitgeverij.Naam == uitgeverijNaam);

                if (uitgeverij == null)
                {
                    Error("Geen uitgeverij met deze naam gevonden");
                    return;
                }

                if (uitgeverij.Boeken.Any())
                {
                    Error("Deze uitgeverij heeft verschillende boeken uitgebracht. Verwijderen is niet toegestaan!");
                    return;
                }

                context.Uitgeverijen.Remove(uitgeverij);
                context.SaveChanges();
                Success("Uitgeverij werd verwijderd");
            }
        }


        private static void DeleteBook()
        {
            Console.WriteLine("# Boek verwijderen");
            string isbnnr = TextInput("ISBN-nummer");

            using (var context = new BoekenDatabaseContext())
            {
                var boek = context.Boeken.FirstOrDefault(boek => boek.ISBNNr == isbnnr);

                if(boek == null)
                {
                    Error($"Boek met isbn-nummer '{isbnnr}' werd niet gevonden");
                    return;
                }

                context.Boeken.Remove(boek);
                context.SaveChanges();
                Success("Boek werd verwijderd");
            }
            Header();
        }
    }
}
