using AgendaSaude.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaSaude.Api.Infra.Data.EntitiesConfiguration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Senha).IsRequired();

            builder.HasMany(x => x.Pacientes)
                .WithOne(x => x.Usuario)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.IdProficional)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}