using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using AgenziaViaggi.Models;

namespace AgenziaViaggi.Database
{
    public class TourContext : DbContext
    {
        public DbSet<Tour> Tours { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=TourDB;" +
            "Integrated Security=True;TrustServerCertificate=True");
        }

    }
}
