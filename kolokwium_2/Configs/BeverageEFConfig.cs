using kolokwium_2.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kolokwium_2.Configs;

public class BeverageEFConfig : IEntityTypeConfiguration<Beverage>
{
    public void Configure(EntityTypeBuilder<Beverage> builder)
    {
        builder
            .HasKey(x => x.IdBeverage)
            .HasName("Beverage_pk");
        builder
            .Property(x => x.IdBeverage)
            .ValueGeneratedNever();

        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(30);
        builder
            .Property(x => x.Price)
            .IsRequired();

        builder.ToTable(nameof(Beverage));

        Beverage[] beverages =
        {
            new() {IdBeverage = 1, Name = "Lemoniada", Price = new decimal(4.50)},
            new() {IdBeverage = 2, Name = "Wudka", Price = new decimal(7.99)},
            new() {IdBeverage = 3, Name = "Sok z gumijagudek", Price = new decimal(15.30)},
        };

        builder.HasData(beverages);
    }
}