using Jobfy_API.Models;
using Jobfy_API.Models.ViewModels;
using Jobfy_API.Repositories.Interfaces;
using Jobfy_API.Services.Interfaces;

namespace Jobfy_API.Services
{
    public class AgendamentoService : IAgendamentoService
    {
        private readonly IAgendamentoRepository _agendamentoRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public AgendamentoService(IAgendamentoRepository agendamentoRepository, IUsuarioRepository usuarioRepository)
        {
            _agendamentoRepository = agendamentoRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Agendamento> CadastrarAgendamento(Agendamento agendamento)
        {
            if (agendamento is null)
                return null;

            return await _agendamentoRepository.InsertAgendamento(agendamento);
        }

        public Task<IEnumerable<Agendamento>> GetTodosAgendamentos(int id)
        {
            return _agendamentoRepository.GetAllAgendamentos(id);
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
                    Mensagem = "Já existe outro agendamento confirmado neste horário ou o agendamento especificado não foi encontrado."
                };

            return new AtualizacaoDecisao
            {
                Sucesso = true,
                Mensagem = "Status de agemento realizado com sucesso!"
            };
        }
    }
}
