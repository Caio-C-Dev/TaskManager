using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TaskManager.API.Application.UseCases;
using TaskManager.API.Application.UseCases.ConcluirTarefa;
using TaskManager.API.Application.UseCases.CriarTarefa;
using TaskManager.API.Application.UseCases.DeletarTarefa;
using TaskManager.API.Application.UseCases.EditarTarefas;
using TaskManager.API.Application.UseCases.ListarTarefas;
using TaskManager.API.Domain.Interfaces;
using TaskManager.API.Infraestructure.Persistence;
using TaskManager.API.Presentation.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Banco de dados
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Injeção de dependência
builder.Services.AddScoped<CriarTarefaUseCase>();
builder.Services.AddScoped<ListarTarefasUseCase>();
builder.Services.AddScoped<ConcluirTarefaUseCase>();
builder.Services.AddScoped<EditarTarefaUseCase>();
builder.Services.AddScoped<DeletarTarefaUseCase>();
builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();
builder.Services.AddValidatorsFromAssemblyContaining<CriarTarefaValidator>();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();