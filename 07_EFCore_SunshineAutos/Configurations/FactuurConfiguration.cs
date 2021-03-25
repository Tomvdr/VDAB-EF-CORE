using _07_EFCore_SunshineAutos.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace _07_EFCore_SunshineAutos.Configurations
{
 
    public class FactuurConfiguration : IEntityTypeConfiguration<Factuur>
    {
        public void Configure(EntityTypeBuilder<Factuur> factuur)
        {
            factuur.ToTable("Factuur");
            factuur.HasKey(_ => _.FactuurNr);

            factuur.Property(_ => _.FactuurDatum).IsRequired();
            factuur.Property(_ => _.Bedrag).IsRequired();

            factuur.HasOne(_ => _.Wagen).WithOne(_ => _.Factuur)
                .HasForeignKey<Wagen>(_ => _.ChassisNr);

            factuur.HasOne(_ => _.Klant).WithMany(_ => _.Facturen)
                .HasForeignKey(_ => _.KlantNr);

            factuur.HasOne(_ => _.Verkoper).WithMany(_ => _.Facturen)
                .HasForeignKey(_ => _.VerkoperId);
        }
    }
}