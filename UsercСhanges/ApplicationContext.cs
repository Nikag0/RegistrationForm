using Microsoft.EntityFrameworkCore;


namespace UsercСhanges
{
    public class ApplicationContext : DbContext
    {
        public DbSet<DataUser> dataUsersSQLite { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=helloapp.db");
        }
    }
}
