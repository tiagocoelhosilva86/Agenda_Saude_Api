using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaSaude.Api.Domain.Entities
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        [DisplayName("Id")]
        public Guid Id { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "Informe seu o nome")]
        [MaxLength(150)]
        public string Nome { get; set; } = string.Empty;

        [DisplayName("Email")]
        [Required(ErrorMessage = "Informe o email")]
        [RegularExpression(@"^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$")]
        [EmailAddress(ErrorMessage = "email invalido")]
        public string Email { get; set; } = string.Empty;

        [DisplayName("Senha")]
        [Required(ErrorMessage = "Informe a senha")]
        [MinLength(7, ErrorMessage = "A senha deve ter 8 ou mais caracteres")]
        public string Senha { get; set; } = string.Empty;

        public ICollection<Paciente>? Pacientes { get; set; }
        public ICollection<Agenda>? Agendas { get; set; }
    }
}