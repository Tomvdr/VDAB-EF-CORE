using _00_Configuration;
using _07_EFCore_SunshineAutos.Entities;
using _07_EFCore_SunshineAutos.EntityMappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07_EFCore_SunshineAutos
{
    public class SunshineAutosContext : DbContext
    {
        // Dit zijn al onze DbSets / tabellen in de te genereren database
        // Aan jou om dit uit te breiden met de rest van de entiteiten
        public DbSet<Merk> Merken{ get; set; }
        // ....

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(ConnectionString.SunshineAutos);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Al onze configuraties moeten toegevoegd worden;
            // Dit is al het geval voor MerkConfiguration & ModelConfiguration
            // Aan jou om dit voor de rest ook in orde te zetten
            modelBuilder.ApplyConfiguration(new MerkConfiguration());
            modelBuilder.ApplyConfiguration(new ModelConfiguration());
            // ...
        }
    }

}
