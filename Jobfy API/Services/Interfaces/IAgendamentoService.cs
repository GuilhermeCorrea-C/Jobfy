using Jobfy_API.Models;
using Jobfy_API.Models.ViewModels;
using System;
using System.Collections.Specialized;

namespace Jobfy_API.Services.Interfaces
{
    public interface IAgendamentoService
    {
        Task<Agendamento> CadastrarAgendamento(Agendamento agendamento);
        Task<IEnumerable<Agendamento>> GetTodosAgendamentos();
        Task<Agendamento> EditarAgendamento(Agendamento agendamento);
        Task<AtualizacaoDecisao> AplicarDecisaoAgendamento(int id, string decisao);
    }
}
