using Backend.Data;
using Backend.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers.Users
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogoutController : ControllerBase
    {
        private readonly MiDbContext _context;

        public LogoutController(MiDbContext context)
        {
            _context = context;
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] LogoutUserDto logoutDto)
        {
            try
            {
                var user = await _context.Users
                    .SingleOrDefaultAsync(u => u.Email == logoutDto.Email);

                if (user == null)
                {
                    return BadRequest("Usuario no encontrado.");
                }

                if (!user.IsOnline)
                {
                    return BadRequest("El usuario no está en línea.");
                }

                user.IsOnline = false;
                await _context.SaveChangesAsync();

                return Ok("Cierre de sesión exitoso.");
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = "Error al insertar cerrar secion", details = ex.Message });
            }
        }
    }
}
