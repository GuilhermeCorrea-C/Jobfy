using Jobfy_API.Data;
using Jobfy_API.Repositories;
using Jobfy_API.Repositories.Interfaces;
using Jobfy_API.Services;
using Jobfy_API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDBContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionStrings"))
);

builder.Services.AddScoped<IAgendamentoRepository, AgendamentoRepository>();
builder.Services.AddScoped<IAgendamentoService, AgendamentoService>();

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
