using Backend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class VehiclePricesController : ControllerBase
{
    private readonly MiDbContext _context;

    public VehiclePricesController(MiDbContext context)
    {
        _context = context;
    }

    [HttpGet("read")]
    public async Task<IActionResult> GetVehicles([FromQuery] string? Model = null)
    {
        try
        {
        var query = _context.VehiclePrice.AsQueryable(); 

        if (!string.IsNullOrWhiteSpace(Model))
        {
            query = query.Where(v => v.Model != null && v.Model.Contains(Model));
        }

        var vehicles = await query.ToListAsync(); 
        return Ok(vehicles);
            
        }
        catch (System.Exception ex)
        {
            return BadRequest(new { message = "Error al leer los datos", details = ex.Message });
        }
    }
}
