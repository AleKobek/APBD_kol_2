using kolokwium_2.Entities;

namespace kolokwium_2.Repositories;

public interface IIngredientRepository
{
    //public Task<ICollection<Ingredient>> GetIngredients(int id);
    public Task<bool> DoesIngredientExist(int id);
    public Task<bool> IsIngredientAlcoholic(Ingredient ingredient);
}