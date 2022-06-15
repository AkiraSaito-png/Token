using Microsoft.EntityFrameworkCore;

namespace sebsa.Models
{
    public class Database : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(connectionString: @"Server=(localdb)\mssqllocaldb;Password=1234;Host=localhost;Port=5432;Database=sebsa;");

        }
    }
}
