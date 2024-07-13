using AgendaSaude.Api.Domain.Validations;
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
    [Table("Usuario")]
    public class Usuario
    {

        [Key]
        [DisplayName("IdUsuario")]
        public Guid IdUsuario { get;  set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "Informe seu o nome")]
        [MaxLength(150)]
        public string Name { get;  set; } = string.Empty;

        [DisplayName("Email")]
        [Required(ErrorMessage = "Informe o email")]
        [RegularExpression(@"^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$")]
        [EmailAddress(ErrorMessage = "email invalido")]
        public string Email { get;  set; } = string.Empty;

        [DisplayName("Senha")]
        [Required(ErrorMessage = "Informe a senha")]
        [MinLength(7, ErrorMessage = "A senha deve ter 8 ou mais caracteres")]
        public string Senha { get;  set; } = string.Empty;

        [DisplayName("Data Cadastro")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateRegistro { get;  set; }

        [DisplayName("Admin")]
        public Boolean Admin { get;  set; } = false;

        public ICollection<Agendamento> Agendamento { get; set; }


        public Usuario(string name, string email, string senha, DateTime dateRegistro, bool admin, ICollection<Agendamento> agendamento)
        {
            IdUsuario = IdUsuario;
            Name = name;
            Email = email;
            Senha = senha;
            DateRegistro = dateRegistro;
            Admin = admin;
        }

        public Usuario(Guid idUsuario, string name, DateTime dateRegistro, ICollection<Agendamento> agendamento)
        {
            IdUsuario = idUsuario;
            Name = name;
            DateRegistro = dateRegistro;
            Agendamento = agendamento;
        }
    }
}
