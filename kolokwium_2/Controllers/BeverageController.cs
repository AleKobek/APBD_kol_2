using kolokwium_2.DTO;
using kolokwium_2.Entities;
using kolokwium_2.Services;
using Microsoft.AspNetCore.Mvc;

namespace kolokwium_2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BeverageController : ControllerBase
{
    private readonly BeverageService _service;

    public BeverageController(BeverageService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetBeverages()
    {
        try
        {
            return Ok(await _service.GetBeverages());
        }
        catch (NullReferenceException e)
        {
            return NotFound();
        }
    }
    
    
    [HttpPost]
    public async Task<IActionResult> AddBeverage(BeverageDTO beverage)
    {
        try
        {
            _service.AddBeverage(beverage);
            return Created();
        }
        catch (NullReferenceException e)
        {
            return NotFound();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
}