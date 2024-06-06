using Jobfy_API.Models;

namespace Jobfy_API.Repositories.Interfaces
{
    public interface IAgendamentoRepository
    {
        Task<Agendamento> InsertAgendamento(Agendamento agendamento);
        Task<IEnumerable<Agendamento>> GetAllAgendamentos();
        Task<Agendamento> SearchById(int id);
        Task<Agendamento> EditarAgendamento(Agendamento agendamento);
        Task<bool> AtualizarStatusAgendamento(int id, string status);
    }
}
