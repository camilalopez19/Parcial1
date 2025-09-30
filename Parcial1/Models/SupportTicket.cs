namespace Parcial1.Models;

public class SupportTicket
{
    public int Id { get; set; }                           // PK

    public string Subject { get; set; } = null!;          // requerido
    public string RequesterEmail { get; set; } = null!;   // requerido

    public string? Description { get; set; }              // nullable
    public int Severity { get; set; }                     // p.ej. 1..5

    // "Open" | "InProgress" | "Closed"
    public string Status { get; set; } = "Open";

    public DateTimeOffset OpenedAt  { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? ClosedAt { get; set; }         // nullable
    public string? AssignedTo { get; set; }               // nullable
}