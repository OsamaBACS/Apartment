using Microsoft.EntityFrameworkCore;
using BackEnd.models;

namespace BackEnd.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) {}

        public DbSet<City> Cities { get; set; }
        public DbSet<User> Users { get; set; }
    }
}