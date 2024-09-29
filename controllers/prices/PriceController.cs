using Backend.Data;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Prices
{
    [ApiController]
    [Route("api/[controller]")]
    public class PriceController : ControllerBase
    {
        private readonly MiDbContext _context;

        public PriceController(MiDbContext context)
        {
            _context = context;
        }

        [HttpPost("insert")]
        public async Task<IActionResult> InsertVehiclePrices()
        {
            try
            {
                var vehiclePrices = new List<VehiclePrice>
            {
                new() { Model = "Hyundai Elantra", Price = 90000000 },
                new() { Model = "Ford Fiesta", Price = 70000000 },
                new() { Model = "Chevrolet Onix", Price = 75000000 },
                new() { Model = "Nissan Versa", Price = 80000000 },
                new() { Model = "Kia Seltos", Price = 120000000 },
                new() { Model = "Suzuki Swift", Price = 60000000 },
                new() { Model = "Honda Civic", Price = 150000000 },
                new() { Model = "Renault Kwid", Price = 50000000 },
                new() { Model = "Peugeot 208", Price = 65000000 },
                new() { Model = "Volkswagen Polo", Price = 78000000 },
                new() { Model = "Mazda 2", Price = 85000000 },
                new() { Model = "Seat Ibiza", Price = 82000000 },
                new() { Model = "Fiat Argo", Price = 68000000 },
                new() { Model = "Toyota Yaris", Price = 90000000 },
                new() { Model = "Nissan Kicks", Price = 110000000 },
                new() { Model = "Ford EcoSport", Price = 100000000 },
                new() { Model = "Chevrolet Tracker", Price = 95000000 },
                new() { Model = "Honda HR-V", Price = 135000000 },
                new() { Model = "Toyota Corolla", Price = 85000000 },
                new() { Model = "Hyundai Tucson", Price = 145000000 },
                new() { Model = "Renault Duster", Price = 100000000 },
                new() { Model = "Nissan X-Trail", Price = 160000000 },
                new() { Model = "Jeep Compass", Price = 180000000 },
                new() { Model = "Toyota RAV4", Price = 200000000 },
                new() { Model = "Mitsubishi Outlander", Price = 170000000 },
                new() { Model = "Skoda Kodiaq", Price = 210000000 },
                new() { Model = "Volkswagen T-Cross", Price = 130000000 },
                new() { Model = "Chevrolet Trailblazer", Price = 200000000 },
                new() { Model = "Ford Mustang", Price = 240000000 },
                new() { Model = "BMW Serie 1", Price = 220000000 },
                new() { Model = "Audi A3", Price = 230000000 },
                new() { Model = "Yamaha MT-03", Price = 25000000 },
                new() { Model = "Honda CB500F", Price = 30000000 },
                new() { Model = "KTM Duke 390", Price = 28000000 },
                new() { Model = "Bajaj Dominar 400", Price = 32000000 },
                new() { Model = "Kawasaki Ninja 250", Price = 40000000 },
                new() { Model = "Honda CRF250L", Price = 35000000 },
                new() { Model = "Yamaha YZF-R3", Price = 50000000 },
                new() { Model = "Suzuki GSX250R", Price = 30000000 },
                new() { Model = "KTM RC 200", Price = 35000000 },
                new() { Model = "Honda CBR500R", Price = 55000000 },
                new() { Model = "Royal Enfield Himalayan", Price = 48000000 },
                new() { Model = "Kawasaki Z400", Price = 45000000 },
                new() { Model = "BMW G310R", Price = 65000000 },
                new() { Model = "TVS Apache RTR 200", Price = 25000000 },
                new() { Model = "Ducati Scrambler Sixty2", Price = 75000000 },
                new() { Model = "Yamaha R15", Price = 35000000 },
                new() { Model = "Honda CB650R", Price = 85000000 },
                new() { Model = "KTM 790 Duke", Price = 150000000 },
                new() { Model = "Husqvarna Vitpilen 401", Price = 100000000 },
                new() { Model = "Kawasaki Ninja 650", Price = 90000000 },
                new() { Model = "Honda Africa Twin", Price = 220000000 },
                new() { Model = "Suzuki V-Strom 650", Price = 100000000 },
                new() { Model = "BMW F850GS", Price = 180000000 },
                new() { Model = "Kawasaki Versys 650", Price = 140000000 },
                new() { Model = "Royal Enfield Interceptor 650", Price = 75000000 },
                new() { Model = "Honda CB1000R", Price = 200000000 },
                new() { Model = "Triumph Street Triple", Price = 120000000 },
                new() { Model = "Ducati Monster 797", Price = 80000000 },
                new() { Model = "Harley-Davidson Street 750", Price = 150000000 },
                new() { Model = "Yamaha XSR700", Price = 75000000 },
                new() { Model = "Moto Guzzi V85 TT", Price = 120000000 },
                new() { Model = "Indian Scout", Price = 200000000 },
            };
                await _context.VehiclePrice.AddRangeAsync(vehiclePrices);
                await _context.SaveChangesAsync();
                return Ok("Precios de vehículos insertados correctamente.");
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = "Error al insertar los precios de los vehículos.", details = ex.Message });
            }
        }
    }
}
