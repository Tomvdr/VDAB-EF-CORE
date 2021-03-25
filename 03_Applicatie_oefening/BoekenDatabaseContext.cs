using _00_Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace _03_Applicatie_oefening
{
    public class BoekenDatabaseContext : DbContext
    {
        private static readonly ILoggerFactory _loggerFactory 
            = LoggerFactory.Create(builder => { builder.AddConsole(); });



        // Tabellen
        public DbSet<Boek> Boeken { get; set; }
        public DbSet<Auteur> Auteurs { get; set; }
        public DbSet<Uitgeverij> Uitgeverijen { get; set; }


        // Wordt opgeroepen bij creatie
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                //.UseLoggerFactory(_loggerFactory)  //tie-up DbContext with LoggerFactory object
                //.EnableSensitiveDataLogging()
                .UseSqlServer(ConnectionString.Boekendatabase);
        }


        protected override void OnModelCreating(ModelBuilder  modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /*
             * De volgende instellingen kunnen ook zo ingesteld worden.
             * Alternatief is de [Table()] attribuut en de [Key] attribuut
             
            modelBuilder.Entity<Boek>().HasKey(_ => _.ISBNNr);
            modelBuilder.Entity<Boek>().ToTable("Boek");

            modelBuilder.Entity<Auteur>().HasKey(_ => _.Id);
            modelBuilder.Entity<Auteur>().ToTable("Auteur");


            modelBuilder.Entity<Uitgeverij>().HasKey(_ => _.Id);
            modelBuilder.Entity<Uitgeverij>().ToTable("Uitgeverij");
            */
        }

        // Heeft een lege constructor nodig voor interne werking
        public BoekenDatabaseContext()
        {
            
        }
    }
}
