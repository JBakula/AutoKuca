using Microsoft.EntityFrameworkCore;

namespace AutoKuca.Models
{
    public class CarsDbContext:DbContext
    {
        public CarsDbContext(DbContextOptions options):base(options) 
        {

        }   
        public DbSet<Brand> Brands { get; set; }   
        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<TransmissionType> TransmissionTypes { get; set; }
        public DbSet<Doors> Doors { get; set; } 
        public DbSet<FuelType> FuelTypes { get; set; }  
        
    }
}
