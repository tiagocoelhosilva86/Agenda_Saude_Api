using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace AgendaSaude.Api.Application.ViewModel
{
    public class UsuarioViewModel
    {
        [IgnoreDataMember]
        public Guid IdUsuario { get; set; }

        [Required(ErrorMessage = "Informe seu o nome")]
        [MaxLength(150)]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o email")]
        [RegularExpression(@"^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$")]
        [EmailAddress(ErrorMessage = "email invalido")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe a senha")]
        [MinLength(7, ErrorMessage = "A senha deve ter 8 ou mais caracteres")]
        public string Senha { get; set; } = string.Empty;
    }

    public class CreateUsuarioViewModel
    {

        [Required(ErrorMessage = "Informe seu o nome")]
        [MaxLength(150)]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o email")]
        [RegularExpression(@"^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$")]
        [EmailAddress(ErrorMessage = "email invalido")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe a senha")]
        [MinLength(7, ErrorMessage = "A senha deve ter 8 ou mais caracteres")]
        public string Senha { get; set; } = string.Empty;
    }

    public class AgendaUsuarioViewModel
    {

        [Required(ErrorMessage = "Informe seu o nome")]
        [MaxLength(150)]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o email")]
        [RegularExpression(@"^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$")]
        [EmailAddress(ErrorMessage = "email invalido")]
        public string Email { get; set; } = string.Empty;
    }
}