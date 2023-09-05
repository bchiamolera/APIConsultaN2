global using ProjetoConsultaN2.Data;
global using ProjetoConsultaN2.Models;
global using ProjetoConsultaN2.DTOs.Consultas;
global using ProjetoConsultaN2.DTOs.Medicos;
global using ProjetoConsultaN2.DTOs.Pacientes;
global using ProjetoConsultaN2.Services;
global using ProjetoConsultaN2.Services.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMedicoService, MedicoService>();
builder.Services.AddScoped<IConsultaService, ConsultaService>(); 
builder.Services.AddScoped<IPacienteService, PacienteService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
