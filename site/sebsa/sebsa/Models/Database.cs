using Microsoft.EntityFrameworkCore;

namespace sebsa.Models
{
    public class Database : DbContext
    {
        public Database(DbContextOptions<Database> options) : base(options)
        {

        }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
