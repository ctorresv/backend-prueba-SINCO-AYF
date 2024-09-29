using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Backend.Data; // Cambia esto por el namespace de tu DbContext
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Authorize] // Asegura que solo usuarios autenticados accedan a este controlador
    [ApiController]
    [Route("api/[controller]")]
    public class ReadUserVehicleController : ControllerBase
    {
        private readonly MiDbContext _context;
        public ReadUserVehicleController(MiDbContext context)
        {
            _context = context;
        }

        // GET: 
        [HttpGet]
        public async Task<IActionResult> GetUserVehicles()
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (userId == null)
                {
                    return Unauthorized("No se pudo obtener el UserId del token.");
                }

                // Filtrar vehículos por el UserId de forma asíncrona
                var userVehicles = await _context.Vehicles
                    .Where(v => v.UserId == int.Parse(userId))
                    .ToListAsync();

                if (userVehicles == null || userVehicles.Count == 0)
                {
                    return NotFound("No se encontraron vehículos para este usuario.");
                }

                return Ok(userVehicles); // Devolver los vehículos del usuario
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
    }
}
