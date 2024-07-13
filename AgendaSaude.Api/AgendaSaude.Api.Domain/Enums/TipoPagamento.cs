using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaSaude.Api.Domain.Enums
{
    public enum TipoPagamento
    {
        [Description("Pix")]
        Pix = 1,

        [Description("Dinheiro")]
        Dinheiro = 2,

        [Description("Cartão Credito")]
        CartaoCredito = 3,

        [Description("Debito")]
        Debito = 4
    }
}
