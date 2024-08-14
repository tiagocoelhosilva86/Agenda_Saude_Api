using AgendaSaude.Api.Application.Interfaces;
using AgendaSaude.Api.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Agenda_Saude.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : Controller
    {
        public readonly IAgendaServices _agendaServices;

        public AgendaController(IAgendaServices agendaServices)
        {
            _agendaServices = agendaServices;
        }

        [HttpPost("CadastrarAgenda/")]
        public async Task<ActionResult<CreateAgendaViewModel>> CadastrarAgenda(CreateAgendaViewModel agendaViewModel)
        {
            CreateAgendaViewModel agendaCadastrar = await _agendaServices.AdicionarAgenda(agendaViewModel);

            return Ok(agendaCadastrar);
        }

        [HttpGet("listarAgendas/")]
        public async Task<ActionResult<List<AgendaViewModel>>> listarAgendas()
        {
            List<AgendaViewModel> listaAgenda = await _agendaServices.ListarAgenda();

            return Ok(listaAgenda);
        }

        [HttpGet("ListarAgendasPorIdProficional/")]
        public async Task<ActionResult<List<AgendaViewModel>>> listarAgendasPorIdProficional(Guid id)
        {
            List<AgendaViewModel> listaAgendasProficional = await _agendaServices.ListarAgendasPorIdProficional(id);

            return Ok(listaAgendasProficional);
        }

        [HttpGet("listarAgendasPorIdPaciente/")]
        public async Task<ActionResult<List<AgendaViewModel>>> ListarAgendasPorIdPaciente(Guid id)
        {
            List<AgendaViewModel> listarAgendasPaciente = await _agendaServices.ListarAgendasPorIdPaciente(id);

            return Ok(listarAgendasPaciente);
        }
            
     }
}
