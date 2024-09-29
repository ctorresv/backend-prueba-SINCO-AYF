using Backend.Data;
using Backend.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace Backend.Controllers.Users
{
    [ApiController]
    [Route("api/[controller]")]
    public class SignUpUsersController : ControllerBase
    {
        private readonly MiDbContext _context;

        public SignUpUsersController(MiDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto registerDto)
        {
            try
            {
                if (_context.Users.Any(u => u.Email == registerDto.Email))
                {
                    return BadRequest("El correo ya está en uso.");
                }

                string hashedPassword = HashPassword(registerDto.Password);

                var newUser = new TableOfUser
                {
                    Email = registerDto.Email,
                    Password = hashedPassword
                };

                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();

                return Ok("Usuario registrado exitosamente.");
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = "Error al registrar usuario", details = ex.Message });
            }
        }
        private string HashPassword(string? password)
        {
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password), "La contraseña no puede ser nula.");
            }
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}
