using AgendaSaude.Api.Domain.Entities;
using AgendaSaude.Api.Infra.Data.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;

namespace AgendaSaude.Api.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Paciente> Paciente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new PacienteConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}