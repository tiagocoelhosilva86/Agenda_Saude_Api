using AgendaSaude.Api.Application.Interfaces;
using AgendaSaude.Api.Application.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agenda_Saude.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : Controller
    {
        public readonly IPacienteServices _pacienteServices;

        public PacienteController(IPacienteServices pacienteServices)
        {
            _pacienteServices = pacienteServices;
        }

        [HttpPost("CadastrarPaciente/")]
        public async Task<ActionResult<PacienteViewModel>> CadastrarPaciente(CreatePacienteViewMode pacienteViewModel)
        {
            PacienteViewModel pacienteCadastrado = await _pacienteServices.AdicionarPaciente(pacienteViewModel);

            return Ok(pacienteCadastrado);
        }
    }
}
