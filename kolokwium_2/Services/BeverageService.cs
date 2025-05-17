using kolokwium_2.DTO;
using kolokwium_2.Entities;
using kolokwium_2.Repositories;

namespace kolokwium_2.Services;

public class BeverageService
{
    private readonly IBeverageRepository _repository;

    public BeverageService(IBeverageRepository repository)
    {
        _repository = repository;
    }

    public async Task<ICollection<BeverageDTO>> GetBeverages()
    {
        return await _repository.GetBeverages();
    }

    public void AddBeverage(BeverageDTO beverage)
    {
        _repository.AddBeverage(beverage);
    }
    
    
}