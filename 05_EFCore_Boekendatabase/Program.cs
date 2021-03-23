using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace _05_EFCore_Boekendatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowAuthorsWithBooks();
        }

        private static void ShowAuthorsWithBooks()
        {
            using (var context = new BoekenDatabaseContext())
            {
                var auteurs = context
                    .Auteurs
                    .Include(_ => _.Boeken)
                    .ToList();

                foreach (var auteur in auteurs)
                {
                    Console.WriteLine("{0} - {1}", auteur.Id, auteur.Naam);

                    foreach (var boek in auteur.Boeken)
                    {
                        Console.WriteLine("> {0} - {1}", boek.ISBNNr, boek.Title);
                    }
                }
            }
        }
    }
}
