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
    public class PacienteMap : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.ToTable("Paciente");

            builder.HasKey(paciente => paciente.Id);

            builder.Property(paciente => paciente.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("varchar(100)");

            builder.Property(paciente => paciente.CPF)
                .IsRequired()
                .HasColumnName("CPF")
                .HasColumnType("varchar(14)");

            builder.HasIndex(paciente => paciente.CPF)
                            .IsUnique();

            builder.Property(paciente => paciente.DataNascimento)
                .HasColumnName("DataNascimento")
                .HasColumnType("date");

            builder.Property(paciente => paciente.Sexo)
                .HasColumnName("Sexo")
                .HasColumnType("int");

            builder.Property(paciente => paciente.Telefone)
                .IsRequired()
                .HasColumnName("Telefone")
                .HasColumnType("varchar(20)");

            builder.Property(paciente => paciente.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("varchar(100)");
        }
    }
}
