using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobfy_API.Models;
using Jobfy_API.Services.Interfaces;
using Jobfy_API.Services.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Jobfy_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("cadastrar-usuario")]
        public async Task<ActionResult<Usuario>> CadastroUsuario([FromBody] Usuario user)
        {
            var usuarioCadastrado = await _usuarioService.RegistroUsuario(user);

            if (!usuarioCadastrado.Sucesso)
                return BadRequest(usuarioCadastrado);

            return Ok(usuarioCadastrado);
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginUsuarioResponse>> Login([FromBody] Usuario user)
        {
            var login = await _usuarioService.LoginUsuario(user);

            if (!login.Sucesso)
                return BadRequest(login);

            return Ok(login);
        }
    }
}