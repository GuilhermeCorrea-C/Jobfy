using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobfy_API.Models;
using Jobfy_API.Services.ViewModels;

namespace Jobfy_API.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<RegristroUsuarioResponse> RegistroUsuario(Usuario user);
        Task<LoginUsuarioResponse> LoginUsuario(Usuario user);
    }
}