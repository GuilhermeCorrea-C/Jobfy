using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobfy_API.Data;
using Jobfy_API.Models;
using Jobfy_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Jobfy_API.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDBContext _context;

        public UsuarioRepository(AppDBContext context)
        {
            _context = context;
        }

        public Task<Usuario> LoginUsuario(Usuario user)
        {
            try
            {
                var usuarioDB = _context.Usuario.FirstOrDefaultAsync(x => x.Email == user.Email && x.Senha == user.Senha);

                if (usuarioDB is not null)
                    return usuarioDB;

                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<Usuario> SalvarUsuario(Usuario user)
        {
            try
            {
                await _context.Usuario.AddAsync(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception)
            {
                return null;
            }
            
        }
    }
}