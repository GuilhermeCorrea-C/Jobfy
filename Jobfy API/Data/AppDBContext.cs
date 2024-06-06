using Jobfy_API.Data.Map;
using Jobfy_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Jobfy_API.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<Agendamento> Agendamento {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AgendamentoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
