using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desafio.Domain.Entities;
using Desafio.Infrastructure.Mapping;

namespace Desafio.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        DbSet<Paciente>? Pacientes { get; set;}
        DbSet<TipoExame>? TiposDeExame { get; set; }
        DbSet<Exame>? Exames { get; set; }
        DbSet<MarcacaoConsulta>? MarcacoesConsulta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Paciente>(new PacienteMap().Configure);
            modelBuilder.Entity<TipoExame>(new TipoExameMap().Configure);
            modelBuilder.Entity<Exame>(new ExameMap().Configure);
            modelBuilder.Entity<MarcacaoConsulta>(new MarcacaoConsultaMap().Configure);
        }

    }
}
