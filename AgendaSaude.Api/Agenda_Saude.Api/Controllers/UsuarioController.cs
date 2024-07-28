using AgendaSaude.Api.Application.Interfaces;
using AgendaSaude.Api.Application.ViewModel;
using AgendaSaude.Api.Domain.Entities;
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
            var usuario = new UsuarioViewModel( usuarioViewModel.Name,usuarioViewModel.Email,usuarioViewModel.Senha,usuarioViewModel.Admin);

            UsuarioViewModel usuariocadastrar = await _usuarioservices.AdicionarUsuario(usuario);

            return Ok(usuariocadastrar);


        }

        [HttpGet("ListarUsuariosCadastrados/")]
        public async Task<ActionResult<List<UsuarioViewModel>>> BuscarTodosUsuariosCadastrados()
        {
            List<UsuarioViewModel> usuarios = await _usuarioservices.listarTodosUsuariosCadastrados();

            return Ok(usuarios);
        }

        [HttpGet("GetUsuarioPorId/")]
        public async Task<ActionResult<UsuarioViewModel>> BuscarUsuarioCadastradoPorId(Guid idUsuario)
        {
            UsuarioViewModel usuario = await _usuarioservices.GetUsuarioPorId(idUsuario);

            return Ok(usuario);
        }

        [HttpPut("AtualizarUsuariocadastrado/")]
        public async Task<ActionResult<UsuarioViewModel>> AtualizarUsuarioCadastrado(UsuarioViewModel usuario, Guid id)
        {
            UsuarioViewModel usuarioAtualizar = await _usuarioservices.AtualizarUsuarioCadastrado(usuario,id);

            return Ok(usuarioAtualizar);
        }

        [HttpDelete("DeletarUsuario/")]
        public async Task<ActionResult<UsuarioViewModel>> DeletarUsuario(Guid id)
        {
            await _usuarioservices.DeletarUsuario(id);

            return Ok(true);

        }

    }
}
