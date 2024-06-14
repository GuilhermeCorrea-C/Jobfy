using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobfy_API.Models;
using Jobfy_API.Repositories.Interfaces;
using Jobfy_API.Services.ViewModels;

namespace Jobfy_API.Services.Interfaces
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;   
        }

        public async Task<LoginUsuarioResponse> LoginUsuario(Usuario user)
        {
            var usuario = await _usuarioRepository.LoginUsuario(user);

            if (usuario is not null)
                return new LoginUsuarioResponse
                {
                    Sucesso = true,
                    Mensagem = "Usuário logado com sucesso.",
                    UsuarioId = usuario.Id
                };

            return new LoginUsuarioResponse();
        }

        public async Task<RegristroUsuarioResponse> RegistroUsuario(Usuario user)
        {
            var usuario = await _usuarioRepository.SalvarUsuario(user);

            if (usuario is not null)
                return new RegristroUsuarioResponse
                {
                    Id = usuario.Id,
                    Sucesso = true,
                    Mensagem = "Usuário cadastrado com sucesso."
                };

            return new RegristroUsuarioResponse();
        }


    }
}