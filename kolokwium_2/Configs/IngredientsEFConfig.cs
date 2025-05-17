using kolokwium_2.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kolokwium_2.Configs;

public class IngredientsEFConfig : IEntityTypeConfiguration<Ingredient>
{
    public void Configure(EntityTypeBuilder<Ingredient> builder)
    {
        builder
            .HasKey(x => x.IdIngredient)
            .HasName("Ingredient_pk");
        builder
            .Property(x => x.IdIngredient)
            .ValueGeneratedNever();

        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(30);

        builder
            .Property(x => x.NonAlcoholic)
            .IsRequired();

        builder.ToTable(nameof(Ingredient));

        Ingredient[] ingredients =
        {
            new () {IdIngredient = 1, Name = "Cytryna", NonAlcoholic = true},
            new () {IdIngredient = 2, Name = "Nie pamietam co", NonAlcoholic = false},
            new () {IdIngredient = 3, Name = "Gumijagoda", NonAlcoholic = false}
        };

        builder.HasData(ingredients);
    }
}