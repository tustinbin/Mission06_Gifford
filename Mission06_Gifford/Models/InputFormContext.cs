using Microsoft.EntityFrameworkCore;

namespace Mission06_Gifford.Models
{
    public class InputFormContext : DbContext
    {
        public InputFormContext(DbContextOptions<InputFormContext> options) : base (options) 
        { }

        public DbSet<InputForm> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }


    }
}
