using Microsoft.EntityFrameworkCore;
using Parcial1.Models;

namespace Parcial1.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Event> Event => Set<Event>();
    public DbSet<Product> Product => Set<Product>();
    public DbSet<Ticket> Ticket => Set<Ticket>();
}