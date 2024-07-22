using AgendaSaude.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace AgendaSaude.Api.Application.ViewModel
{
    public class UsuarioViewModel
    {
        [IgnoreDataMember]
        public Guid IdUsuario { get; set; }

        [Required(ErrorMessage = "Informe seu o nome")]
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o email")]
        [RegularExpression(@"^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$")]
        [EmailAddress(ErrorMessage = "email invalido")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe a senha")]
        [MinLength(7, ErrorMessage = "A senha deve ter 8 ou mais caracteres")]
        public string Senha { get; set; } = string.Empty;

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateRegistro { get; set; }

        public Boolean Admin { get; set; }

        public UsuarioViewModel()
        {
        }

        public UsuarioViewModel(string name, string email, string senha,Boolean admin)
        {
            this.IdUsuario = Guid.NewGuid();
            this.DateRegistro = DateTime.Now;
            Name = name;
            Email = email;
            Senha = senha;
            Admin = admin;
        }

        public UsuarioViewModel(Guid idUsuario, string name, string email, string senha, DateTime dateRegistro, bool admin)
        {
            IdUsuario = idUsuario;
            Name = name;
            Email = email;
            Senha = senha;
            DateRegistro = dateRegistro;
            Admin = admin;
        }
    }


}
