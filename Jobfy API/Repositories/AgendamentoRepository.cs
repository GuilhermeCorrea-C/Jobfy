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

        public AgendamentoRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Agendamento> InsertAgendamento(Agendamento agendamento)
        {
            try
            {
                agendamento.Status = "Pendente Confirmação";
                await _dbContext.Agendamento.AddAsync(agendamento);
                await _dbContext.SaveChangesAsync();
                return agendamento;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Agendamento>> GetAllAgendamentos()
        {
            var listaAgendamentos = await _dbContext.Agendamento.ToListAsync();
            return listaAgendamentos;
        }

        public async Task<Agendamento> SearchById(int id)
        {
            return await _dbContext.Agendamento.FirstOrDefaultAsync(x => x.Id == id);
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

            _dbContext.Agendamento.Update(agendamentoDb);
            await _dbContext.SaveChangesAsync();

            return agendamentoDb;
        }

        public async Task<bool> AtualizarStatusAgendamento(int id, string status)
        {
            var agendamentoDb = await SearchById(id);

            if (agendamentoDb is null)
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
                    status = "";
                    break;
            }

            if (!status.Contains(status))
                return false;

            agendamentoDb.Status = status;
            _dbContext.Agendamento.Update(agendamentoDb);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
