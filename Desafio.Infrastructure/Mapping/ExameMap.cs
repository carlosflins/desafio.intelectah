using Desafio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Infrastructure.Mapping
{
    public class ExameMap : IEntityTypeConfiguration<Exame>
    {
        public void Configure(EntityTypeBuilder<Exame> builder)
        {
            builder.ToTable("Exame");

            builder.HasKey(exame => exame.Id);

            builder.Property(exame => exame.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("varchar(100)");

            builder.Property(exame => exame.Observacoes)
                .HasColumnName("Observacoes")
                .HasColumnType("varchar(1000)")
                .HasDefaultValue("");

            builder.HasOne<TipoExame>(exame => exame.TipoExame)
                .WithMany(tipoExame => tipoExame.Exames)
                .HasForeignKey(exame => exame.TipoExameId);
        }
    }
}
