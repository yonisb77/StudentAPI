using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Lägg till Controllers och Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrera Databas
builder.Services.AddDbContext<SkolaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrera Repository
builder.Services.AddScoped<IKursRepository, KursRepository>();

// Registrera MediatR (letar upp alla handlers i Application-lagret)
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Application.Queries.HamtaAllaKurserQuery).Assembly));

var app = builder.Build();

// Konfigurera HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();