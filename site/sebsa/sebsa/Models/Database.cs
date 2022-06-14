using Microsoft.EntityFrameworkCore;

namespace sebsa.Models
{
    public class Database : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(connectionString: @"Server=(localdb)\mssqllocaldb;Database=sebsa;Integrated Security=True");
        }
    }
}
