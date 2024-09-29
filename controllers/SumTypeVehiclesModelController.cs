using Backend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleSumController : ControllerBase
    {
        private readonly MiDbContext _context;

        public VehicleSumController(MiDbContext context)
        {
            _context = context;
        }

        [HttpGet("sum")]
        public async Task<IActionResult> GetSum([FromQuery] bool? isCar = null, [FromQuery] string? model = null)
        {
            // Condicional para suma por tipo de vehículo carro o moto
            if (isCar.HasValue)
            {
                var totalValueByType = await _context.Vehicles
                    .Where(v => v.TypeVehicle == isCar.Value)
                    .SumAsync(v => v.Value);

                return Ok(new { TotalValue = totalValueByType, Filter = isCar.Value ? "Carros" : "Motos" });
            }

            // Condicional para suma por modelo
            if (!string.IsNullOrWhiteSpace(model))
            {
                var totalValueByModel = await _context.Vehicles
                    .Where(v => v.Model == model)
                    .SumAsync(v => v.Value);

                return Ok(new { TotalValue = totalValueByModel, Model = model });
            }
            return BadRequest("Debe especificar un parámetro 'isCar' para filtrar por tipo o 'model' para filtrar por modelo.");
        }
    }
}