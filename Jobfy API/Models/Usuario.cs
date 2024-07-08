using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.Data;

namespace Jobfy_API.Models
{
    public class Usuario : Entidade
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        [JsonIgnore]
        public ICollection<Agendamento>? Agendamentos { get; set;} = new HashSet<Agendamento>();
    }
}