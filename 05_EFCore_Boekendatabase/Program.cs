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
