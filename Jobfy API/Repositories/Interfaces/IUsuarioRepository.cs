using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobfy_API.Models;

namespace Jobfy_API.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> SalvarUsuario(Usuario user);
        Task<Usuario> LoginUsuario(Usuario user);
        Task<Usuario> GetById(int id);
    }
}