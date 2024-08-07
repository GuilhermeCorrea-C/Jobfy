﻿using System.Text.Json.Serialization;

namespace Jobfy_API.Models
{
    public class Agendamento : Entidade
    {
        public string Endereco { get; set; }
        public string NomeCliente { get; set; }
        public string Telefone { get; set; }
        public decimal? ValorOrcamento { get; set; }
        public decimal? Despesas {  get; set; }
        public string TipoServico { get; set; }
        public string? Status { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim {  get; set; }
        public int UsuarioId { get; set; }
        [JsonIgnore]
        public Usuario? Usuario { get; set; }
    }
}
