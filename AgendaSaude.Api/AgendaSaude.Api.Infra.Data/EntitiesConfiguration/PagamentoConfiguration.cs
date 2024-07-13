using AgendaSaude.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaSaude.Api.Infra.Data.EntitiesConfiguration
{
    public class PagamentoConfiguration : IEntityTypeConfiguration<Pagamento>
    {
            public void Configure(EntityTypeBuilder<Pagamento> builder)
            {
            builder.HasKey(x => x.IdPagamento);
            builder.Property(x => x.Tipopagamento).IsRequired();
        }
    }
}
