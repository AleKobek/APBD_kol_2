namespace kolokwium_2.Entities;

public class Ingredient
{
    public int IdIngredient { get; set; }
    public string Name { get; set; }
    public bool NonAlcoholic { get; set; }

    public virtual ICollection<BeverageIngredient> Beverages { get; set; } = new List<BeverageIngredient>();
}