using System;
using System.ComponentModel.DataAnnotations;

namespace Parcial1.Models;

public class Product
{
    public int Id { get; set; }

    [Required, MaxLength(160)]
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    [Range(0, double.MaxValue)]
    public decimal Price { get; set; }

    [Range(0, int.MaxValue)]
    public int Stock { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}