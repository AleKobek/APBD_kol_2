using kolokwium_2.Entities;

namespace kolokwium_2.DTO;

public record BeverageDTO(
    int Id,
    string Name,
    Decimal Price,
    ICollection<Ingredient> Ingredients
        );