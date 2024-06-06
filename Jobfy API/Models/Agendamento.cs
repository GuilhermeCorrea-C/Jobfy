namespace Jobfy_API.Models
{
    public class Agendamento : Entidade
    {
        public string Endereco { get; set; }
        public string NomeCliente { get; set; }
        public string Telefone { get; set; }
        public decimal? ValorOrcamento { get; set; }
        public string TipoServico { get; set; }
        public string? Status { get; set; }
    }
}
