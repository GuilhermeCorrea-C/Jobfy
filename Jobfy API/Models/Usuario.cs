using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.Data;

namespace Jobfy_API.Models
{
    public class Usuario : Entidade
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}