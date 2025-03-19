using Microsoft.EntityFrameworkCore;
using XemXe.Domain.Entities;
using Type = System.Type;

namespace XemXe.Infrastructure.Data;

public class CarDbContext : DbContext
{
    public CarDbContext(DbContextOptions<CarDbContext> options) : base(options) {}
    
    public DbSet<Manufacturer> Manufacturers { get; set; }
    public DbSet<CarType> Types { get; set; }
    public DbSet<CarModel> Models { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Image> Images { get; set; }
}