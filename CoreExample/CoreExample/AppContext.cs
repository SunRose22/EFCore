using Microsoft.EntityFrameworkCore;


    public class AppContext : DbContext
    {
        public DbSet<Tester> Tester { get; set; }

        public AppContext(DbContextOptions<AppContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
