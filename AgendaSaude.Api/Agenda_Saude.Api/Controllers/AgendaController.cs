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
        public async Task<ActionResult<AgendaViewModel>> CadastrarAgenda(CreateAgendaViewModel agendaViewModel)
        {
            AgendaViewModel agendaCadastrar = await _agendaServices.AdicionarAgenda(agendaViewModel);

            return Ok(agendaCadastrar);
        }
            
     }
}
