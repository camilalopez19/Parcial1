namespace Parcial1.Models;

public class Event
{
    public int Id { get; set; }            // PK
    public string Title { get; set; } = null!;
    public string Location { get; set; } = null!;
    public DateTime StartAt { get; set; }
    public DateTime? EndAt { get; set; }
    public bool IsOnline { get; set; }
    public string? Notes { get; set; }
}