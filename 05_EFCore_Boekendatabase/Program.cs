using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_EFCore_Boekendatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowAuthorsWithBooks();

            List<Boek> boeken = new List<Boek>
            {
                new Boek
                {
                    Title = "Harry Potter"
                },
                new Boek
                {
                    Title = "Later Stephen King"
                },
            };

            // LINQ-manier
            var result = boeken.Where(boek => boek.Title == "Harry Potter");


            // foreach
            List<Boek> result2 = new List<Boek>();
            foreach(var boek in boeken)
            {
                if(boek.Title == "Harry Potter")
                {
                    result2.Add(boek);
                }
            }
        }

        private static void ShowAuthorsWithBooks()
        {
            using (var context = new BoekenDatabaseContext())
            {
                Console.WriteLine("===================");
                Console.WriteLine("Take voor de ToList");
                Console.WriteLine("===================");
                var auteurs = context.Auteurs // select top 3 * from auteurs
                    .OrderBy(_ => _.Naam )
                    .Take(3)
                    .ToList();

                Console.WriteLine("===================");
                Console.WriteLine("ToList voor de Take");
                Console.WriteLine("===================");
                var auteurs2 = context.Auteurs // select top 3 * from auteurs
                     .OrderBy(_ => _.Naam)
                     .ToList()
                     .Take(3);





                context.SaveChanges();
            }
        }
    }
}
