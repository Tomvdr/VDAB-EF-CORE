using _07_EFCore_SunshineAutos.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _07_EFCore_SunshineAutos.EntityMappings
{
 
    // IEntityTypeConfiguration is een Interface van EF-Core die gebruikt wordt voor de structuur van een Code-First model te maken
    // Je kan hier tabelnamen instellen, relaties (1-to-many, many-to-many, 1-to-1), 
    // Als parameter krijgen we een EntityTypeBuilder van het type Merk
    // Zo weet EF Core dat de configuratie voor entiteit 'Merk' te vinden is in dit bestand
    public class MerkConfiguration : IEntityTypeConfiguration<Merk>
    {
        public void Configure(EntityTypeBuilder<Merk> merk)
        {
            // Instellen welke de primary key is. Dit is hetzelfde als het [Key] attribuut
            // De underscore in onderstaande predicates staat voor Merk.
            merk.HasKey(_ => _.Id);

            // De tabelnaam die EF core moet genereren & gebruiken
            merk.ToTable("Merk");

            // Required properties: dit genereert een database structuur waar onderstaande kolommen "Not-Null" zijn
            merk.Property(_ => _.Naam).IsRequired();

            // Relaties
            // Een merk heeft meerdere modellen -- omgekeerd heeft een model maar één merk. Dit is een één-op-veel relatie
            // Dwz. dat we een HasMany().WithOne() moeten schrijven:
            merk.HasMany(_ => _.Modellen).WithOne(_ => _.Merk).HasForeignKey(_ => _.MerkId);
            // Bovenstaand lees je dus als "een merk heeft meerdere modellen, een model heeft één merk"
            // Dit is noodzakelijk, EF core gaat hier onze foreign keys aanmaken.
        }
    }
}
