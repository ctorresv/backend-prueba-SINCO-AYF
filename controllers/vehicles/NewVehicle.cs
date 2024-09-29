using Backend.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Backend.Controllers.Vehicles
{

    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly MiDbContext _context;

        public VehicleController(MiDbContext context)
        {
            _context = context;

        }

        [HttpPost("add")]
        [Authorize]
        public async Task<IActionResult> AddVehicle([FromBody] TableOfVehicles vehicle)
        {
            try
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

                if (userIdClaim == null)
                {
                    return Unauthorized("User not logged in.");
                }

                vehicle.UserId = int.Parse(userIdClaim.Value);
                vehicle.CreationDate = DateTime.Now;

                _context.Vehicles.Add(vehicle);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Vehicle added successfully.", vehicle });
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = "Error al borrar vehiculo", details = ex.Message });
            }
        }
    }
}