using kolokwium_2.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kolokwium_2.Configs;

public class BeverageIngredientEFConfig : IEntityTypeConfiguration<BeverageIngredient>
{
    public void Configure(EntityTypeBuilder<BeverageIngredient> builder)
    {
        builder
            .HasKey(x => new { x.IdBeverage, x.IdIngredient })
            .HasName("BeverageIngredient_pk");

        builder
            .HasOne(x => x.Beverage)
            .WithMany(x => x.Ingredients)
            .HasForeignKey(x => x.IdBeverage)
            .HasConstraintName("BecerageIngredient_Beverage")
            .OnDelete(DeleteBehavior.Restrict);
        builder
            .HasOne(x => x.Ingredient)
            .WithMany(x => x.Beverages)
            .HasForeignKey(x => x.IdIngredient)
            .HasConstraintName("BecerageIngredient_Ingredient")
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .Property(x => x.Amount)
            .IsRequired()
            .HasMaxLength(10);

        builder.ToTable(nameof(BeverageIngredient));
        
        BeverageIngredient[] beverageIngredients =
        {
            new () {IdIngredient = 1, IdBeverage = 1, Amount = "20"},
            new () {IdIngredient = 2, IdBeverage = 2, Amount = "15"},
            new () {IdIngredient = 3, IdBeverage = 3, Amount = "10"},
        };

        builder.HasData(beverageIngredients);
    }
}