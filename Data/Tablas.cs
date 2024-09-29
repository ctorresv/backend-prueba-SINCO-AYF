namespace Backend.Data
{
    public class TableOfVehicles
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public TableOfUser? User { get; set; }
        public bool Used { get; set; }
        public bool TypeVehicle {get; set;}
        public string? Model { get; set; }
        public string? Color { get; set; }
        public float Mileage { get; set; }
        public float Value { get; set; }
        public string? Image { get; set; }
        public int? NumOfSpeeds { get; set; }
        public string? Cylinder { get; set; }
        public DateTime CreationDate { get; set; }
    }

    public class TableOfUser
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool IsOnline { get; set; }
        public ICollection<TableOfVehicles>? Vehicles { get; set; }
    }

    public class VehiclePrice
    {       
        public int Id { get; set; }
        public string? Model { get; set; }
        public float Price { get; set; } 
    }

    public class SalesTable 
    {
        public int Id {get; set;}
        public string? Name {get; set;}
        public string? Document {get; set;}
        public string? Model {get; set;}
        public string? Price {get; set;} 
        public DateTime CreationDate { get; set; }

    }

}
