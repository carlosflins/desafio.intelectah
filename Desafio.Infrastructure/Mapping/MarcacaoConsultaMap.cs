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
    public class MarcacaoConsultaMap : IEntityTypeConfiguration<MarcacaoConsulta>
    {
        public void Configure(EntityTypeBuilder<MarcacaoConsulta> builder)
        {
            builder.ToTable("MarcacaoConsulta");

            builder.HasKey(marcacaoConsulta => marcacaoConsulta.Id);

            builder.HasOne<Paciente>(marcacaoConsulta => marcacaoConsulta.Paciente)
                .WithMany(paciente => paciente.MarcacoesConsulta)
                .HasForeignKey(marcacaoConsulta => marcacaoConsulta.PacienteId)
                .IsRequired();

            builder.HasOne<TipoExame>(marcacaoConsulta => marcacaoConsulta.TipoExame)
                .WithMany(tipoExame => tipoExame.MarcacoesConsulta)
                .HasForeignKey(marcacaoConsulta => marcacaoConsulta.TipoExameId)
                .IsRequired();

            builder.Property(marcacaoConsulta => marcacaoConsulta.DataHoraMarcacao)
                .IsRequired()
                .HasColumnName("DataHoraMarcacao")
                .HasColumnType("datetime");

            builder.Property(marcacaoConsulta => marcacaoConsulta.Protocolo)
                .IsRequired()
                .HasColumnName("Protocolo")
                .HasColumnType("varchar(40)");

            builder.HasIndex(marcacaoConsulta => marcacaoConsulta.Protocolo)
                .IsUnique();
        }
    }
}
