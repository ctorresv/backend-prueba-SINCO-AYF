using Backend.Data;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Sales
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly MiDbContext _context;

        public SalesController(MiDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] SalesTable salesRegister)
        {
            try
            {
                if (salesRegister == null)
                {
                    return BadRequest("Sales data is required.");
                }
                var newSale = new SalesTable
                {
                    Name = salesRegister.Name,
                    Document = salesRegister.Document,
                    Model = salesRegister.Model,
                    Price = salesRegister.Price,

                };
                salesRegister.CreationDate = DateTime.Now;

                _context.Sales.Add(newSale);
                await _context.SaveChangesAsync();

                return Ok("Sale created successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

        }
    }
}