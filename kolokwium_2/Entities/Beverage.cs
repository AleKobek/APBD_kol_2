namespace kolokwium_2.Entities;

public class Beverage
{
    public int IdBeverage { get; set; }
    public string Name { get; set; }
    public Decimal Price { get; set; }

    public virtual ICollection<BeverageIngredient> Ingredients { get; set; } = new List<BeverageIngredient>();
}