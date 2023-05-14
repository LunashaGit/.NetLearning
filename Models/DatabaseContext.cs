using Microsoft.EntityFrameworkCore;

namespace Todo.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
    }
}