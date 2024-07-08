namespace Jobfy_API.Models.ViewModels
{
    public class CadastrarAgendamentoViewModel
    {
        public string Endereco { get; set; }
        public string NomeCliente { get; set; }
        public string Telefone { get; set; }
        public decimal? ValorOrcamento { get; set; }
        public decimal? Despesas { get; set; }
        public string TipoServico { get; set; }
        public string? Status { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int UsuarioId { get; set; }
    }
}
