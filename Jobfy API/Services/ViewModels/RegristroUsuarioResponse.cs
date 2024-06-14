using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jobfy_API.Services.ViewModels
{
    public class RegristroUsuarioResponse
    {
        public int Id { get; set; }
        public bool Sucesso { get; set ; }
        public string Mensagem { get; set; }

        public RegristroUsuarioResponse()
        {
            this.Id = 0;
            this.Sucesso = false;
            this.Mensagem = "Falha ao cadastrar usuário";
        }
    }
}