using Microsoft.EntityFrameworkCore;
using Parcial1.Data;

var builder = WebApplication.CreateBuilder(args);

<<<<<<< HEAD
// DbContext (cadena "Default" en appsettings.json / secrets)
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddControllers();
=======
// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
>>>>>>> origin/master
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

<<<<<<< HEAD
=======
// Configure the HTTP request pipeline.
>>>>>>> origin/master
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

<<<<<<< HEAD
app.MapControllers();
app.MapGet("/ping", () => Results.Ok(new { status = "ok" }));

app.Run();//
=======
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
>>>>>>> origin/master
