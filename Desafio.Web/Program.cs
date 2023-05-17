using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces.Repository;
using Desafio.Domain.Interfaces.Service;
using Desafio.Infrastructure.Context;
using Desafio.Infrastructure.Repository;
using Desafio.Service.Services;
using Desafio.Service.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configura o DI para o DbContext.
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));

// Adiciona os repositórios.
builder.Services.AddScoped<IBaseRepository<TipoExame>, TipoExameRepository>();
builder.Services.AddScoped<IBaseRepository<Exame>, ExameRepository>();
builder.Services.AddScoped<IBaseRepository<Paciente>, PacienteRepository>();
builder.Services.AddScoped<IBaseRepository<MarcacaoConsulta>, MarcacaoConsultaRepository>();

// Adiciona os services.
builder.Services.AddScoped<IBaseService<TipoExame>, TipoExameService>();
builder.Services.AddScoped<IBaseService<Exame>, ExameService>();
builder.Services.AddScoped<IBaseService<Paciente>, PacienteService>();
builder.Services.AddScoped<IBaseService<MarcacaoConsulta>, MarcacaoConsultaService>();

// Adiciona os validadores.
builder.Services.AddScoped<IValidator<Paciente>, PacienteValidator>();
builder.Services.AddScoped<IValidator<TipoExame>, TipoExameValidator>();
builder.Services.AddScoped<IValidator<Exame>, ExameValidator>();
builder.Services.AddScoped<IValidator<MarcacaoConsulta>, MarcacaoConsultaValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
