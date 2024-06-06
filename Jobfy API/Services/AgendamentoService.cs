using Jobfy_API.Models;
using Jobfy_API.Models.ViewModels;
using Jobfy_API.Repositories.Interfaces;
using Jobfy_API.Services.Interfaces;

namespace Jobfy_API.Services
{
    public class AgendamentoService : IAgendamentoService
    {
        private readonly IAgendamentoRepository _agendamentoRepository;

        public AgendamentoService(IAgendamentoRepository agendamentoRepository)
        {
            _agendamentoRepository = agendamentoRepository;
        }

        public async Task<Agendamento> CadastrarAgendamento(Agendamento agendamento)
        {
            if (agendamento is null)
                return null;

            return await _agendamentoRepository.InsertAgendamento(agendamento);
        }

        public Task<IEnumerable<Agendamento>> GetTodosAgendamentos()
        {
            return _agendamentoRepository.GetAllAgendamentos();
        }

        public async Task<Agendamento> EditarAgendamento(Agendamento agendamento)
        {
            var agendamentoUpdate = await _agendamentoRepository.EditarAgendamento(agendamento);

            if (agendamentoUpdate is null)
                return null;

            return agendamentoUpdate;
        }

        public async Task<AtualizacaoDecisao> AplicarDecisaoAgendamento(int id, string decisao)
        {
            var decisaoAtualizada = await _agendamentoRepository.AtualizarStatusAgendamento(id, decisao);

            if (!decisaoAtualizada)
                return new AtualizacaoDecisao
                {
                    Sucesso = false,
                    Mensagem = "Ocorreu um erro ao atualizar o status do agendamento."
                };

            return new AtualizacaoDecisao
            {
                Sucesso = true,
                Mensagem = "Status de agemento realizado com sucesso!"
            };
        }
    }
}
