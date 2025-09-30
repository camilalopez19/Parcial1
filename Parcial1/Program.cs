using Microsoft.EntityFrameworkCore;
using Parcial1.Data;

var builder = WebApplication.CreateBuilder(args);

// DbContext (cadena "Default" en appsettings.json / secrets)
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.MapGet("/ping", () => Results.Ok(new { status = "ok" }));

app.Run();//