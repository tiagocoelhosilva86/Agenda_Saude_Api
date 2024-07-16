using AgendaSaude.Api.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaSaude.Api.Domain.Entities
{
    [Table("Agendamento")]
    public class Agendamento
    {
        [Key]
        [DisplayName("IdAgenda")]
        public Guid IdAgenda { get; set; }

        [DisplayName("Descrição")]
        [MaxLength(250)]
        public string Descricao { get; set; }

        [DisplayName("Data Agendamento")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Informe a Data do Agendamento")]
        public DateTime DataAgendamendo { get; set; }

        [DisplayName("Confirmação Agendamento")]
        public Boolean ConfirmacaoAgendamento { get; set; }

        [DisplayName("Forma de Pagamento")]
        [Required(ErrorMessage = "Informe a Forma de Pagamento")]
        public TipoPagamento TipoPagamento { get; set; }

        [DisplayName("Valor Consulta")]
        [Required(ErrorMessage = "Informe o Valor da Consulta")]
        public string ValorConsulta { get; set; }

        [DisplayName("Id Usuario")]
        [Required(ErrorMessage = "Informe o Id do Usuario")]
        public Guid IdUsuario { get; set; }

        public Usuario Usuario { get; set; }

        [DisplayName("Id Pagamento")]
        public Guid IdPagamento { get; set; }

        public Pagamento Pagamento { get; set; }




    }
}
