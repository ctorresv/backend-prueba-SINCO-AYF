using Backend.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Backend.Controllers.Vehicles
{

    [ApiController]
    [Route("api/[controller]")]
    public class DeleteVehicleController : ControllerBase
    {
        private readonly MiDbContext _context;

        public DeleteVehicleController(MiDbContext context)
        {
            _context = context;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            try
            {
                var vehicle = await _context.Vehicles.FindAsync(id);
                if (vehicle == null)
                {
                    return NotFound();
                }
                _context.Vehicles.Remove(vehicle);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = "Error al borrar vehiculo", details = ex.Message });
            }
        }
    }
}