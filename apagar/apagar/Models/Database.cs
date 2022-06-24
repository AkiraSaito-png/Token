using Microsoft.EntityFrameworkCore;

namespace apagar.Models
{
    public class Database : DbContext
    {
        public Database(DbContextOptions<Database> options) : base(options)
        {

        }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
