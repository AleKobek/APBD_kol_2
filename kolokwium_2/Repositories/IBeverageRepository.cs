using kolokwium_2.DTO;

namespace kolokwium_2.Repositories;

public interface IBeverageRepository
{
    public Task<ICollection<BeverageDTO>> GetBeverages();

    public void AddBeverage(BeverageDTO beverage);
}