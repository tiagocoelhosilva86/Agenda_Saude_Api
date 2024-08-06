using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaSaude.Api.Domain.Entities
{
    [Table("Paciente")]
    public class Paciente
    {
        [Key]
        [DisplayName("Id")]
        public Guid IdPaciente { get; set; }

        [DisplayName("IdProficional")]
        public Guid IdProficional { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "Informe o Nome do Paciente")]
        public string Nome { get; set; }

        [DisplayName("Email")]
        [RegularExpression(@"^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$")]
        [EmailAddress(ErrorMessage = "email invalido")]
        public string Email { get; set; } = string.Empty;

        [DisplayName("Telefone")]
        public string Telefone { get; set; }

        public Usuario Usuario { get; set; }
        public ICollection<Agenda>? Agendas { get; set; }
    }
}