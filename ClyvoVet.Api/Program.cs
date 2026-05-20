using ClyvoVet.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var databaseProvider = builder.Configuration["DatabaseProvider"];

builder.Services.AddDbContext<ClyvoVetDbContext>(options =>
{
    if (databaseProvider == "Oracle")
    {
        options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection"));
    }
    else
    {
        options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
    }
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();