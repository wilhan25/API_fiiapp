using Microsoft.EntityFrameworkCore;
using fiiApi.Models;

namespace fiiApi.Data
{
    public class FiiApiContext : DbContext
    {
        public FiiApiContext(DbContextOptions<FiiApiContext> options) : base(options) { }

        public DbSet<FundoImobiliario> FundosImobiliarios { get; set; }
        public DbSet<Investidor> Investidores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração do relacionamento muitos-para-muitos entre Investidor e FundoImobiliario.
            modelBuilder.Entity<Investidor>()
                .HasMany(i => i.Carteira)
                .WithMany(f => f.Investidores)
                .UsingEntity(j => j.ToTable("InvestidorFundos"));
        }
    }
}
