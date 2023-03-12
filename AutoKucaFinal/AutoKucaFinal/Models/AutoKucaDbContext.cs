using Microsoft.EntityFrameworkCore;

namespace AutoKucaFinal.Models
{
    public class AutoKucaDbContext:DbContext
    {
        public AutoKucaDbContext(DbContextOptions options):base(options) 
        {
            
        }   
        public DbSet<Color> Colors { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get;set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Doors> Doors { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<TransmissionType> TransmissionTypes { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
