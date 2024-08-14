using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AgendaSaude.Api.Application.ViewModel
{
    public class PacienteViewModel
    {
        [IgnoreDataMember]
        public Guid IdPaciente { get; set; }

        [Required(ErrorMessage = "Informe o id do Proficional")]
        public Guid IdProficional { get; set; }

        [Required(ErrorMessage = "Informe o Nome do Paciente")]
        public string Nome { get; set; } = string.Empty;

        [RegularExpression(@"^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$")]
        [EmailAddress(ErrorMessage = "email invalido")]
        public string Email { get; set; } = string.Empty;

        public string Telefone { get; set; }
    }

    public class CreatePacienteViewMode
    {
        [Required(ErrorMessage = "Informe o id do Proficional")]
        public Guid IdProficional { get; set; }

        [Required(ErrorMessage = "Informe o Nome do Paciente")]
        public string Nome { get; set; } = string.Empty;

        [RegularExpression(@"^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$")]
        [EmailAddress(ErrorMessage = "email invalido")]
        public string Email { get; set; } = string.Empty;

        public string Telefone { get; set; }
    }

    public class EditarPacienteViewMode
    {

        [Required(ErrorMessage = "Informe o Nome do Paciente")]
        public string Nome { get; set; } = string.Empty;

        [RegularExpression(@"^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$")]
        [EmailAddress(ErrorMessage = "email invalido")]
        public string Email { get; set; } = string.Empty;

        public string Telefone { get; set; }
    }

    public class AgendaPacienteViewModel
    {

        [Required(ErrorMessage = "Informe o Nome do Paciente")]
        public string Nome { get; set; } = string.Empty;

        [RegularExpression(@"^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$")]
        [EmailAddress(ErrorMessage = "email invalido")]
        public string Email { get; set; } = string.Empty;

        public string Telefone { get; set; }
    }
}