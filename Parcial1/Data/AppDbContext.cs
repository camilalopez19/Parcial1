using Microsoft.EntityFrameworkCore;
using Parcial1.Models;

namespace Parcial1.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<SupportTicket> SupportTickets => Set<SupportTicket>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SupportTicket>(e =>
        {
            e.ToTable("support_tickets");
            e.HasKey(x => x.Id);

            e.Property(x => x.Subject)
                .IsRequired()
                .HasMaxLength(150);

            e.Property(x => x.RequesterEmail)
                .IsRequired()
                .HasMaxLength(320);

            e.Property(x => x.Description)
                .HasMaxLength(2000);

            e.Property(x => x.Status)
                .IsRequired()
                .HasMaxLength(30);

            e.Property(x => x.AssignedTo)
                .HasMaxLength(120);
        });
    }
}