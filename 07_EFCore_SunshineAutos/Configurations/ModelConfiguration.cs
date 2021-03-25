using _07_EFCore_SunshineAutos.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _07_EFCore_SunshineAutos.EntityMappings
{
 
    // IEntityTypeConfiguration is een Interface van EF-Core die gebruikt wordt voor de structuur van een Code-First model te maken
    // Je kan hier tabelnamen instellen, relaties (1-to-many, many-to-many, 1-to-1), 
    // Als parameter krijgen we een EntityTypeBuilder van het type Merk
    // Zo weet EF Core dat de configuratie voor entiteit 'Merk' te vinden is in dit bestand
    public class ModelConfiguration : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> model)
        {
            // Instellen welke de primary key is. Dit is hetzelfde als het [Key] attribuut
            // De underscore in onderstaande predicates staat voor Merk.
            model.HasKey(_ => _.Id);

            // De tabelnaam die EF core moet genereren & gebruiken
            model.ToTable("Model");

            // Required properties: dit genereert een database structuur waar onderstaande kolommen "Not-Null" zijn
            model.Property(_ => _.Naam).IsRequired();

            // Relaties
            // Een model heeft één merk -- omgekeerd heeft een merk meerdere modellen
            // Dwz. dat we een HasMany().WithOne() moeten schrijven:
            model.HasOne(_ => _.Merk)
                .WithMany(_ => _.Modellen)
                .HasForeignKey(_ => _.MerkId);
            
        }
    }
}
