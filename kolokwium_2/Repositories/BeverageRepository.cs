
using kolokwium_2.Context;
using kolokwium_2.DTO;
using kolokwium_2.Entities;
using Microsoft.EntityFrameworkCore;

namespace kolokwium_2.Repositories;

public class BeverageRepository : IBeverageRepository
{
    private readonly DrinksDbContext _context;
    private readonly IIngredientRepository _ingredientRepository;

    public BeverageRepository(DrinksDbContext context)
    {
        _context = context;
    }

    public async Task<ICollection<BeverageDTO>> GetBeverages()
    {
        ICollection<BeverageDTO> beveragesToReturn = new List<BeverageDTO>();
        ICollection<Beverage> beverages = await _context.Beverages.ToListAsync();
        foreach (var beverage in beverages)
        {
            ICollection<Ingredient> ingredients = new List<Ingredient>();
            // tu powinien być join, ale zapomniałam jak to zrobić i muszę iść na około
            ICollection<BeverageIngredient> beverageIngredients = await _context.BeverageIngredients.Where(x => x.IdBeverage == beverage.IdBeverage)
                .ToListAsync();
            foreach (var beverageIngredient in beverageIngredients)
            {
                ingredients.Add(await _context.Ingredients.Where(x=>x.IdIngredient == beverageIngredient.IdIngredient).FirstOrDefaultAsync());
            }
            beveragesToReturn.Add(new BeverageDTO(beverage.IdBeverage, beverage.Name, beverage.Price, ingredients));
        }

        return beveragesToReturn;
    }

    public async void AddBeverage(BeverageDTO beverage)
    {
        // powinien zawierać co najmniej jeden składnik, jak nie ma to dodać
        // jeśli jakikolwiek ma alkochol, to trzeba podnieść cenę o 10%

        (
            int Id,
            string Name,
            Decimal Price,
            ICollection<Ingredient> Ingredients
        ) = beverage;

        bool czyBylAlkochoowy = false;

        foreach (var ingredient in Ingredients)
        {
            if (await _ingredientRepository.IsIngredientAlcoholic(ingredient))
            {
                if (!czyBylAlkochoowy)
                {
                    Price = Price * new decimal(1.1);
                    czyBylAlkochoowy = true;
                }
            }
        }

        Beverage beverageAdd = new Beverage
        {
            IdBeverage = Id,
            Name = Name,
            Price = Price
        };

        await _context.Beverages.AddAsync(beverageAdd);
        
        // nie mam czasu dodać składników

    }


    private async Task<bool> DoesBeverageExist(int id)
    {
        return await _context.Beverages.FindAsync(id) != null;
    }
}