using Jobfy_API.Data;
using Jobfy_API.Models;
using Jobfy_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Jobfy_API.Repositories
{
    public class AgendamentoRepository : IAgendamentoRepository
    {
        public readonly AppDBContext _dbContext;
        public readonly List<string> status = ["Pendente Confirmação", "Confirmado", "Cancelado"];
        public readonly IUsuarioRepository _usuarioRepository;

        public AgendamentoRepository(AppDBContext dbContext, IUsuarioRepository usuarioRepository)
        {
            _dbContext = dbContext;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Agendamento> InsertAgendamento(Agendamento agendamento)
        {
            try
            {
                agendamento.Status = "Pendente Confirmação";
                agendamento.Usuario = await _usuarioRepository.GetById(agendamento.UsuarioId);
                await _dbContext.Agendamento.AddAsync(agendamento);
                await _dbContext.SaveChangesAsync();
                return agendamento;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Agendamento>> GetAllAgendamentos(int id)
        {
            var listaAgendamentos = await _dbContext.Agendamento
                                                    .AsNoTracking()
                                                    .Where(x => x.UsuarioId == id)
                                                    .ToListAsync();
            return listaAgendamentos;
        }

        public async Task<Agendamento> SearchById(int id)
        {
            return await _dbContext.Agendamento.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Agendamento> EditarAgendamento(Agendamento agendamento)
        {
            var agendamentoDb = await SearchById(agendamento.Id);

            if (agendamentoDb is null)
                return null;

            agendamentoDb.Endereco = agendamento.Endereco;
            agendamentoDb.Telefone = agendamento.Telefone;
            agendamentoDb.TipoServico = agendamento.TipoServico;
            agendamentoDb.ValorOrcamento = agendamento.ValorOrcamento;
            agendamentoDb.NomeCliente = agendamento.NomeCliente;
            agendamentoDb.Despesas = agendamento.Despesas;
            agendamentoDb.DataFim = agendamento.DataFim;
            agendamentoDb.DataInicio = agendamento.DataInicio;

            if (agendamentoDb.Status == "Cancelado")
                agendamentoDb.Status = "Pendente Confirmação";

            _dbContext.Agendamento.Update(agendamentoDb);
            await _dbContext.SaveChangesAsync();

            return agendamentoDb;
        }

        public async Task<bool> AtualizarStatusAgendamento(int id, string status)
        {
            var agendamentoDb = await SearchById(id);

            if (agendamentoDb is null)
                return false;

            if (await VerificaConcomitancia(agendamentoDb) && status.Equals("Confirmar"))
                return false;

            switch(status)
            {
                case "Cancelar":
                  status = "Cancelado";
                  break;
                case "Confirmar":
                    status = "Confirmado";
                    break;
                default:
                    status = "Pendente Confirmação";
                    break;
            }

            if (!status.Contains(status))
                return false;

            agendamentoDb.Status = status;
            _dbContext.Agendamento.Update(agendamentoDb);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> VerificaConcomitancia(Agendamento agendamento)
        {
            var agendamentosConcomitantes = await _dbContext.Agendamento
                                                            .AsNoTracking()
                                                            .Where(x =>
                                                                x.DataInicio >= agendamento.DataInicio && 
                                                                x.DataFim <= agendamento.DataFim &&
                                                                x.Status == "Confirmado" &&
                                                                x.UsuarioId == agendamento.UsuarioId)
                                                            .ToListAsync();
            return agendamentosConcomitantes.Count > 0;
        }
    }
}
