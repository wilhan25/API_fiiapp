// Data/FiiApiContext.cs
using Microsoft.EntityFrameworkCore;
using fiiApi.Models; // Ajuste para o namespace correto dos modelos

namespace fiiApi.Data
{
   public class FiiApiContext : DbContext
    {
        public FiiApiContext(DbContextOptions<FiiApiContext> options)
            : base(options)
        {
        }

        public DbSet<FundoImobiliario> FundosImobiliarios { get; set; }
    }
}
