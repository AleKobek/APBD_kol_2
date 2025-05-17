using kolokwium_2.Configs;
using kolokwium_2.Entities;
using Microsoft.EntityFrameworkCore;

namespace kolokwium_2.Context;

public class DrinksDbContext : DbContext
{
    public virtual DbSet<Beverage> Beverages { get; set; }
    public virtual DbSet<Ingredient> Ingredients { get; set; }
    // wiem, że nie trzeba, ale zapomniałam jak zrobić join
    public virtual DbSet<BeverageIngredient> BeverageIngredients { get; set; }

    public DrinksDbContext()
    {
        
    }

    public DrinksDbContext(DbContextOptions<DrinksDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BeverageEFConfig).Assembly);
    }
}