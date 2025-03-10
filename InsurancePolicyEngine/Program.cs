using Insurance.Application.Commands;
using Insurance.Domain.DataContracts;
using Insurance.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<InsuranceDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateContractHandler>());

// Register repositories
builder.Services.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
builder.Services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));

// Register MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
