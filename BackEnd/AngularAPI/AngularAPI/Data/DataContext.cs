using Microsoft.EntityFrameworkCore;
using AngularAPI.models;

namespace AngularAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) {}

        public DbSet<City> Cities { get; set; }
    }
}