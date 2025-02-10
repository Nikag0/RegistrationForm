using Microsoft.EntityFrameworkCore;

namespace UsercСhanges  
{
    public class ApplicationContext : DbContext
    {
        public DbSet<DataUser> TenMillionPgSQL { get; set; } = null!;
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=helloapp.db");
        //}

        //public ApplicationContext()
        //{
        //    Database.EnsureCreated();
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost; Port=5432; Database=TenMillionPgSQL; Username = postgres; Password=Nikago2280.");
        }
    }
}
