using Jobfy_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jobfy_API.Data.Map
{
    public class AgendamentoMap : IEntityTypeConfiguration<Agendamento>
    {
        public void Configure(EntityTypeBuilder<Agendamento> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.NomeCliente).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Endereco).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Telefone).IsRequired();
            builder.Property(x => x.TipoServico).IsRequired();
        }
    }
}
