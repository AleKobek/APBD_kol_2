using kolokwium_2.Context;
using kolokwium_2.Entities;

namespace kolokwium_2.Repositories;

public class IngredientRepository : IIngredientRepository
{
    private readonly DrinksDbContext _context;

    public async Task<bool> DoesIngredientExist(int id)
    {
        return await _context.Ingredients.FindAsync(id) != null;
    }

    public async Task<bool> IsIngredientAlcoholic(Ingredient ingredient)
    {
        Ingredient? ingredient2 = await _context.Ingredients.FindAsync(ingredient.IdIngredient);
        if (ingredient2 == null)
        {
            await _context.Ingredients.AddAsync(ingredient);
        }
        return !ingredient.NonAlcoholic;
    }
    
}