
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaSaude.Api.Domain.Enums;

namespace AgendaSaude.Api.Domain.Entities
{
    [Table("Pagamento")]
    public class Pagamento 
    {
        [Key]
        [DisplayName("IdPagamento")]
        public Guid IdPagamento { get; set; }

        public TipoPagamento Tipopagamento { get; set; }

        public ICollection<Agendamento> Agendamento { get; set; }

        public Pagamento(TipoPagamento tipopagamento, ICollection<Usuario> usuario, ICollection<Agendamento> agendamento)
        {
            IdPagamento = IdPagamento;
            this.Tipopagamento = tipopagamento;
            Agendamento = agendamento;
        }
    }
}
