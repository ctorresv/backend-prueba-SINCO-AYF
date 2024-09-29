using Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Backend.Validators
{

public class VehicleValidator
{
    private readonly MiDbContext _context;

    public VehicleValidator(MiDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CanAddVehicleAsync(int userId, bool typeVehicle)
    {
        int carCount = await _context.Vehicles.CountAsync(v => v.UserId == userId && v.TypeVehicle);
        int motorcycleCount = await _context.Vehicles.CountAsync(v => v.UserId == userId && !v.TypeVehicle);

        if (typeVehicle)
        {
            return carCount < 10; // Verifica si el usuario tiene menos de 10 carros.
        }
        else
        {
            return motorcycleCount < 15; // Verifica si el usuario tiene menos de 15 motos.
        }
    }
}
}
