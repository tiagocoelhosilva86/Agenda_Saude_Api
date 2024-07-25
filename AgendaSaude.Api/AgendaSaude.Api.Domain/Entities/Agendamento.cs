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
        [Required(ErrorMessage = "Informe a Forma de Pagamento")]
        public string Descricao { get; set; }

        [DisplayName("Paciente")]
        [MaxLength(150)]
        [Required(ErrorMessage = "Informe o nome do paciente")]
        public string Paciente { get; set; }

        [DisplayName("Telefone")]
        public string Telefone { get; set; }

        [DisplayName("Endereço")]
        [MaxLength(250)]
        public string Endereco { get; set; }

        [DisplayName("Email")]
        [RegularExpression(@"^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$")]
        [EmailAddress(ErrorMessage = "email invalido")]
        public string Email { get; set; } = string.Empty;

        [DisplayName("Data Agendamento")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Informe a Data do Agendamento")]
        public DateTime DataAgendamendo { get; set; }

        [DisplayName("Confirmação Agendamento")]
        public Boolean ConfirmacaoAgendamento { get; set; }

        [DisplayName("Forma de Pagamento")]
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
