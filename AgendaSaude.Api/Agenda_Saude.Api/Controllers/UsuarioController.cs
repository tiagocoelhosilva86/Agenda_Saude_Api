using AgendaSaude.Api.Application.Interfaces;
using AgendaSaude.Api.Application.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agenda_Saude.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServices _usuarioservices;

        public UsuarioController(IUsuarioServices usuarioservices)
        {
            _usuarioservices = usuarioservices;
        }

        [HttpPost("CadastrarUsuario/")]
        public async Task<ActionResult<UsuarioViewModel>> CadastrarUsuario(UsuarioViewModel usuarioViewModel)
        {
            var usuario = new UsuarioViewModel( usuarioViewModel.Name,usuarioViewModel.Email,usuarioViewModel.Senha);

            UsuarioViewModel usuariocadastrar = await _usuarioservices.AdicionarUsuario(usuario);

            return Ok(usuariocadastrar);


        }

    }
}
