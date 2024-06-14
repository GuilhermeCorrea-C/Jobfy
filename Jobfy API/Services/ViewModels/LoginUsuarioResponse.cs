using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jobfy_API.Services.ViewModels
{
    public class LoginUsuarioResponse
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public int UsuarioId { get; set; }

        public LoginUsuarioResponse()
        {
            this.Sucesso = false;
            this.Mensagem = "Erro ao realizar login do usuário.";
            this.UsuarioId = 0;
        }
    }
}