namespace kolokwium_2.Entities;

public class BeverageIngredient
{
    public int IdBeverage { get; set; }
    public int IdIngredient { get; set; }
    public string Amount { get; set; }
    
    public virtual Beverage Beverage { get; set; }
    public virtual Ingredient Ingredient { get; set; }
}