using Microsoft.EntityFrameworkCore;


namespace IEnumerable_IQueryable
{
    public class AppDbContext : DbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=ZILAN_ELEFTOZ;database=IEnumerable_IQueryable; integrated security=true;TrustServerCertificate=True;");
        }
    }

}



