using AgendaSaude.Api.Application.ViewModel;
using AgendaSaude.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaSaude.Api.Application.Interfaces
{
    public interface IUsuarioServices
    {
        Task<UsuarioViewModel> AdicionarUsuario(UsuarioViewModel usuarioViewModel);
    }
}
