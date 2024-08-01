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
        public async Task<ActionResult<UsuarioViewModel>> CadastrarUsuario(CreateUsuarioViewModel createUsuarioViewModel)
        {
            var usuario = new UsuarioViewModel();

            usuario.Nome = createUsuarioViewModel.Nome;
            usuario.Email = createUsuarioViewModel.Email;
            usuario.Senha = createUsuarioViewModel.Senha;

            UsuarioViewModel usuariocadastrar = await _usuarioservices.AdicionarUsuario(usuario);

            return Ok(usuariocadastrar);


        }

        [HttpGet("ListarUsuariosCadastrados/")]
        public async Task<ActionResult<List<UsuarioViewModel>>> BuscarTodosUsuariosCadastrados()
        {
            List<UsuarioViewModel> usuarios = await _usuarioservices.listarTodosUsuariosCadastrados();

            return Ok(usuarios);
        }

        [HttpGet("BuscarUsuarioPorId/")]
        public async Task<ActionResult<UsuarioViewModel>> BuscarUsuarioCadastradoPorId(Guid idUsuario)
        {
            UsuarioViewModel usuario = await _usuarioservices.GetUsuarioPorId(idUsuario);

            return Ok(usuario);
        }

        [HttpPut("AtualizarUsuariocadastrado/")]
        public async Task<ActionResult<UsuarioViewModel>> AtualizarUsuarioCadastrado(CreateUsuarioViewModel createUsuarioViewModel, Guid id)
        {
            UsuarioViewModel usuarioAtualizar = await _usuarioservices.AtualizarUsuarioCadastrado(createUsuarioViewModel, id);

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
