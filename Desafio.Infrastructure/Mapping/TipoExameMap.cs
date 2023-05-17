using Desafio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Infrastructure.Mapping
{
    public class TipoExameMap : IEntityTypeConfiguration<TipoExame>
    {
        public void Configure(EntityTypeBuilder<TipoExame> builder)
        {
            builder.ToTable("TipoExame");

            builder.HasKey(tipoExame => tipoExame.Id);

            builder.Property(tipoExame => tipoExame.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("varchar(100)");

            builder.Property(tipoExame => tipoExame.Descricao)
                .HasColumnName("Descricao")
                .HasColumnType("varchar(256)")
                .HasDefaultValue("");
        }
    }
}
