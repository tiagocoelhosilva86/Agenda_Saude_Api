using AgendaSaude.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaSaude.Api.Application.ViewModel
{
    public class AgendaViewModel
    {
        public Guid IdAgenda { get; set; }

        [Required(ErrorMessage = "Informe o id do Paciente")]
        public Guid IdPaciente { get; set; }

        [Required(ErrorMessage = "Informe o id do Proficional")]
        public Guid IdProficional { get; set; }

        [Required(ErrorMessage = "Informe a Data inicio do Agendamento")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "Informe a Data Fim do Agendamento")]
        public DateTime DataFim { get; set; }
        public AgendaUsuarioViewModel Proficional { get; set; }
        public AgendaPacienteViewModel Paciente { get; set; }
    }

    public class CreateAgendaViewModel
    {

        [Required(ErrorMessage = "Informe o id do Paciente")]
        public Guid IdPaciente { get; set; }

        [Required(ErrorMessage = "Informe o id do Proficional")]
        public Guid IdProficional { get; set; }

        [Required(ErrorMessage = "Informe a Data inicio do Agendamento")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "Informe a Data Fim do Agendamento")]
        public DateTime DataFim { get; set; }
    }

    public class EditarAgendaViewModel
    {

        [Required(ErrorMessage = "Informe a Data inicio do Agendamento")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "Informe a Data Fim do Agendamento")]
        public DateTime DataFim { get; set; }
    }

}
