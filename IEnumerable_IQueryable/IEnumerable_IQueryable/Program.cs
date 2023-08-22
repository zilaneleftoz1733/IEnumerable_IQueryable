using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace IEnumerable_IQueryable
{
    class Program
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer("server=ZILAN_ELEFTOZ;database=IEnumerable_IQueryable; integrated security=true;TrustServerCertificate=True;");

            using (var dbContext = new AppDbContext(optionsBuilder.Options))
            {
                int iterations = 1000; // Number of iterations for accurate timing

                // Measure time for IEnumerable
                var stopwatchIEnumerable = Stopwatch.StartNew();
                for (int i = 0; i < iterations; i++)
                {
                    var productsIEnumerable = dbContext.Products.ToList();
                }
                stopwatchIEnumerable.Stop();
                Console.WriteLine($"IEnumerable Time: {stopwatchIEnumerable.ElapsedMilliseconds} ms");

                // Measure time for IQueryable
                var stopwatchIQueryable = Stopwatch.StartNew();
                for (int i = 0; i < iterations; i++)
                {
                    var productsIQueryable = dbContext.Products.Where(p => p.Price > 50).ToList();
                }
                stopwatchIQueryable.Stop();
                Console.WriteLine($"IQueryable Time: {stopwatchIQueryable.ElapsedMilliseconds} ms");

                var products = dbContext.Products.ToList();
                Console.WriteLine("Products:");
                foreach (var product in products)
                {
                    Console.WriteLine($"Product:Id : {product.Id} , Name: {product.Name}, Price: {product.Price}");
                }
            }
        }
    }
}
