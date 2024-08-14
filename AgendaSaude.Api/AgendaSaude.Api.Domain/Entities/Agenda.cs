
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AgendaSaude.Api.Domain.Entities
{
    public class Agenda
    {
        [Key]
        [DisplayName("Id")]
        public Guid IdAgenda { get; set; }

        [DisplayName("IdPaciente")]
        public Guid IdPaciente { get; set; }

        [DisplayName("IdProficional")]
        public Guid IdProficional { get; set; }

        [DisplayName("DataInicio")]
        [Required(ErrorMessage = "Informe a Data inicio do Agendamento")]
        public DateTime DataInicio { get; set; }

        [DisplayName("DataFim")]
        [Required(ErrorMessage = "Informe a Data Fim do Agendamento")]
        public DateTime DataFim { get; set; }
        public Usuario Proficional { get; set; }
        public Paciente Paciente { get; set; }
    }
}
