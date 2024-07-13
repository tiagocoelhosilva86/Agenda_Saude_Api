using AgendaSaude.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaSaude.Api.Infra.Data.Context
{
    public class ApplicationDbContext: DbContext
    {
        protected ApplicationDbContext(DbContextOptions options) :base(options) { }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Agendamento> Agendamento { get; set; }
        public DbSet<Pagamento> Pagamento { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

    }
}
